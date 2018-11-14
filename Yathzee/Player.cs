using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yahtzee.Combinations;

namespace Yahtzee
{
    public class Player
    {
        public CombinationBase[] UpperSection;
        public CombinationBase[] LowerSection;
        public string Name;
        private int m_iUpperSectionTotal;
        public int UpperSectionTotal  { get { return m_iUpperSectionTotal + (UpperSectionBonus ? 35 : 0); } }
        public bool UpperSectionBonus;
        public int BonusYahtzeeCount;
       // public int LowerSectionTotal { get { return m_iLowerSectionTotal + (UpperSectionBonus ? 35 : 0); } }
        public int LowerSectionTotal;

        public Player(string name)
        {
            Name = name;
            LoadUpperSection();
            LoadLowerSection();
        }

        private void LoadUpperSection()
        {
            UpperSection = new CombinationBase[6];
            for (int i = 0; i < 6; i++)
            {
                UpperSection[i] = new AddOnly(i + 1);
            }
        }

        private void LoadLowerSection()
        {
            /*
             * Three kind 3*value + summation,
             * Four kind 4*value + summation,
             * full house 25,
             * long straight 40,
             * short straight 30,
             * Yahtzee 50,
             * Chance summation,
             */

            LowerSection = new CombinationBase[7];
            LowerSection[0] = new CombinationBase("Three of a Kind", CombinationTypeEnum.Formula);
            LowerSection[1] = new CombinationBase("Four of a Kind", CombinationTypeEnum.Formula);
            LowerSection[2] = new SetValue("Full House", 25);
            LowerSection[3] = new SetValue("Short Straight", 30);
            LowerSection[4] = new SetValue("Long Straight", 40);
            LowerSection[5] = new SetValue("Yahtzee", 50);
            LowerSection[6] = new CombinationBase("Chance", CombinationTypeEnum.Summation);
        }

        public void SetUpperSectionCombination(int kind, int count)
        {
            for (int i = 0; i < 6; i++)
            {
                AddOnly me = UpperSection[i] as AddOnly;
                if (me.AddOnlyValue == kind)
                {
                    if (me.Open == true)
                    {
                        UpperSection[i].CalculateValue(count);
                        m_iUpperSectionTotal += UpperSection[i].Value;
                        UpperSectionBonus = (m_iUpperSectionTotal >= 63);
                    }
                    if (me.Forfeit == true)
                        throw new CombinationException("You have already forfeited this combination.");
                    break;
                }
            }
        }

        internal CombinationBase SetLowerSectionCombination(string name, int[] aiInput)
        {
            if (name.StartsWith("Bonus Yahtzee") && LowerSection[5].Open == false && BonusYahtzeeCount < 3)
            {
                BonusYahtzeeCount += 1;
                LowerSectionTotal += 100;
                return null;
            }
            else if (name.StartsWith("Bonus Yahtzee") && LowerSection[5].Open)
            {
                name = "Yahtzee";
            }

            for (int i = 0; i < LowerSection.Length; i++)
            {
                if (name.StartsWith(LowerSection[i].Name))
                {
                    if (name == "Three of a Kind")
                    {
                        if (aiInput.Length < 3)
                            throw new CombinationException("Three of a Kind combination requires at least 3 numbers.");
                        
                        int kind = aiInput[0];
                        int[] aiExtra = new int[2];
                        Array.Copy(aiInput, 1, aiExtra, 0, 2);
                        LowerSection[i].CalculateValue(new CombinationFormulas.ThreeKind(kind, aiExtra));
                        LowerSection[i].Name = string.Format("{0} ({1},{2},{3})", LowerSection[i].Name, kind, aiExtra[0], aiExtra[1]);
                    }
                    else if (name == "Four of a Kind")
                    {
                        if (aiInput.Length < 2)
                            throw new CombinationException("Four of a Kind combination requires at least 2 numbers.");
                        LowerSection[i].CalculateValue(new CombinationFormulas.FourKind(aiInput[0], aiInput[1]));
                        LowerSection[i].Name = string.Format("{0} ({1},{2})", LowerSection[i].Name, aiInput[0], aiInput[1]);
                    }
                    else if (name == "Chance")
                    {
                        if (aiInput.Length != 5)
                            throw new CombinationException("Chance combination requires 5 numbers.");
                        LowerSection[i].CalculateValue(new CombinationFormulas.Chance(aiInput));
                    }
                    else
                    {
                        LowerSection[i].CalculateValue(aiInput);
                    }

                    LowerSectionTotal += LowerSection[i].Value;
                    return LowerSection[i];
                    //break;
                }
            }
            return null;
        }

        public void ForfeitUpperSectionCombination(int kind)
        {
            for (int i = 0; i < 6; i++)
            {
                AddOnly me = UpperSection[i] as AddOnly;
                if (me.AddOnlyValue == kind && me.Open == true)
                {
                    UpperSection[i].Forfeit = true;
                    UpperSection[i].Open = false;
                    break;
                }
            }
        }
        public void ForfeitUpperSectionCombination(string name)
        {
            for (int i = 0; i < 6; i++)
            {
                AddOnly me = UpperSection[i] as AddOnly;
                if (name.Contains(me.Name) && me.Open == true)
                {
                    UpperSection[i].Forfeit = true;
                    UpperSection[i].Open = false;
                    break;
                }
            }
        }
        internal void ForfeitLowerSectionCombination(string name)
        {
            if (name.StartsWith("Bonus Yahtzee"))
            {
                return;
            }

            for (int i = 0; i < LowerSection.Length; i++)
            {
                if (name.StartsWith(LowerSection[i].Name))
                {
                    LowerSection[i].Forfeit = true;
                    LowerSection[i].Open = false;
                    break;
                }
            }
        }
    }
}
