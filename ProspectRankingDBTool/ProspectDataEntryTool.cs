using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProspectRankingDBTool
{
    public partial class ProspectDataEntryTool : Form
    {
        public ProspectDataEntryTool()
        {
            InitializeComponent();
        }

        private void btnNewPlayerList_Click(object sender, EventArgs e)
        {
            NewPlayerList form = new NewPlayerList();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
            }
        }

        private void btnViewData_Click(object sender, EventArgs e)
        {
            NewPlayer form = new NewPlayer();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
            }
        }

        private void btnParseFGtop15_Click(object sender, EventArgs e)
        {
            string org = null;
            if (txtFGUrl.TextLength > 0)
            {
                HtmlAgilityPack.HtmlWeb hw = new HtmlAgilityPack.HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = hw.Load(txtFGUrl.Text);

                HtmlAgilityPack.HtmlNode titleNode = doc.DocumentNode.SelectSingleNode("html/head/title");
                if (titleNode != null)
                {
                    string title = titleNode.InnerText;

                    org = BaseballModelContext.ParseForOrganization(title);
                }

                HtmlAgilityPack.HtmlNodeCollection divs = doc.DocumentNode.SelectNodes("//div[@id='blogcontent']");

                if (divs != null)
                {
                    HtmlAgilityPack.HtmlNode node = divs[0];

                    HtmlAgilityPack.HtmlNodeCollection links = node.SelectNodes("//a[@href]");
                    if (links != null)
                    {
                        foreach (HtmlAgilityPack.HtmlNode link in links)
                        {
                            HtmlAgilityPack.HtmlAttribute att = link.Attributes["href"];
                            if (att != null)
                            {
                                if (att.Value.StartsWith("http://www.fangraphs.com/statss.aspx?playerid=", StringComparison.OrdinalIgnoreCase))
                                {
                                    string myUrl = att.Value;
                                    NewPlayer form = new NewPlayer(myUrl, org);
                                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                    {
                                    }
                                }
                            }
                        }
                    }
                }
                txtFGUrl.Text = "";
            }
        }
    }
}
