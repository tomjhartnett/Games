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
        public int amount { get; private set; }
        private StatFormula formula { get; set; }

        public Stat(string Name, StatFormula Formula)
        {
            name = Name;
            formula = Formula;
            amount = 0;
        }

        public void evaluateStat(int mult, int itemlevel)
        {
            amount = formula.getRandomAmount(itemlevel) * mult;
        }
    }
}
