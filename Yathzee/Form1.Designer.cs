namespace Yahtzee
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.grdPlayers = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ctrlMenu_NewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.clearScoreBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.combinationInputsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdPlayers)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdPlayers
            // 
            this.grdPlayers.AllowUserToAddRows = false;
            this.grdPlayers.AllowUserToDeleteRows = false;
            this.grdPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPlayers.Location = new System.Drawing.Point(12, 39);
            this.grdPlayers.Name = "grdPlayers";
            this.grdPlayers.RowHeadersWidth = 150;
            this.grdPlayers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grdPlayers.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPlayers.Size = new System.Drawing.Size(595, 397);
            this.grdPlayers.TabIndex = 1;
            this.grdPlayers.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPlayers_CellEndEdit);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctrlMenu_NewGame,
            this.clearScoreBoardToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(619, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ctrlMenu_NewGame
            // 
            this.ctrlMenu_NewGame.Name = "ctrlMenu_NewGame";
            this.ctrlMenu_NewGame.Size = new System.Drawing.Size(77, 20);
            this.ctrlMenu_NewGame.Text = "New Game";
            this.ctrlMenu_NewGame.Click += new System.EventHandler(this.ctrlMenu_NewGame_Click);
            // 
            // clearScoreBoardToolStripMenuItem
            // 
            this.clearScoreBoardToolStripMenuItem.Name = "clearScoreBoardToolStripMenuItem";
            this.clearScoreBoardToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.clearScoreBoardToolStripMenuItem.Text = "Clear Score Board";
            this.clearScoreBoardToolStripMenuItem.Click += new System.EventHandler(this.clearScoreBoardToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.combinationInputsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // combinationInputsToolStripMenuItem
            // 
            this.combinationInputsToolStripMenuItem.Name = "combinationInputsToolStripMenuItem";
            this.combinationInputsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.combinationInputsToolStripMenuItem.Text = "Combination Inputs";
            this.combinationInputsToolStripMenuItem.Click += new System.EventHandler(this.combinationInputsToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 450);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.grdPlayers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yahtzee!!";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.grdPlayers)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdPlayers;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ctrlMenu_NewGame;
        private System.Windows.Forms.ToolStripMenuItem clearScoreBoardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem combinationInputsToolStripMenuItem;
    }
}

