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
        protected TextGenerator textGenerator { get; set; }
        public string name { get; protected set; }
        public string type { get; protected set; }
        public string typeModifier { get; protected set; }
        public Bitmap image { get; protected set; }
        public int itemLevel { get; protected set; }
        public string quality { get; protected set; }
        public int qualityMult { get; set; }
        public Color qualityColor { get; protected set; }

        public Item(TypeClass Itemclass, int Itemlevel)
        {
            //sets the textGenerator to call
            textGenerator = Itemclass.nameGenerator;
            //sets the name
            name = textGenerator.getName();
            //sets the itemlevel
            itemLevel = Itemlevel;
            //gets a random quality
            quality = Itemclass.getRandomQuality();
            //gets a random quality
            qualityMult = Itemclass.getQualityMultiplier(quality);
            //gets random stats bestowed on wearer
            statsGiven = Itemclass.getRandomStatsGiven(Itemlevel, quality, itemLevel);
            //gets random stats required to wear the item
            requiredStats = Itemclass.getRandomStatsRequired(Itemlevel, quality, itemLevel);
            //sets the type
            type = Itemclass.type;
            //gets a random type modifier
            typeModifier = Itemclass.getRandomTypeModifier();
            //sets the color of the quality
            qualityColor = Itemclass.getColor(quality);
            //sets the image
            image = Itemclass.getRandomImage();
        }

        public Item(TypeClass Itemclass, int Itemlevel, string Quality)
        {
            //sets the textGenerator to call
            textGenerator = Itemclass.nameGenerator;
            //sets the name
            name = textGenerator.getName();
            //sets the itemlevel
            itemLevel = Itemlevel;
            //sets the quality
            quality = Quality;
            //gets a random quality
            qualityMult = Itemclass.getQualityMultiplier(quality);
            //gets random stats bestowed on wearer
            statsGiven = Itemclass.getRandomStatsGiven(Itemlevel, quality, itemLevel);
            //gets random stats required to wear the item
            requiredStats = Itemclass.getRandomStatsRequired(Itemlevel, quality, itemLevel);
            //sets the type
            type = Itemclass.type;
            //gets a random type modifier
            typeModifier = Itemclass.getRandomTypeModifier();
            //sets the color of the quality
            qualityColor = Itemclass.getColor(quality);
            //sets the image
            image = Itemclass.getRandomImage();
        }

        //replaces the default ToString to be a better visual
        public override string ToString()
        {
            return textGenerator.getText(this);
        }

        //gets the set of labels that describes the item
        public Panel getPanel(Button b)
        {
            return textGenerator.getPanel(this, b);
        }

        //get the button for this item
        public ItemButton getButton()
        {
            return new ItemButton(this);
        }
        
        //calculates how much of a stat value is in a list of stats
        public int getStat(string stat, List<Stat> stats)
        {
            int total = 0;

            foreach(Stat s in stats)
                if (s.name.ToLower().Equals(stat.ToLower()))
                    total += s.getValue(qualityMult, itemLevel);

            return total;
        }
    }
}
