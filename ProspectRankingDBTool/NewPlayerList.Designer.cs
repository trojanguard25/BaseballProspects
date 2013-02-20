namespace ProspectRankingDBTool
{
    partial class NewPlayerList
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDone = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.rbPreSeason = new System.Windows.Forms.RadioButton();
            this.rbInSeason = new System.Windows.Forms.RadioButton();
            this.cbOrganization = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPosition = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numRankings = new System.Windows.Forms.NumericUpDown();
            this.cbPublic = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.urlInfo1 = new ProspectRankingDBTool.UrlInfo();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.playerRank1 = new ProspectRankingDBTool.PlayerRank();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRankings)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbPublic);
            this.groupBox1.Controls.Add(this.numRankings);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbPosition);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbOrganization);
            this.groupBox1.Controls.Add(this.rbInSeason);
            this.groupBox1.Controls.Add(this.rbPreSeason);
            this.groupBox1.Controls.Add(this.numYear);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 166);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(695, 269);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Player Ranking List";
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(632, 441);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 2;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "YEAR:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ORGANIZATION:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numYear
            // 
            this.numYear.Location = new System.Drawing.Point(51, 38);
            this.numYear.Maximum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.numYear.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(47, 20);
            this.numYear.TabIndex = 4;
            this.numYear.Value = new decimal(new int[] {
            2013,
            0,
            0,
            0});
            // 
            // rbPreSeason
            // 
            this.rbPreSeason.AutoSize = true;
            this.rbPreSeason.Location = new System.Drawing.Point(105, 40);
            this.rbPreSeason.Name = "rbPreSeason";
            this.rbPreSeason.Size = new System.Drawing.Size(41, 17);
            this.rbPreSeason.TabIndex = 5;
            this.rbPreSeason.TabStop = true;
            this.rbPreSeason.Text = "Pre";
            this.rbPreSeason.UseVisualStyleBackColor = true;
            // 
            // rbInSeason
            // 
            this.rbInSeason.AutoSize = true;
            this.rbInSeason.Location = new System.Drawing.Point(152, 40);
            this.rbInSeason.Name = "rbInSeason";
            this.rbInSeason.Size = new System.Drawing.Size(34, 17);
            this.rbInSeason.TabIndex = 6;
            this.rbInSeason.TabStop = true;
            this.rbInSeason.Text = "In";
            this.rbInSeason.UseVisualStyleBackColor = true;
            // 
            // cbOrganization
            // 
            this.cbOrganization.FormattingEnabled = true;
            this.cbOrganization.Location = new System.Drawing.Point(104, 76);
            this.cbOrganization.Name = "cbOrganization";
            this.cbOrganization.Size = new System.Drawing.Size(82, 21);
            this.cbOrganization.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "POSITION:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbPosition
            // 
            this.cbPosition.FormattingEnabled = true;
            this.cbPosition.Location = new System.Drawing.Point(104, 117);
            this.cbPosition.Name = "cbPosition";
            this.cbPosition.Size = new System.Drawing.Size(82, 21);
            this.cbPosition.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "NUMBER:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numRankings
            // 
            this.numRankings.Location = new System.Drawing.Point(104, 159);
            this.numRankings.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numRankings.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRankings.Name = "numRankings";
            this.numRankings.Size = new System.Drawing.Size(47, 20);
            this.numRankings.TabIndex = 11;
            this.numRankings.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // cbPublic
            // 
            this.cbPublic.AutoSize = true;
            this.cbPublic.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbPublic.Location = new System.Drawing.Point(51, 199);
            this.cbPublic.Name = "cbPublic";
            this.cbPublic.Size = new System.Drawing.Size(67, 17);
            this.cbPublic.TabIndex = 12;
            this.cbPublic.Text = "PUBLIC:";
            this.cbPublic.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(77, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "ID:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(104, 230);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(68, 20);
            this.txtID.TabIndex = 14;
            // 
            // urlInfo1
            // 
            this.urlInfo1.Location = new System.Drawing.Point(12, 12);
            this.urlInfo1.Name = "urlInfo1";
            this.urlInfo1.Size = new System.Drawing.Size(705, 133);
            this.urlInfo1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.hScrollBar1);
            this.groupBox2.Controls.Add(this.playerRank1);
            this.groupBox2.Location = new System.Drawing.Point(340, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(349, 241);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Player Rank";
            // 
            // playerRank1
            // 
            this.playerRank1.Location = new System.Drawing.Point(5, 18);
            this.playerRank1.Name = "playerRank1";
            this.playerRank1.Size = new System.Drawing.Size(338, 173);
            this.playerRank1.TabIndex = 0;
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(7, 210);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(336, 17);
            this.hScrollBar1.TabIndex = 1;
            // 
            // NewPlayerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 471);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.urlInfo1);
            this.Name = "NewPlayerList";
            this.Text = "Player List...";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRankings)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UrlInfo urlInfo1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbPublic;
        private System.Windows.Forms.NumericUpDown numRankings;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbPosition;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbOrganization;
        private System.Windows.Forms.RadioButton rbInSeason;
        private System.Windows.Forms.RadioButton rbPreSeason;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private PlayerRank playerRank1;
    }
}