using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahtzee.Combinations
{
    public class AddOnly : CombinationBase
    {
        public int AddOnlyValue;
       
        public AddOnly(int addOnlyValue)
            : base(string.Format("AddOnly {0}", addOnlyValue), CombinationTypeEnum.Formula)
        {
            AddOnlyValue = addOnlyValue;
        }

        public override void CalculateValue(int input)
        {
            if (Open == false)
                throw new CombinationException(string.Format("You already used {0}", Name));
            if (input > 6 || input < 0)
                throw new CombinationException("Input must be between 1 and 6");
            Value = input * AddOnlyValue;
            Input = input;
            Open = false;
        }
    }
}
