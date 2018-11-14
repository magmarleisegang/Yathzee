using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Yathzee.Combinations;

namespace Yathzee
{
    public partial class PlayerCard : Form
    {
        private Player m_Player;

        public PlayerCard()
        {
            InitializeComponent();
        }

        public void ShowCard(Player player)
        {
            m_Player = player;
            lblPlayerName.Text = m_Player.Name;
            LoadUpperSection();
            LoadLowerSection();
            lblUserTotal.Text = string.Format("{0}'s Total: {1}", m_Player.Name, (m_Player.UpperSectionTotal + m_Player.LowerSectionTotal));
            this.Show();
        }

        private void LoadUpperSection()
        {
            CombinationBase[] combos = m_Player.UpperSection;
           // DataGridViewRow template = grdUpperSection.RowTemplate;
            grdUpperSection.Rows.Clear();
            for (int i = 0; i < combos.Length; i++)
            {
                int newIndex = grdUpperSection.Rows.Add();
                DataGridViewRow row = grdUpperSection.Rows[newIndex];
                AddOnly only = combos[i] as AddOnly;
                row.Cells[0].Value = string.Format("{0} ({1}):", only.Name, only.Input);
                if (combos[i].Forfeit)
                    row.Cells[1].Value = "-";
                else
                    row.Cells[1].Value = combos[i].Value;
                row.Cells[1].ReadOnly = !only.Open;
            }

            int footerRowIndex = grdUpperSection.Rows.Add();
            DataGridViewRow footerRow = grdUpperSection.Rows[footerRowIndex];
            footerRow.ReadOnly = true;
            footerRow.Cells[0].Value = "Sub Total (63 + 35):";
            footerRow.Cells[1].Value = m_Player.UpperSectionTotal + (m_Player.UpperSectionBonus ? 35 : 0);
        }

        private void LoadLowerSection()
        {
            CombinationBase[] combos = m_Player.LowerSection;

            grdLowerSection.Rows.Clear();
            for (int i = 0; i < combos.Length; i++)
            {
                int newIndex = grdLowerSection.Rows.Add();
                DataGridViewRow row = grdLowerSection.Rows[newIndex];
                row.Cells[0].Value = combos[i].Name;
                if (combos[i].Forfeit)
                    row.Cells[1].Value = "-";
                else row.Cells[1].Value = combos[i].Value;
            }

            int YathzeeRowIndex = grdLowerSection.Rows.Add();
            DataGridViewRow bonusYathzeeRow = grdLowerSection.Rows[YathzeeRowIndex];

            bonusYathzeeRow.Cells[0].Value = string.Format("Bonus Yathzee ({0}/3):", m_Player.BonusYathzeeCount);
            bonusYathzeeRow.Cells[1].Value = m_Player.BonusYathzeeCount * 100;

            int footerRowIndex = grdLowerSection.Rows.Add();
            DataGridViewRow footerRow = grdLowerSection.Rows[footerRowIndex];
            footerRow.ReadOnly = true;
            footerRow.Cells[0].Value = "Sub Total:";
            footerRow.Cells[1].Value = m_Player.LowerSectionTotal;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void grdUpperSection_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
                return;
            if (e.RowIndex == grdUpperSection.Rows.Count - 1)
                return;
            string name = grdUpperSection.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (grdUpperSection.Rows[e.RowIndex].Cells[1].Value.ToString() == "-")
            {
                m_Player.ForfeitUpperSectionCombination(name);
                return;
            }

            int input;
            if (int.TryParse(grdUpperSection.Rows[e.RowIndex].Cells[1].Value.ToString(), out input) == false)
            {
                MessageBox.Show("Invalid input", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            CombinationBase[] combos = m_Player.UpperSection;
            AddOnly only;
            for (int i = 0; i < combos.Length; i++)
            {
                if (name.Contains(combos[i].Name))
                {
                    only = combos[i] as AddOnly;
                    try
                    {
                        m_Player.SetUpperSectionCombination(only.AddOnlyValue, input);
                        grdUpperSection.Rows[e.RowIndex].Cells[1].Value = only.Value;
                        grdUpperSection.Rows[e.RowIndex].Cells[0].Value = string.Format("{0} ({1}):", only.Name, only.Input);
                    }
                    catch (CombinationException ex)
                    {
                        if (ex.Message.Contains("forfeit"))
                            grdUpperSection.Rows[e.RowIndex].Cells[1].Value = "-";
                        else
                            grdUpperSection.Rows[e.RowIndex].Cells[1].Value = 0;
                        MessageBox.Show(ex.Message, "Combination Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;
                }
            }

            SetUpperSectionTotal();
        }

        private void SetUpperSectionTotal()
        {
            DataGridViewRow footerRow = grdUpperSection.Rows[grdUpperSection.Rows.Count - 1];
            footerRow.ReadOnly = true;
            footerRow.Cells[0].Value = "Sub Total (63 + 35):";
            footerRow.Cells[1].Value = m_Player.UpperSectionTotal + (m_Player.UpperSectionBonus ? 35 : 0);
        }

        private void grdLowerSection_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
                return;
            if (e.RowIndex == grdLowerSection.Rows.Count - 1)
                return;
            string name = grdLowerSection.Rows[e.RowIndex].Cells[0].Value.ToString();
            string[] asInput = grdLowerSection.Rows[e.RowIndex].Cells[1].Value.ToString().Split(',');
            if (asInput.Length > 0 && asInput[0] == "-")
            {
                m_Player.ForfeitLowerSectionCombination(name);
                return;
            }
            int[] aiInput = new int[asInput.Length];
            for (int i = 0; i < asInput.Length; i++)
            {
                int iTemp;
                if (int.TryParse(asInput[i], out iTemp) == false)
                {
                    MessageBox.Show("Invalid input", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                aiInput[i] = iTemp;
            }
            try
            {
                m_Player.SetLowerSectionCombination(name, aiInput);
                LoadLowerSection();
                // SetLowerSectionTotal();
            }
            catch (CombinationException ex)
            {
                if (ex.Message.Contains("forfeit"))
                    grdLowerSection.Rows[e.RowIndex].Cells[1].Value = "-";
                else
                    grdLowerSection.Rows[e.RowIndex].Cells[1].Value = 0;
                MessageBox.Show(ex.Message, "Combination Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void SetLowerSectionTotal()
        {
            DataGridViewRow footerRow = grdLowerSection.Rows[grdLowerSection.Rows.Count - 1];
            footerRow.ReadOnly = true;
            footerRow.Cells[0].Value = "Sub Total (63 + 35):";
            footerRow.Cells[1].Value = m_Player.LowerSectionTotal;
        }


    }
}
