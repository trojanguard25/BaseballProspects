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
        Player m_player;
        List<string> m_positionEnum;
        List<string> m_throwEnum;
        List<string> m_batEnum;
        List<string> m_publicEnum;

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

        private void InitializeEnums()
        {
            m_positionEnum = new List<string>();
            m_positionEnum.Add("SP");
            m_positionEnum.Add("RP");
            m_positionEnum.Add("C");
            m_positionEnum.Add("1B");
            m_positionEnum.Add("2B");
            m_positionEnum.Add("3B");
            m_positionEnum.Add("SS");
            m_positionEnum.Add("IF");
            m_positionEnum.Add("CF");
            m_positionEnum.Add("OF");
            m_positionEnum.Add("DH");

            m_batEnum = new List<string>();
            m_batEnum.Add("R");
            m_batEnum.Add("L");
            m_batEnum.Add("S");

            m_throwEnum = new List<string>();
            m_throwEnum.Add("R");
            m_throwEnum.Add("L");

            m_publicEnum = new List<string>();
            m_publicEnum.Add("Y");
            m_publicEnum.Add("N");
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

            cbBat.DataSource = m_batEnum;
            cbPosition.DataSource = m_positionEnum;
            cbThrow.DataSource = m_throwEnum;
            

        }
    }
}
