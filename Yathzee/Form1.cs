using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Yahtzee.Combinations;

namespace Yahtzee
{
    public partial class Form1 : Form
    {
        public List<Player> m_Players;
        //public PlayerCard m_CardForm;
        public Form1()
        {
            InitializeComponent();
            m_Players = new List<Player>();
            // m_CardForm = new PlayerCard();
        }

        #region Load Methods
        private void LoadPlayers()
        {
            if (m_Players.Count > 0)
            {
                grdPlayers.Rows.Clear();
                grdPlayers.Columns.Clear();
                int i = 1;
                foreach (Player item in m_Players)
                {
                    grdPlayers.Columns.Add(string.Format("colPlayer{0}", i++), item.Name);
                }

                Dictionary<string, DataGridViewRow> lstRows = LoadGridRows();
                i = 0;
                foreach (Player player in m_Players)
                {
                    for (int j = 0; j < player.UpperSection.Length; j++)
                    {
                        CombinationBase combo = player.UpperSection[j];
                        if (combo.Forfeit)
                            lstRows[combo.Name].Cells[i].Value = "-";
                        else
                            lstRows[combo.Name].Cells[i].Value = combo.Value;
                    }

                    lstRows["Upper Section Total"].Cells[i].Value = player.UpperSectionTotal;

                    for (int j = 0; j < player.LowerSection.Length; j++)
                    {
                        CombinationBase combo = player.LowerSection[j];
                        if (combo.Forfeit)
                            lstRows[combo.Name].Cells[i].Value = "-";
                        else
                            lstRows[combo.Name].Cells[i].Value = combo.Value;
                    }
                    lstRows["Bonus Yahtzee"].Cells[i].Value = player.BonusYahtzeeCount * 100;

                    lstRows["Lower Section Total"].Cells[i].Value = player.UpperSectionTotal;
                    lstRows["Player Total"].Cells[i].Value = player.UpperSectionTotal + player.LowerSectionTotal;
                    i++;
                }
            }
        }

        private Dictionary<string, DataGridViewRow> LoadGridRows()
        {
            Dictionary<string, DataGridViewRow> lstRows = new Dictionary<string, DataGridViewRow>();
            Player temp = new Player("");
            DataGridViewCellStyle styleUpper = new DataGridViewCellStyle() { BackColor = Color.PeachPuff };
            for (int i = 0; i < temp.UpperSection.Length; i++)
            {
                lstRows.Add(temp.UpperSection[i].Name, grdPlayers.Rows[grdPlayers.Rows.Add()]);
                lstRows[temp.UpperSection[i].Name].HeaderCell = new DataGridViewRowHeaderCell() { Value = temp.UpperSection[i].Name, Style = styleUpper };
                lstRows[temp.UpperSection[i].Name].DefaultCellStyle = styleUpper;
            }
            LoadTotalRow(lstRows, "Upper Section Total", new DataGridViewCellStyle() { BackColor = Color.Orange });

            DataGridViewCellStyle styleLower = new DataGridViewCellStyle() { BackColor = Color.LightGreen };

            for (int i = 0; i < temp.LowerSection.Length; i++)
            {
                lstRows.Add(temp.LowerSection[i].Name, grdPlayers.Rows[grdPlayers.Rows.Add()]);
                lstRows[temp.LowerSection[i].Name].HeaderCell = new DataGridViewRowHeaderCell() { Value = temp.LowerSection[i].Name, Style = styleLower };
                lstRows[temp.LowerSection[i].Name].DefaultCellStyle = styleLower;
            }

            lstRows.Add("Bonus Yahtzee", grdPlayers.Rows[grdPlayers.Rows.Add()]);
            lstRows["Bonus Yahtzee"].HeaderCell = new DataGridViewRowHeaderCell() { Value = "Bonus Yahtzee" };
            lstRows["Bonus Yahtzee"].DefaultCellStyle = styleLower;

            LoadTotalRow(lstRows, "Lower Section Total", new DataGridViewCellStyle() { BackColor = Color.MediumSeaGreen });

            LoadTotalRow(lstRows, "Player Total", new DataGridViewCellStyle());
            return lstRows;
        }

        private void LoadNewGameForm()
        {
            List<Player> lstTempPlayers;
            NewGame frmNewGame = new NewGame();

            if (frmNewGame.ShowDialog(out lstTempPlayers) == System.Windows.Forms.DialogResult.OK)
            {
                m_Players = lstTempPlayers;
                LoadPlayers();
            }
        }

