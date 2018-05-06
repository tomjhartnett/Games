using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace RNGItems
{
    /*
     * This class represents an item. 
     * Each item has a list of stats that are required to wear the item, as well as a list of stats that are given to the hero when wearing the item.
     * In addition, each item has a name.
     * Also a type, which is a string representation of the type of the item (i.e. sword, belt, helmet, ring, bow, whatever)
     * The typeModifier is the material or specific type of the item. For example, one handed or two handed for weapons, and cloth or mail for armor)
     * The itemlevel is the implicit level of the weapon. It affects how strong the stat buffs are (or damage/armor etc)
     * The TextGenerator generates all text for this item. It is specific to the itemClass.
     * Finally, the quality of the item is how rare it is. This affects the stat strength as well
     */ 
    public class Item
    {
        public List<Stat> statsGiven { get; protected set; }
        public List<Stat> requiredStats { get; protected set; }
        private TextGenerator textGenerator { get; set; }
        public string name { get; protected set; }
        public string type { get; protected set; }
        public string typeModifier { get; protected set; }
        public int itemLevel { get; protected set; }
        public string quality { get; protected set; }

        public Item(ItemClass Itemclass, int Itemlevel)
        {
            textGenerator = Itemclass.nameGenerator;
            name = textGenerator.getName();
            itemLevel = Itemlevel;
            quality = Itemclass.getRandomQuality();
            statsGiven = Itemclass.getRandomStatsGiven(Itemlevel, quality, itemLevel);
            requiredStats = Itemclass.getRandomStatsRequired(Itemlevel, quality, itemLevel);
            type = Itemclass.type;
            typeModifier = Itemclass.getRandomTypeModifier();
        }

        public Item(ItemClass Itemclass, int Itemlevel, string Quality)
        {
            name = Itemclass.nameGenerator.getName();
            itemLevel = Itemlevel;
            quality = Quality;
            statsGiven = Itemclass.getRandomStatsGiven(Itemlevel, quality, itemLevel);
            requiredStats = Itemclass.getRandomStatsRequired(Itemlevel, quality, itemLevel);
            type = Itemclass.type;
            typeModifier = Itemclass.getRandomTypeModifier();
        }

        //replaces the default ToString to be a better visual
        public override string ToString()
        {
            return textGenerator.getText(this);
        }
    }
}
