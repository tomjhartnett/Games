using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGItems
{
    /*
     * This class represents a Stat.
     * It requires a name and a formula.
     * The default amount is 0, and when evaluated, will get a number based on the formula and multiplier.
     */
    public class Stat
    {
        public string name { get; private set; }
        private StatFormula formula { get; set; }
        private int amount { get; set; }
        private bool evaluated = false;

        public Stat(string Name, StatFormula Formula)
        {
            name = Name;
            formula = Formula;
        }

        public int getValue(int mult, int itemlevel)
        {
            if (!evaluated)
            {
                amount = formula.getRandomAmount(itemlevel) * mult;
                evaluated = true;
            }

            return amount;
        }
    }
}
