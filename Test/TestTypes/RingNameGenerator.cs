using RNGItems;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        //generates a panel that describes this item
        public override Panel getPanel(Item item, Button button)
        {
            return new ItemPanel(item, button, getLabels(item));
        }

        //returns a list of strings that are the same as what is returned in getText, but split by newlines
        private List<string> getStrings(Item i)
        {
            List<string> ret = new List<string>();

            ret.Add(i.name);
            ret.Add($"Item Level {i.itemLevel}");
            ret.Add($"{i.type}");

            foreach (Stat stat in i.statsGiven)
                ret.Add($"+ {stat.amount} {stat.name}");

            foreach (Stat stat in i.requiredStats)
                ret.Add($"Requires {stat.amount} {stat.name}");

            return ret;
        }

        //returns a set of labels that describe the ring
        private List<Label> getLabels(Item i)
        {
            List<Label> ret = new List<Label>();

            int y = 0;
            int index = 0;
            foreach (string s in getStrings(i))
            {
                Color c = Color.Black;
                if (index == 0)
                    c = i.qualityColor;
                else if (index == 1)
                    c = Color.Gold;
                index++;


                Label l = getLabelFromSection(s, y, c);
                y += l.Height;
                ret.Add(l);
            }

            return ret;
        }

        //creates a label based on the passed text, y location, and foreColor c
        private Label getLabelFromSection(string text, int y, Color c)
        {
            Label ret = new Label();
            ret.AutoSize = true;
            ret.ForeColor = c;
            ret.Text = text;
            ret.Location = new System.Drawing.Point(5, y + 5);

            ret.Height = TextRenderer.MeasureText(text, ret.Font).Height;

            return ret;
        }
    }
}
