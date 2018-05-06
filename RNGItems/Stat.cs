using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGItems
{
    /*
     * This class represents a Stat.
     * It is meant to be flexible so any project can put its own stats in.
     * The class has a name which is a string representation of the name.
     * It also has a referenced stat, which currently is an int (but should probably be changed).
     * This reference is used to keep track of the the stat, for checks against required amounts to wear the items.
     */
    public class Stat
    {
        public string name { get; private set; }
        public int referencedStat { get; private set;}

        public Stat(string Name)
        {
            name = Name;
        }

        public Stat(string Name, ref int ReferencedStat)
        {
            name = Name;
            referencedStat = ReferencedStat;
        }
    }
}
