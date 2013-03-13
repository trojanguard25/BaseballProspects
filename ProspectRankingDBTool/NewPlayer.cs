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
            try
            {
                BaseballModelContext.Instance.DBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                if (ex.InnerException != null)
                {
                    errorMsg += " " + ex.InnerException.Message;
                }
                MessageBox.Show("Unable to save. Please update the form: " + errorMsg);
                this.DialogResult = System.Windows.Forms.DialogResult.None;
            }
        }
    }
}
