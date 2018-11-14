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
	public partial class Help : Form
	{
		public Help()
		{
			InitializeComponent();
			label1.Text = @"How to capture input combinations:

Upper section: 
Simply enter the number of dice of the specified value rolled.

Lower Section:

Three and Four of a kind: Enter a comma separated list of the three/four kind followed by the values of the remaining dice.
Only the first 3 or 2 values will be used in the calculation for Three of a Kind and Four of a kind respectively.
e.g dice rolled 3 3 3 1 2 will be input to Three of a Kind as 3,1,2

Full House, Short/Long Straight, Yahtzee: enter 1 if the combination was rolled. The correct score will be displayed

Chance: enter the 5 die values as a comma separated list e.g dice rolled 1 2 3 4 5 input as 1,2,3,4,5

Bonus Yahtzee: Simply enter 1 for each bonus Yahtzee. If 1 is entered but the Lower Section Yahtzee is still empty, 
					it will be set and the bonus value will remain zero.

To forfeit any combination simply enter a dash (-).";
		}
	}
}
