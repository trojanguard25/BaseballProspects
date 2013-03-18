using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;

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

            // need to store the values for combo-boxes or else they will be overridden when the DataSource is set
            string bat = m_player.Bat;
            string pos = m_player.Position;
            string thr = m_player.Throw;
            string org = m_player.Organization;

            cbBat.DataSource = m_batEnum;
            cbPosition.DataSource = m_positionEnum;
            cbThrow.DataSource = m_throwEnum;
            cbOrganization.DataSource = m_organizationEnum;

            SetCBIndex(bat, m_batEnum, cbBat);
            SetCBIndex(pos, m_positionEnum, cbPosition);
            SetCBIndex(thr, m_throwEnum, cbThrow);
            SetCBIndex(org, m_organizationEnum, cbOrganization);

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
            if (currentValue != null && currentValue.Length > 0)
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

        private void numHeight_Enter(object sender, EventArgs e)
        {
            numHeight.Select(0, numHeight.Text.Length);
        }

        private void numWeight_Enter(object sender, EventArgs e)
        {
            numWeight.Select(0, numWeight.Text.Length);
        }

        private void btnFindUrls_Click(object sender, EventArgs e)
        {
            // open web browser on player's baseball reference page
            if (m_player.BasebaRef == null || m_player.BasebaRef.Length == 0)
            {
                string baseballReferenceSearchUrl = "http://www.baseball-reference.com/pl/player_search.cgi?search=" + m_player.Firstname + "+" + m_player.Lastname;
                System.Diagnostics.Process.Start(baseballReferenceSearchUrl);
            }
            else
            {
                System.Diagnostics.Process.Start(m_player.BasebaRef);
            }
        }

        private void btnParseFG_Click(object sender, EventArgs e)
        {
            if (m_player.Fangraphs != null)
            {
                HtmlAgilityPack.HtmlWeb hw = new HtmlAgilityPack.HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = hw.Load(m_player.Fangraphs);

                HtmlAgilityPack.HtmlNodeCollection divs = doc.DocumentNode.SelectNodes("//div[@id='content']");

                if (divs != null)
                {
                    HtmlConvert htt = new HtmlConvert();

                    StringWriter sw = new StringWriter();
                    htt.ConvertTo(divs.First(), sw);
                    sw.Flush();

                    string s = sw.ToString();

                    Regex re = new Regex(@"(^.+\w)\s*Birthdate:\s+(\S+)\s+Bats/Throws:\s+(\S+)\s+Height/Weight:\s+(\S+)\s+Position:\s+(\S+)Contract:", RegexOptions.Compiled);

                    GroupCollection groups = re.Match(s).Groups;
                    if (groups.Count == 6)
                    {
                        // get name
                        string name = groups[1].Captures[0].Value;
                        Regex reName = new Regex(@"(^\w+)\s+(\S+)$", RegexOptions.Compiled);
                        GroupCollection nameGroups = reName.Match(name).Groups;
                        if (nameGroups.Count == 3)
                        {
                            string firstName = nameGroups[1].Captures[0].Value;
                            string lastName = nameGroups[2].Captures[0].Value;
                            txtFirstName.Text = firstName;
                            txtLastName.Text = lastName;
                        }

                        // get birthdate
                        string birthdate = groups[2].Captures[0].Value;
                        DateTimeConverter date = new DateTimeConverter();
                        DateTime birthDataTime = (DateTime)date.ConvertFromString(birthdate);
                        dateDOB.Value = birthDataTime;

                        // get batting and throwing
                        string batsThrows = groups[3].Captures[0].Value;
                        Regex reBT = new Regex(@"(\w)/(\w)", RegexOptions.Compiled);
                        GroupCollection btGroups = reBT.Match(batsThrows).Groups;
                        if (btGroups.Count == 3)
                        {
                            string bats = btGroups[1].Captures[0].Value;
                            string throws = btGroups[2].Captures[0].Value;
                            SetCBIndex(bats, m_batEnum, cbBat);
                            SetCBIndex(throws, m_throwEnum, cbThrow);
                        }

                        // get height and weight
                        string heightWeight = groups[4].Captures[0].Value;
                        Regex reHW = new Regex(@"(\w+)-(\w+)/(\w+)", RegexOptions.Compiled);
                        GroupCollection hwGroups = reHW.Match(heightWeight).Groups;
                        if (hwGroups.Count == 4)
                        {
                            int heightFt = Convert.ToInt32(hwGroups[1].Captures[0].Value);
                            int heightInch = Convert.ToInt32(hwGroups[2].Captures[0].Value);
                            int weight = Convert.ToInt32(hwGroups[3].Captures[0].Value);

                            numHeight.Value = heightFt * 12 + heightInch;
                            numWeight.Value = weight;
                        }

                        // get position
                        string position = groups[5].Captures[0].Value;
                        Regex rePos = new Regex(@"(\w+)/");
                        GroupCollection posGroups = rePos.Match(position).Groups;
                        if (posGroups.Count > 1)
                        {
                            SetCBIndex(posGroups[1].Captures[0].Value, m_positionEnum, cbPosition);
                        }
                        else
                        {
                            if (position == "P")
                            {
                                position = "SP";
                            }
                            SetCBIndex(position, m_positionEnum, cbPosition);
                        }
                    }
                }
            }
        }

        public void UpdateFGUrl(string url)
        {
            txtFGUrl.Text = url;
        }
    }
}
