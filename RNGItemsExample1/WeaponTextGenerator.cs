using RNGItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGItemsExample1
{
    public class WeaponTextGenerator : TextGenerator
    {
        public WeaponTextGenerator(string path) : base(path)
        { }

        //returns the text as a string
        public override string getText(Item i)
        {
            string builder = $"{i.name}\n";
            builder += $"Item Level {i.itemLevel}\n";
            builder += $"{i.type} {i.typeModifier}\n";

            builder += $"{i.getStat("mindamage", i.statsGiven)} - {i.getStat("maxdamage", i.statsGiven)} Damage\n";

            foreach (Stat stat in i.statsGiven)
                builder += $"+ {stat.getValue(i)} {stat.name}\n";

            foreach (Stat stat in i.requiredStats)
                builder += $"Requires {stat.getValue(i)} {stat.name}\n";

            return builder;
        }

        //returns a list of strings that are the same as what is returned in getText, but split by newlines
        protected override List<string> getStrings(Item i)
        {
            List<string> ret = new List<string>();

            ret.Add(i.name);
            ret.Add($"Item Level {i.itemLevel}");
            ret.Add($"{i.type}");

            ret.Add($"{i.getStat("mindamage", i.statsGiven)} - {i.getStat("maxdamage", i.statsGiven)} Damage");

            foreach (Stat stat in i.statsGiven)
                if (!stat.name.ToLower().Equals("mindamage") && !stat.name.ToLower().Equals("maxdamage"))
                    ret.Add($"+ {stat.getValue(i)} {stat.name}");

            foreach (Stat stat in i.requiredStats)
                ret.Add($"Requires {stat.getValue(i)} {stat.name}");

            return ret;
        }
    }
}
