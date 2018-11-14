using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahtzee.Combinations
{
    public class SetValue : CombinationBase
    {
        public int SetValueValue { get; set; }
        public SetValue(string name, int value)
            : base(name, CombinationTypeEnum.Simple)
        {
            SetValueValue = value;
        }

        public override void CalculateValue(int[] input)
        {
            int iInput = input[0];
            if (Open == false)
                throw new CombinationException(string.Format("You already used {0}", Name));

            if (iInput != 0 && iInput != 1)
                throw new CombinationException("Input is limited to 1 or 0");

            Value = SetValueValue * iInput;
            Open = false;
        }
    }
}
