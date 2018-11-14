using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahtzee.CombinationFormulas
{
    public interface ICombinationFormula
    {
        int GetValue();
    }

    public class ThreeKind : ICombinationFormula
    {
        private int m_Kind;
        private int[] m_Extra;

        public ThreeKind(int kind, int[] extra)
        {
            m_Kind = kind;
            m_Extra = extra;
        }

        public int GetValue()
        {
            int iTempExtra = 0;
            for (int i = 0; i < m_Extra.Length; i++)
            {
                iTempExtra += m_Extra[i];
            }

            return (m_Kind * 3) + iTempExtra;
        }
    }

    public class FourKind : ICombinationFormula
    {
        private int m_Kind;
        private int m_Extra;

        public FourKind(int kind, int extra)
        {
            m_Kind = kind;
            m_Extra = extra;
        }

        public int GetValue()
        {
            return (m_Kind * 4) + m_Extra;
        }
    }

    public class Chance : ICombinationFormula
    {
        public int Value;
        public Chance(int[] input)
        {
            if (input.Length != 5)
                throw new CombinationException("Chance formula requries 5 inputs");

            Value = 0;
            for (int i = 0; i < input.Length; i++)
            {
                Value += input[i];
            }
        }
        public Chance(int v1, int v2, int v3, int v4, int v5)
        {

            Value = v1 + v2 + v3 + v4 + v5;
        }

        public int GetValue()
        {
            return Value;
        }
    }
}
