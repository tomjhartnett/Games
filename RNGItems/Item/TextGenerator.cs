using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RNGItems
{
    //a class that is used by itemclasses to generate the required text for that class of item
    //this is the base version, with some standard default options
    //most should be modified for a unique feel
    public class TextGenerator
    {
        private Random rand { get; set; }
        private List<string> names;

        //initialize the random, as well as add names
        public TextGenerator(List<string> Names)
        {
            rand = new Random(Guid.NewGuid().GetHashCode());

            names = Names;
        }

        //initialize the random, as well as add names
        public TextGenerator(string path)
        {
            rand = new Random(Guid.NewGuid().GetHashCode());

            names = File.ReadAllLines(path).ToList();
        }

        //returns a random name from names
        public virtual string getName()
        {
            return names[rand.Next(0, names.Count)];
        }
        //generates the text for a ring
        public virtual string getText(Item i)
        {
            string builder = $"{i.name}\n";
            builder += $"Item Level {i.itemLevel}\n";
            builder += $"{i.type}\n";

            foreach (Stat stat in i.statsGiven)
                builder += $"+ {stat.getValue(i.qualityMult, i.itemLevel)} {stat.name}\n";

            foreach (Stat stat in i.requiredStats)
                builder += $"Requires {stat.getValue(i.qualityMult, i.itemLevel)} {stat.name}\n";

            return builder;
        }

        //generates a panel that describes this item
        public virtual Panel getPanel(Item item, Button button)
        {
            return new ItemPanel(item, button, getLabels(item));
        }

        //returns a list of strings that are the same as what is returned in getText, but split by newlines
        protected virtual List<string> getStrings(Item i)
        {
            List<string> ret = new List<string>();

            ret.Add(i.name);
            ret.Add($"Item Level {i.itemLevel}");
            ret.Add($"{i.type}");

            foreach (Stat stat in i.statsGiven)
                ret.Add($"+ {stat.getValue(i.qualityMult, i.itemLevel)} {stat.name}");

            foreach (Stat stat in i.requiredStats)
                ret.Add($"Requires {stat.getValue(i.qualityMult, i.itemLevel)} {stat.name}");

            return ret;
        }

        //returns a set of labels that describe the ring
        protected virtual List<Label> getLabels(Item i)
        {
            List<Label> ret = new List<Label>();
            Font preferred = new Font("Arial", 15);

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
                l.Font = preferred;
                ret.Add(l);
            }

            return ret;
        }

        //creates a label based on the passed text, y location, and foreColor c
        protected virtual Label getLabelFromSection(string text, int y, Color c)
        {
            Label ret = new Label();
            ret.Font = new Font("Arial", 15);
            ret.AutoSize = true;
            ret.ForeColor = c;
            ret.Text = text;
            ret.Location = new System.Drawing.Point(5, y + 5);

            ret.Height = TextRenderer.MeasureText(text, ret.Font).Height;

            return ret;
        }
    }
}
