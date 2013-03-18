namespace ProspectRankingDBTool
{
    partial class ProspectDataEntryTool
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnViewData = new System.Windows.Forms.Button();
            this.btnNewPlayerList = new System.Windows.Forms.Button();
            this.btnParseFGtop15 = new System.Windows.Forms.Button();
            this.txtFGUrl = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnViewData
            // 
            this.btnViewData.Location = new System.Drawing.Point(12, 32);
            this.btnViewData.Name = "btnViewData";
            this.btnViewData.Size = new System.Drawing.Size(102, 23);
            this.btnViewData.TabIndex = 0;
            this.btnViewData.Text = "Add New Player";
            this.btnViewData.UseVisualStyleBackColor = true;
            this.btnViewData.Click += new System.EventHandler(this.btnViewData_Click);
            // 
            // btnNewPlayerList
            // 
            this.btnNewPlayerList.Location = new System.Drawing.Point(12, 61);
            this.btnNewPlayerList.Name = "btnNewPlayerList";
            this.btnNewPlayerList.Size = new System.Drawing.Size(102, 23);
            this.btnNewPlayerList.TabIndex = 1;
            this.btnNewPlayerList.Text = "New Player List";
            this.btnNewPlayerList.UseVisualStyleBackColor = true;
            this.btnNewPlayerList.Click += new System.EventHandler(this.btnNewPlayerList_Click);
            // 
            // btnParseFGtop15
            // 
            this.btnParseFGtop15.Location = new System.Drawing.Point(13, 3);
            this.btnParseFGtop15.Name = "btnParseFGtop15";
            this.btnParseFGtop15.Size = new System.Drawing.Size(101, 23);
            this.btnParseFGtop15.TabIndex = 2;
            this.btnParseFGtop15.Text = "Parse FG top-15";
            this.btnParseFGtop15.UseVisualStyleBackColor = true;
            this.btnParseFGtop15.Click += new System.EventHandler(this.btnParseFGtop15_Click);
            // 
            // txtFGUrl
            // 
            this.txtFGUrl.Location = new System.Drawing.Point(121, 5);
            this.txtFGUrl.Name = "txtFGUrl";
            this.txtFGUrl.Size = new System.Drawing.Size(346, 20);
            this.txtFGUrl.TabIndex = 3;
            // 
            // ProspectDataEntryTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 92);
            this.Controls.Add(this.txtFGUrl);
            this.Controls.Add(this.btnParseFGtop15);
            this.Controls.Add(this.btnNewPlayerList);
            this.Controls.Add(this.btnViewData);
            this.Name = "ProspectDataEntryTool";
            this.Text = "Prospect Data Entry Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnViewData;
        private System.Windows.Forms.Button btnNewPlayerList;
        private System.Windows.Forms.Button btnParseFGtop15;
        private System.Windows.Forms.TextBox txtFGUrl;


    }
}

