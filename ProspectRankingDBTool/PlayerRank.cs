using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProspectRankingDBTool
{
    public partial class PlayerRank : UserControl
    {
        private class PlayerInfo
        {
            private Player m_player;

            public PlayerInfo(Player player)
            {
                m_player = player;
            }

            override public string ToString()
            {
                string name = m_player.Lastname + ", " + m_player.Firstname + " - " + m_player.Position + " " + m_player.Organization;

                return name;
            }

            public Player GetPlayer()
            {
                return m_player;
            }
        };

        private PlayerRanking m_playerRanking;
        private BaseballModelContext m_context;
        private List<PlayerInfo> m_players;
        private List<string> m_organizationEnum;
        private List<string> m_gradesEnum;

        public PlayerRank()
        {
            InitializeComponent();
        }

        public PlayerRank(PlayerRanking player)
        {
            InitializeComponent();

            m_playerRanking = player;
        }

        /*private void PlayerRank_Load(object sender, EventArgs e)
        {
        }*/

        public PlayerRanking PlayerRankValue
        {
            get
            {
                return m_playerRanking;
            }
            set
            {
                m_playerRanking = value;

                if (m_playerRanking != null)
                {
                    int selectedIndex = m_organizationEnum.IndexOf(m_playerRanking.OrganizationID);
                    if (selectedIndex >= 0)
                    {
                        cbOrganization.SelectedIndex = selectedIndex;
                    }

                    selectedIndex = m_gradesEnum.IndexOf(m_playerRanking.Grade);
                    if (selectedIndex >= 0)
                    {
                        cbGrade.SelectedIndex = selectedIndex;
                    }

                    if (m_playerRanking.Rank != null)
                    {
                        numRank.Value = (sbyte)m_playerRanking.Rank;
                    }
                }
            }
        }

        private void InitPlayerRanking()
        {
            m_organizationEnum = new List<string>(m_context.Organizations);
            m_organizationEnum.Insert(0, "");
            cbOrganization.DataSource = m_organizationEnum;

            m_gradesEnum = new List<string>(m_context.Grades);
            m_gradesEnum.Insert(0, "");
            cbGrade.DataSource = m_gradesEnum;

            m_players = new List<PlayerInfo>();
            
            var query = from it in m_context.DBContext.Players
                        orderby it.Lastname, it.Firstname
                        select it;

            foreach (Player player in query)
            {
                PlayerInfo playerInfo = new PlayerInfo(player);
                m_players.Add(playerInfo);
            }

            cbPlayerName.DataSource = m_players;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            m_context.DBContext.SaveChanges();
        }

        private void cbPlayerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_playerRanking != null)
            {
                m_playerRanking.Player = m_players.ElementAt(cbPlayerName.SelectedIndex).GetPlayer();
            }
        }

        private void cbOrganization_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_playerRanking != null)
            {
                m_playerRanking.OrganizationID = m_organizationEnum.ElementAt(cbOrganization.SelectedIndex);
            }
        }

        private void cbGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_playerRanking != null)
            {
                m_playerRanking.Grade = m_gradesEnum.ElementAt(cbGrade.SelectedIndex);
            }
        }

        private void PlayerRank_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            m_context = BaseballModelContext.Instance;

            InitPlayerRanking();
        }

        private void numRank_ValueChanged(object sender, EventArgs e)
        {
            if (m_playerRanking != null)
            {
                m_playerRanking.Rank = (sbyte)numRank.Value;
            }
        }
    }
}
