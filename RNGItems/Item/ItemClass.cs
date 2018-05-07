using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGItems
{
    //This class represents a class of item. Some common example might be weapon and armor.
    //All armors have an armor stat, as well as have the same text output
    public class ItemClass
    {
        //the various materials this object can be
        public List<string> typeModifier { get; private set; }
        //the various qualities or rarities this item can be
        public List<string> qualities { get; private set; }
        //the possible stats required to wear this itemclass
        public List<Stat> possibleRequired { get; private set; }
        //the possible stats that are given by wearing this itemclass
        public List<Stat> possibleGiven { get; private set; }
        //the stats that are always given by wearing this itemclass
        public List<Stat> requiredGiven { get; private set; }
        //the stats that are always required to wear this item
        public List<Stat> requiredRequired { get; private set; }

        public ItemClass(List<string> Typemodifier, List<string> Qualities, List<Stat> Possiblerequired, List<Stat> Possiblegiven, List<Stat> Requiredrequired, List<Stat> Requiredgiven)
        {
            typeModifier = Typemodifier;
            qualities = Qualities;
            possibleRequired = Possiblerequired;
            possibleGiven = Possiblegiven;
            requiredGiven = Requiredgiven;
            requiredRequired = Requiredrequired;
        }
    }
}
