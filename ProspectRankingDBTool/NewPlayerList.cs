using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProspectRankingDBTool
{
    public partial class NewPlayerList : Form
    {
        private URL m_url;
        private PlayerList m_playerList;
        private List<PlayerRanking> m_playerRankingsList;
        private BaseballModelContext m_context;
        private List<string> m_positionEnum;
        private List<string> m_organizationEnum;

        private string m_PreSeason = "Pre";
        private string m_InSeason = "In";

        private bool m_playerListAdded = false;

        public NewPlayerList()
        {
            InitializeComponent();
        }

        private void NewPlayerList_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            m_context = BaseballModelContext.Instance;

            InitializeData();
        }

        private void InitializeData()
        {
            m_url = new URL();
            m_playerList = new PlayerList();

            urlInfo1.URLObject = m_url;

            m_playerList.Number = (byte)numRankings.Value;
            m_playerList.Year = (short)numYear.Value;
            m_playerList.Season = m_PreSeason;
            m_playerList.URL = m_url;

            rbPreSeason.Checked = true;

            m_positionEnum = new List<string>(m_context.Positions);
            m_positionEnum.Insert(0, "");
            m_organizationEnum = new List<string>(m_context.Organizations);
            m_organizationEnum.Insert(0, "");

            hScrollBar1.Maximum = 1;

            m_context.DBContext.URLs.AddObject(m_url);
        }

        private void rbPreSeason_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPreSeason.Checked)
            {
                m_playerList.Season = m_PreSeason;
            }
        }

        private void rbInSeason_CheckedChanged(object sender, EventArgs e)
        {
            if (rbInSeason.Checked)
            {
                m_playerList.Season = m_InSeason;
            }
        }

        private void cbOrganization_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_playerList.Organization = cbOrganization.SelectedValue.ToString();
        }

        private void cbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_playerList.Position = cbPosition.SelectedValue.ToString();
        }

        private void numRankings_ValueChanged(object sender, EventArgs e)
        {
            m_playerList.Number = (byte)numRankings.Value;
        }

        private void cbPublic_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPublic.Checked)
            {
                m_playerList.Public = "Y";
            }
            else
            {
                m_playerList.Public = "N";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (m_context == null)
                return;

            if (!m_playerListAdded)
            {
                m_context.DBContext.PlayerLists.AddObject(m_playerList);
                m_playerListAdded = true;
            }

            m_context.DBContext.SaveChanges();

            hScrollBar1.Maximum = (int)numRankings.Value;

            m_playerRankingsList = new List<PlayerRanking>();

            for (int i = 0; i < numRankings.Value; i++)
            {
                PlayerRanking player = new PlayerRanking();
                player.URL = m_url;
                player.PlayerList = m_playerList;
                player.Rank = (sbyte)(i+1);
                m_context.DBContext.PlayerRankings.AddObject(player);
                m_playerRankingsList.Add(player);
            }

            playerRank1.PlayerRankValue = m_playerRankingsList[0];

            btnSave.Enabled = false;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            playerRank1.PlayerRankValue = m_playerRankingsList[hScrollBar1.Value - 1];
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (m_context == null)
                return;

            m_context.DBContext.SaveChanges();
        }
    }
}
