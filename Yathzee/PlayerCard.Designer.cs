namespace Yathzee
{
    partial class PlayerCard
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
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.grdUpperSection = new System.Windows.Forms.DataGridView();
            this.grdLowerSection = new System.Windows.Forms.DataGridView();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblUserTotal = new System.Windows.Forms.Label();
            this.colCombination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdUpperSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLowerSection)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.Location = new System.Drawing.Point(12, 9);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(67, 13);
            this.lblPlayerName.TabIndex = 0;
            this.lblPlayerName.Text = "Player Name";
            // 
            // grdUpperSection
            // 
            this.grdUpperSection.AllowUserToAddRows = false;
            this.grdUpperSection.AllowUserToDeleteRows = false;
            this.grdUpperSection.AllowUserToResizeColumns = false;
            this.grdUpperSection.AllowUserToResizeRows = false;
            this.grdUpperSection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdUpperSection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUpperSection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCombination,
            this.colInput});
            this.grdUpperSection.Location = new System.Drawing.Point(12, 34);
            this.grdUpperSection.MaximumSize = new System.Drawing.Size(206, 500);
            this.grdUpperSection.MinimumSize = new System.Drawing.Size(206, 154);
            this.grdUpperSection.Name = "grdUpperSection";
            this.grdUpperSection.RowHeadersVisible = false;
            this.grdUpperSection.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.grdUpperSection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdUpperSection.Size = new System.Drawing.Size(206, 178);
            this.grdUpperSection.TabIndex = 1;
            this.grdUpperSection.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdUpperSection_CellEndEdit);
            // 
            // grdLowerSection
            // 
            this.grdLowerSection.AllowUserToAddRows = false;
            this.grdLowerSection.AllowUserToDeleteRows = false;
            this.grdLowerSection.AllowUserToResizeColumns = false;
            this.grdLowerSection.AllowUserToResizeRows = false;
            this.grdLowerSection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grdLowerSection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLowerSection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.grdLowerSection.Location = new System.Drawing.Point(12, 228);
            this.grdLowerSection.Name = "grdLowerSection";
            this.grdLowerSection.RowHeadersVisible = false;
            this.grdLowerSection.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.grdLowerSection.Size = new System.Drawing.Size(205, 222);
            this.grdLowerSection.TabIndex = 2;
            this.grdLowerSection.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdLowerSection_CellEndEdit);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOk.Location = new System.Drawing.Point(75, 480);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblUserTotal
            // 
            this.lblUserTotal.AutoSize = true;
            this.lblUserTotal.Location = new System.Drawing.Point(12, 461);
            this.lblUserTotal.Name = "lblUserTotal";
            this.lblUserTotal.Size = new System.Drawing.Size(56, 13);
            this.lblUserTotal.TabIndex = 4;
            this.lblUserTotal.Text = "User Total";
            // 
            // colCombination
            // 
            this.colCombination.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCombination.HeaderText = "Combination";
            this.colCombination.Name = "colCombination";
            this.colCombination.ReadOnly = true;
            this.colCombination.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCombination.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colInput
            // 
            this.colInput.HeaderText = "Value";
            this.colInput.Name = "colInput";
            this.colInput.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colInput.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colInput.Width = 75;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Combination";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Value";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 75;
            // 
            // PlayerCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 515);
            this.Controls.Add(this.lblUserTotal);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.grdLowerSection);
            this.Controls.Add(this.grdUpperSection);
            this.Controls.Add(this.lblPlayerName);
            this.Name = "PlayerCard";
            this.Text = "PlayerCard";
            ((System.ComponentModel.ISupportInitialize)(this.grdUpperSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLowerSection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.DataGridView grdUpperSection;
        private System.Windows.Forms.DataGridView grdLowerSection;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblUserTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCombination;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInput;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}