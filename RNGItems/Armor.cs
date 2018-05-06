using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGItems
{
    public class Armor : Item
    {
        public int armor { get; private set; }

        public Armor(string Name, int Itemlevel, Quality Qual, Dictionary<Stat, int> Statsgiven, Dictionary<Stat, int> Requiredstats, Type Type, TypeModifier Typemodifier, int Armor) : base(Name, Itemlevel, Qual, Statsgiven, Requiredstats, Type, Typemodifier)
        {
            armor = Armor;
        }

        public override string ToString()
        {
            string builder = $"{name}\n";
            builder += $"Item Level {itemLevel}\n";
            builder += $"{getTypeModifier()} {getType()}\n";

            builder += $"{armor} Armor\n";

            foreach (KeyValuePair<Stat, int> stat in statsGiven)
                builder += $"+ {stat.Value} {stat.Key.name}\n";

            foreach (KeyValuePair<Stat, int> stat in requiredStats)
                builder += $"Requires {stat.Value} {stat.Key.name}\n";

            //builder += $"Requires Level {requiredLevel}\n";

            return builder;
        }
    }
}
