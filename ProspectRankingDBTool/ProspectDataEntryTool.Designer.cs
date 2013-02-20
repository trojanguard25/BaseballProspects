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
            this.SuspendLayout();
            // 
            // btnViewData
            // 
            this.btnViewData.Location = new System.Drawing.Point(13, 61);
            this.btnViewData.Name = "btnViewData";
            this.btnViewData.Size = new System.Drawing.Size(75, 23);
            this.btnViewData.TabIndex = 0;
            this.btnViewData.Text = "View Data";
            this.btnViewData.UseVisualStyleBackColor = true;
            // 
            // btnNewPlayerList
            // 
            this.btnNewPlayerList.Location = new System.Drawing.Point(298, 61);
            this.btnNewPlayerList.Name = "btnNewPlayerList";
            this.btnNewPlayerList.Size = new System.Drawing.Size(75, 23);
            this.btnNewPlayerList.TabIndex = 1;
            this.btnNewPlayerList.Text = "New Player List";
            this.btnNewPlayerList.UseVisualStyleBackColor = true;
            this.btnNewPlayerList.Click += new System.EventHandler(this.btnNewPlayerList_Click);
            // 
            // ProspectDataEntryTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 96);
            this.Controls.Add(this.btnNewPlayerList);
            this.Controls.Add(this.btnViewData);
            this.Name = "ProspectDataEntryTool";
            this.Text = "Prospect Data Entry Tool";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnViewData;
        private System.Windows.Forms.Button btnNewPlayerList;


    }
}

