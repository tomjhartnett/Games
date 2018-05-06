using RNGItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    /*
     * This class is a child of TextGenerator and generates names and text for a Ring itemClass.
     */ 
    public class RingNameGenerator : TextGenerator
    {
        private Random rand { get; set; }
        private List<string> names = new List<string>();

        //initialize the random, as well as add names
        public RingNameGenerator()
        {
            rand = new Random(Guid.NewGuid().GetHashCode());

            names.Add("Band of Might");
            names.Add("Reaver Ring");
        }

        //returns a random name from names
        public override string getName()
        {
            return names[rand.Next(0, names.Count)];
        }

        //generates the text for a ring
        public override string getText(Item i)
        {
            string builder = $"{i.name}\n";
            builder += $"Item Level {i.itemLevel}\n";
            builder += $"{i.type}\n";

            foreach (Stat stat in i.statsGiven)
                builder += $"+ {stat.amount} {stat.name}\n";

            foreach (Stat stat in i.requiredStats)
                builder += $"Requires {stat.amount} {stat.name}\n";

            return builder;
        }
    }
}
