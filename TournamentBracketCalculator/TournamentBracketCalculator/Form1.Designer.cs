namespace TournamentBracketCalculator
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTournamentAttendanceListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTournamentRankingListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playersListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.PlayersPanel = new System.Windows.Forms.Panel();
            this.btn_generate_brackets = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.PlayersPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openTournamentRankingListToolStripMenuItem,
            this.openTournamentAttendanceListToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openTournamentAttendanceListToolStripMenuItem
            // 
            this.openTournamentAttendanceListToolStripMenuItem.Enabled = false;
            this.openTournamentAttendanceListToolStripMenuItem.Name = "openTournamentAttendanceListToolStripMenuItem";
            this.openTournamentAttendanceListToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.openTournamentAttendanceListToolStripMenuItem.Text = "Open Tournament Attendance List";
            this.openTournamentAttendanceListToolStripMenuItem.Click += new System.EventHandler(this.openTournamentAttendanceListToolStripMenuItem_Click);
            // 
            // openTournamentRankingListToolStripMenuItem
            // 
            this.openTournamentRankingListToolStripMenuItem.Name = "openTournamentRankingListToolStripMenuItem";
            this.openTournamentRankingListToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.openTournamentRankingListToolStripMenuItem.Text = "Open Tournament Rankings";
            this.openTournamentRankingListToolStripMenuItem.Click += new System.EventHandler(this.openPlayerRankingListToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playersListToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.aboutToolStripMenuItem.Text = "View";
            // 
            // playersListToolStripMenuItem
            // 
            this.playersListToolStripMenuItem.Name = "playersListToolStripMenuItem";
            this.playersListToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.playersListToolStripMenuItem.Text = "Players List";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem1.Text = "About";
            // 
            // PlayersPanel
            // 
            this.PlayersPanel.Controls.Add(this.btn_generate_brackets);
            this.PlayersPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayersPanel.Location = new System.Drawing.Point(0, 24);
            this.PlayersPanel.Name = "PlayersPanel";
            this.PlayersPanel.Size = new System.Drawing.Size(800, 426);
            this.PlayersPanel.TabIndex = 1;
            this.PlayersPanel.Visible = false;
            this.PlayersPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btn_generate_brackets
            // 
            this.btn_generate_brackets.Location = new System.Drawing.Point(307, 186);
            this.btn_generate_brackets.Name = "btn_generate_brackets";
            this.btn_generate_brackets.Size = new System.Drawing.Size(142, 38);
            this.btn_generate_brackets.TabIndex = 0;
            this.btn_generate_brackets.Text = "Generate Brackets";
            this.btn_generate_brackets.UseVisualStyleBackColor = true;
            this.btn_generate_brackets.Click += new System.EventHandler(this.btn_generate_brackets_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PlayersPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.PlayersPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTournamentAttendanceListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTournamentRankingListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playersListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.Panel PlayersPanel;
        private System.Windows.Forms.Button btn_generate_brackets;
    }
}

