using RNGItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    /*
     * This class is a StatFormula, that when prompted for a random amount, returns a random number between 1 and (itemLevel * 2 + 1)
     */ 
    public class StandardStatGrowth : StatFormula
    {
        private Random rand { get; set; }

        public StandardStatGrowth()
        {
            rand = new Random(Guid.NewGuid().GetHashCode());
        }

        public override int getRandomAmount(int itemLevel)
        {
            return rand.Next(itemLevel * 2) + 1;
        }
    }
}
