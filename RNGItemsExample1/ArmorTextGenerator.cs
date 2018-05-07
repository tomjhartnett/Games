using RNGItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RNGItemsExample1
{
    public class ArmorTextGenerator : TextGenerator
    {
        public override string getText(Item i)
        {
            string builder = $"{i.name}\n";
            builder += $"Item Level {i.itemLevel}\n";
            builder += $"{i.type} {i.typeModifier}\n";

            builder += $"{i.getStat("armor")} Armor\n";

            foreach (Stat stat in i.statsGiven)
                builder += $"+ {stat.amount} {stat.name}\n";

            foreach (Stat stat in i.requiredStats)
                builder += $"Requires {stat.amount} {stat.name}\n";

            return builder;
        }

        public override Panel getPanel(Item i, Button b)
        {
            throw new NotImplementedException();
        }

        public override string getName()
        {
            throw new NotImplementedException();
        }
    }
}
