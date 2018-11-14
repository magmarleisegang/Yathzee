using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahtzee
{
    public class CombinationBase
    {
        public string Name { get; set; }
        public CombinationTypeEnum Type { get; set; }
        public int Value { get; set; }
        public int Input { get; set; }
        public bool Open { get; set; }
        public bool Forfeit { get; set; }

        public CombinationBase(string name, CombinationTypeEnum type)
        {
            Open = true;
            Name = name;
            Type = type;
        }

        public virtual void CalculateValue(int input)
        {
            throw new NotImplementedException();
        }

        public virtual void CalculateValue(int[] input)
        {
            throw new NotImplementedException();
        }
        
        public virtual void CalculateValue(CombinationFormulas.ICombinationFormula formula)
        {
            Value = formula.GetValue();
        }
    }

    public enum CombinationTypeEnum
    {
        Simple,
        Formula,
        Summation
    }

    public class CombinationException : Exception
    {
        public CombinationException(string message) : base(message) { }
    }
}
