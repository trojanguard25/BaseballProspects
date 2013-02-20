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
        List<string> testList = new List<string>();

        public ProspectDataEntryTool()
        {
            InitializeComponent();
            prospectdbEntities context = new prospectdbEntities();
            var query = from it in context.Organizations
                        orderby it.Abbr
                        select it;

            foreach (Organization org in query)
                testList.Add(org.Abbr);

            listBox1.DataSource = testList;
        }
    }
}
