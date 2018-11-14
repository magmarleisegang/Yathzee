using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Yahtzee
{
    public partial class NewGame : Form
    {
        private List<Player> m_lstNewPlayers;
        public NewGame()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            m_lstNewPlayers = new List<Player>();
            if (grdNames.Rows.Count < 2)
            {
                MessageBox.Show("Must enter at least 2 names", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (DataGridViewRow item in grdNames.Rows)
            {
                if (item.Index < grdNames.Rows.Count - 1)
                    m_lstNewPlayers.Add(new Player(item.Cells[0].Value.ToString()));
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public DialogResult ShowDialog(out List<Player> players)
        {
            if (this.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                players = m_lstNewPlayers;
                return System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                players = null;
                return this.DialogResult;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
