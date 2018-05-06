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
     * Also a type, which is a enum representation of the type of the item (i.e. sword, belt, helmet, ring, bow, whatever)
     * The typeModifier is the material or specific type of the item. For example, one handed or two handed for weapons, and cloth or mail for armor)
     * The itemlevel is the implicit level of the weapon. It affects how strong the stat buffs are (or damage/armor etc)
     * Finally, the quality of the item is how rare it is. This affects the stat strength as well
     */ 
    public class Item
    {
        public enum Quality { COMMON, UNCOMMON, RARE, EPIC, LEGENDARY }
        public enum Type { SWORD, BOW, RING, HELMET }
        public enum TypeModifier { TWO_HANDED, ONE_HANDED, CLOTH, LEATHER }


        public Dictionary<Stat, int> statsGiven { get; protected set; }
        public Dictionary<Stat, int> requiredStats { get; protected set; }
        public int requiredLevel { get; protected set; }
        public string name { get; protected set; }
        public Type type { get; protected set; }
        public TypeModifier typeModifier { get; protected set; }
        public int itemLevel { get; protected set; }
        public Quality quality { get; protected set; }
        private Panel panel;

        public Item(string Name, int Itemlevel, Quality Qual, Dictionary<Stat, int> Statsgiven, Dictionary<Stat, int> Requiredstats, Type Type, TypeModifier Typemodifier)
        {
            name = Name;
            itemLevel = Itemlevel;
            quality = Qual;
            statsGiven = Statsgiven;
            requiredStats = Requiredstats;
            type = Type;
            typeModifier = Typemodifier;
        }

        //replaces the default ToString to be a better visual
        public override string ToString()
        {
            string builder = $"{name}\n";
            builder += $"Item Level {itemLevel}\n";
            builder += $"{getTypeModifier()} {getType()}\n";
            
            foreach(KeyValuePair<Stat, int> stat in statsGiven)
                builder += $"+ {stat.Value} {stat.Key.name}\n";

            foreach (KeyValuePair<Stat, int> stat in requiredStats)
                builder += $"Requires {stat.Value} {stat.Key.name}\n";

            //builder += $"Requires Level {requiredLevel}\n";

            return builder;
        }

        //Tries to find stat in statsGiven
        //if matched, return the quantity given
        public int getStatGiven(string stat)
        {
            foreach (Stat s in statsGiven.Keys)
                if (s.name == stat)
                    return statsGiven[s];

            return 0;
        }

        //returns an output friendly representation of the type
        public string getType()
        {
            string ret = "";

            switch (type)
            {
                case Type.BOW: ret = "Bow"; break;
                case Type.HELMET: ret = "Helmet"; break;
                case Type.RING: ret = "Ring"; break;
                case Type.SWORD: ret = "Sword"; break;
                default: break;
            }

            return ret;
        }

        //returns an output friendly representation of the typemodifier
        public string getTypeModifier()
        {
            string ret = "";

            switch (typeModifier)
            {
                case Item.TypeModifier.CLOTH: ret = "Bloth"; break;
                case Item.TypeModifier.LEATHER: ret = "Leather"; break;
                case Item.TypeModifier.ONE_HANDED: ret = "One-handed"; break;
                case Item.TypeModifier.TWO_HANDED: ret = "Two-handed"; break;
                default: break;
            }

            return ret;
        }

        public Button getButton()
        {
            Button ret = new Button();
            ret.AutoSize = true;

            ToolTip tooltip = new ToolTip();
            tooltip.AutoPopDelay = 0;
            tooltip.InitialDelay = 0;
            tooltip.ReshowDelay = 0;
            tooltip.ShowAlways = true;
            tooltip.AutomaticDelay = 0;
            tooltip.UseAnimation = false;
            tooltip.UseFading = false;

            Color c = Color.WhiteSmoke;
            if (quality == Quality.COMMON)
                c = Color.WhiteSmoke;
            else if (quality == Quality.UNCOMMON)
                c = Color.LightGreen;
            else if (quality == Quality.RARE)
                c = Color.DeepSkyBlue;
            else if (quality == Quality.EPIC)
                c = Color.Purple;
            else if (quality == Quality.LEGENDARY)
                c = Color.Orange;

            tooltip.BackColor = c;


            tooltip.SetToolTip(ret, ToString());

            return ret;
        }
    }
}
