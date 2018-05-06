using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGItems
{
    //represents some sort of formula to receive a value for a stat
    //getRandomAmount returns a number based on the itemLevel, must be implemented
    public abstract class StatFormula
    {
        public abstract int getRandomAmount(int itemLevel);
    }
}
