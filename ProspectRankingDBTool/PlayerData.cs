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
    public partial class PlayerData : UserControl
    {
        private Player m_player;

        private BaseballModelContext m_context;

        private List<string> m_positionEnum;
        private List<string> m_throwEnum;
        private List<string> m_batEnum;
        private List<string> m_organizationEnum;

        public PlayerData()
        {
            InitializeComponent();

            m_player = new Player();
        }

        public PlayerData(Player player)
        {
            InitializeComponent();

            m_player = player;
        }

        public Player PlayerEntity
        {
            get
            {
                return m_player;
            }
        }

        private void InitializePlayerData()
        {
            txtFirstName.Text = m_player.Firstname;
            txtLastName.Text = m_player.Lastname;
            txtBRUrl.Text = m_player.BasebaRef;
            txtFGUrl.Text = m_player.Fangraphs;

            if (m_player.DOB != null)
            {
                dateDOB.Value = (System.DateTime)m_player.DOB;
            }
            if (m_player.Height != null)
            {
                numHeight.Value = (decimal)m_player.Height;
            }
            if (m_player.Weight != null)
            {
                numWeight.Value = (decimal)m_player.Weight;
            }

            m_positionEnum = new List<string>(m_context.Positions);
            m_positionEnum.Insert(0, "");
            m_throwEnum = new List<string>(m_context.Throwing);
            m_throwEnum.Insert(0, "");
            m_batEnum = new List<string>(m_context.Batting);
            m_batEnum.Insert(0, "");
            m_organizationEnum = new List<string>(m_context.Organizations);
            m_organizationEnum.Insert(0, "");

            cbBat.DataSource = m_batEnum;
            cbPosition.DataSource = m_positionEnum;
            cbThrow.DataSource = m_throwEnum;
            cbOrganization.DataSource = m_organizationEnum;

            SetCBIndex(m_player.Bat, m_batEnum, cbBat);
            SetCBIndex(m_player.Position, m_positionEnum, cbPosition);
            SetCBIndex(m_player.Throw, m_throwEnum, cbThrow);
            SetCBIndex(m_player.Organization, m_organizationEnum, cbOrganization);

            checkPublic.Checked = m_player.Public.Equals("Y", StringComparison.OrdinalIgnoreCase);

            if (m_player.GraduationYear != null)
            {
                numGradYear.Value = (decimal)m_player.GraduationYear;
            }

            txtBRUrl.Text = m_player.BasebaRef;
            txtFGUrl.Text = m_player.Fangraphs;
        }

        private void SetCBIndex(string currentValue, List<string> dataList, ComboBox cb)
        {
            if (currentValue.Length > 0)
            {
                int posID = dataList.FindIndex(s => s == currentValue);
                if (posID < 0)
                {
                    dataList.Add(currentValue);
                    cb.SelectedIndex = dataList.Count - 1;
                }
                else
                {
                    cb.SelectedIndex = posID;
                }
            }
            else
            {
                cb.SelectedIndex = 0;
            }
        }

        private void PlayerData_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            m_context = BaseballModelContext.Instance;

            InitializePlayerData();

        }

        private void cbOrganization_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_player.Organization = cbOrganization.SelectedValue.ToString();
        }

        private void cbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_player.Position = cbPosition.SelectedValue.ToString();
        }

        private void cbThrow_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_player.Throw = cbThrow.SelectedValue.ToString();
        }

        private void cbBat_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_player.Bat = cbBat.SelectedValue.ToString();
        }

        private void numGradYear_ValueChanged(object sender, EventArgs e)
        {
            if (numGradYear.Value < 1990)
            {
                m_player.GraduationYear = null;
            }
            else
            {
                m_player.GraduationYear = (short?)numGradYear.Value;
            }
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            m_player.Firstname = txtFirstName.Text;
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            m_player.Lastname = txtLastName.Text;
        }

        private void dateDOB_ValueChanged(object sender, EventArgs e)
        {
            if (dateDOB.Value.Year > 1970)
            {
                m_player.DOB = dateDOB.Value;
            }
            else
            {
                m_player.DOB = null;
            }
        }

        private void numHeight_ValueChanged(object sender, EventArgs e)
        {
            if (numHeight.Value < 50)
            {
                m_player.Height = null;
            }
            else
            {
                m_player.Height = (byte?)numHeight.Value;
            }
        }

        private void numWeight_ValueChanged(object sender, EventArgs e)
        {
            if (numWeight.Value < 100)
            {
                m_player.Weight = null;
            }
            else
            {
                m_player.Weight = (short)numWeight.Value;
            }
        }

        private void txtBRUrl_TextChanged(object sender, EventArgs e)
        {
            m_player.BasebaRef = txtBRUrl.Text;
        }

        private void txtFGUrl_TextChanged(object sender, EventArgs e)
        {
            m_player.Fangraphs = txtFGUrl.Text;
        }

        private void checkPublic_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPublic.Checked)
            {
                m_player.Public = "Y";
            }
            else
            {
                m_player.Public = "N";
            }
        }
    }
}