        private void LoadTotalRow(Dictionary<string, DataGridViewRow> lstRows, string name, DataGridViewCellStyle style)
        {
            lstRows.Add(name, grdPlayers.Rows[grdPlayers.Rows.Add()]);
            lstRows[name].HeaderCell = new DataGridViewRowHeaderCell() { Value = name, Style = style };
            lstRows[name].ReadOnly = true;
            lstRows[name].DefaultCellStyle = style;
        }
        #endregion

        #region Events
        private void ctrlMenu_NewGame_Click(object sender, EventArgs e)
        {
            LoadNewGameForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_Players = new List<Player>();
        }

        private void grdPlayers_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (m_Players.Count == 0)
            {
                return;
            }
            Player p = m_Players[e.ColumnIndex];

            string name = grdPlayers.Rows[e.RowIndex].HeaderCell.Value.ToString();
            if (grdPlayers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "-")
            {
                if (e.RowIndex < 6)
                    p.ForfeitUpperSectionCombination(name);
                else
                    p.ForfeitLowerSectionCombination(name);
                grdPlayers.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                return;
            }

            if (e.RowIndex < 6)
            {
                int input;
                if (int.TryParse(grdPlayers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out input) == false)
                {
                    MessageBox.Show("Invalid input", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    grdPlayers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;

                    return;
                }
                //uppersection
                AddOnly only;
                for (int i = 0; i < p.UpperSection.Length; i++)
                {
                    if (name.Contains(p.UpperSection[i].Name))
                    {
                        only = p.UpperSection[i] as AddOnly;
                        try
                        {
                            p.SetUpperSectionCombination(only.AddOnlyValue, input);
                            grdPlayers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = only.Value;
                            grdPlayers.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;

                        }
                        catch (CombinationException ex)
                        {
                            if (ex.Message.Contains("forfeit"))
                                grdPlayers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "-";
                            else
                                grdPlayers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                            MessageBox.Show(ex.Message, "Combination Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        break;
                    }
                }
            }
            else
            {
                //lower section
                string[] asInput = grdPlayers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Split(',');
                if (asInput.Length > 0 && asInput[0] == "-")
                {
                    p.ForfeitLowerSectionCombination(name);
                    grdPlayers.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;

                    return;
                }
                int[] aiInput = new int[asInput.Length];
                for (int i = 0; i < asInput.Length; i++)
                {
                    int iTemp;
                    if (int.TryParse(asInput[i], out iTemp) == false)
                    {
                        MessageBox.Show("Invalid input", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        grdPlayers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;

                        return;
                    }
                    aiInput[i] = iTemp;
                }
                try
                {
                    CombinationBase combo = p.SetLowerSectionCombination(name, aiInput);
                    if (combo != null)
                    {
                        if (name == "Bonus Yahtzee")
                        {
                            grdPlayers.Rows[12].Cells[e.ColumnIndex].Value = combo.Value;
                            grdPlayers.Rows[12].Cells[e.ColumnIndex].ReadOnly = true;
                            grdPlayers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                        }
                        else
                        {
                            grdPlayers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = combo.Value;
                            grdPlayers.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                        }
                    }
                    else if (name == "Bonus Yahtzee")
                    {
                        grdPlayers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = p.BonusYahtzeeCount * 100;
                        grdPlayers.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = p.BonusYahtzeeCount >= 3;
                    }
                    // LoadLowerSection();
                    // SetLowerSectionTotal();
                }
                catch (CombinationException ex)
                {
                    if (ex.Message.Contains("forfeit"))
                        grdPlayers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "-";
                    else
                        grdPlayers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                    MessageBox.Show(ex.Message, "Combination Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            SetTotals(p, e.ColumnIndex);
        }

        private void SetTotals(Player p, int columnIndex)
        {
            grdPlayers[columnIndex, 6].Value = p.UpperSectionTotal;
            grdPlayers[columnIndex, 15].Value = p.LowerSectionTotal;
            grdPlayers[columnIndex, 16].Value = p.UpperSectionTotal + p.LowerSectionTotal;

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            LoadNewGameForm();
        }
        #endregion

        private void clearScoreBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < m_Players.Count; i++)
            {
                m_Players[i] = new Player(m_Players[i].Name);
            }

            LoadPlayers();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About abt = new About();
            abt.ShowDialog();
        }

        private void combinationInputsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help h = new Help();
            h.Show();
        }

        #region Grid Input & Scoring
        #endregion
    }
}
