using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGItems
{
    public class Weapon : Item
    {
        public int minDamage { get; private set; }
        public int maxDamage { get; private set; }

        public Weapon(string Name, int Itemlevel, Quality Qual, Dictionary<Stat, int> Statsgiven, Dictionary<Stat, int> Requiredstats, Type Type, TypeModifier Typemodifier, int Mindamage, int Maxdamage) : base(Name, Itemlevel, Qual, Statsgiven, Requiredstats, Type, Typemodifier)
        {
            minDamage = Mindamage;
            maxDamage = Maxdamage;
        }

        public override string ToString()
        {
            string builder = $"{name}\n";
            builder += $"Item Level {itemLevel}\n";
            builder += $"{getTypeModifier()} {getType()}\n";

            builder += $"{minDamage} - {maxDamage} Damage\n";
            builder += $"{(maxDamage - minDamage) / 2} DPS\n";

            foreach (KeyValuePair<Stat, int> stat in statsGiven)
                builder += $"+ {stat.Value} {stat.Key.name}\n";

            foreach (KeyValuePair<Stat, int> stat in requiredStats)
                builder += $"Requires {stat.Value} {stat.Key.name}\n";

            //builder += $"Requires Level {requiredLevel}\n";

            return builder;
        }
    }
}
