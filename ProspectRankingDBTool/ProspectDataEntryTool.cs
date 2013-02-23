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

        }

        private void btnViewData_Click(object sender, EventArgs e)
        {
            NewPlayer form = new NewPlayer();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
            }
        }
    }
}
