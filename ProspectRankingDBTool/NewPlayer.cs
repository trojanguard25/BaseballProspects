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
    public partial class NewPlayer : Form
    {
        public NewPlayer()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BaseballModelContext.Instance.DBContext.Players.AddObject(playerData1.PlayerEntity);
            BaseballModelContext.Instance.DBContext.SaveChanges();
        }
    }
}
