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
        private PlayerList m_playerList;
        private URL m_url;

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

        public PlayerList PlayerListRef
        {
            set
            {
                m_playerList = value;
            }
        }

        public URL UrlRef
        {
            set
            {
                m_url = value;
            }
        }

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
                    else if (m_playerList != null)
                    {
                        selectedIndex = m_organizationEnum.IndexOf(m_playerList.Organization);
                        if (selectedIndex >= 0)
                        {
                            cbOrganization.SelectedIndex = selectedIndex;
                            m_playerRanking.OrganizationID = m_playerList.Organization;
                        }
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
            cbOrganization.DataSource = m_organizationEnum;

            m_gradesEnum = new List<string>(m_context.Grades);
            m_gradesEnum.Insert(0, "");
            cbGrade.DataSource = m_gradesEnum;

            UpdatePlayerList();
        }

        private void UpdatePlayerList()
        {
            if (m_players == null)
            {
                m_players = new List<PlayerInfo>();
            }
            else
            {
                m_players.Clear();
            }

            if (m_playerList != null && m_playerList.Organization != "MLB")
            {
                var query = from it in m_context.DBContext.Players
                            where it.Organization == m_playerList.Organization
                            orderby it.Lastname, it.Firstname
                            select it;
                foreach (Player player in query)
                {
                    PlayerInfo playerInfo = new PlayerInfo(player);
                    m_players.Add(playerInfo);
                }
                
                query = from it in m_context.DBContext.Players
                            where it.Organization != m_playerList.Organization
                            orderby it.Lastname, it.Firstname
                            select it;
                foreach (Player player in query)
                {
                    PlayerInfo playerInfo = new PlayerInfo(player);
                    m_players.Add(playerInfo);
                }
            }
            else
            {
                var query = from it in m_context.DBContext.Players
                            orderby it.Lastname, it.Firstname
                            select it;

                foreach (Player player in query)
                {
                    PlayerInfo playerInfo = new PlayerInfo(player);
                    m_players.Add(playerInfo);
                }
            }

            cbPlayerName.DataSource = m_players;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            m_playerRanking.PlayerList = m_playerList;
            m_playerRanking.URL = m_url;
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

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            NewPlayer form = new NewPlayer();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UpdatePlayerList();
            }
        }
    }
}
