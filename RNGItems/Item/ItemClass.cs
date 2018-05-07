using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGItems
{
    /*
     * This class represents a class of items.
     * For example, a sword is an itemClass, and each sword has common characteristics like possible names, possible materials, rarities (qualities), as well as possible or required stats.
     */
    public class ItemClass
    {
        //the type of this itemclass, i.e. sword
        public string type { get; private set; }
        //the generator to generate text for this class
        public TextGenerator nameGenerator { get; private set; }
        //the various materials this object can be
        private List<string> typeModifier { get; set; }
        //the various materials this object can be
        private List<Bitmap> images { get; set; }
        //the various qualities or rarities this item can be
        private List<string> qualities { get; set; }
        //the possible stats required to wear this itemclass
        private List<Stat> possibleRequired { get; set; }
        //the possible stats that are given by wearing this itemclass
        private List<Stat> possibleGiven { get; set; }
        //the stats that are always given by wearing this itemclass
        private List<Stat> requiredGiven { get; set; }
        //the stats that are always required to wear this item
        private List<Stat> requiredRequired { get; set; }
        //our random number generator
        private static Random rand = new Random(Guid.NewGuid().GetHashCode());
        
        public ItemClass(string Type, TextGenerator Namegenerator, List<string> Typemodifier, List<string> Qualities, List<Bitmap> possibleImages, List<Stat> Possiblerequired, List<Stat> Possiblegiven, List<Stat> Requiredrequired, List<Stat> Requiredgiven)
        {
            type = Type;
            nameGenerator = Namegenerator;
            images = possibleImages;
            typeModifier = Typemodifier;
            qualities = Qualities;
            possibleRequired = Possiblerequired;
            possibleGiven = Possiblegiven;
            requiredGiven = Requiredgiven;
            requiredRequired = Requiredrequired;
        }

        //the default way to get the random given stats
        //most children should override this
        public virtual List<Stat> getRandomStatsGiven(int itemLevel, string quality, int itemlevel)
        {
            List<Stat> ret = new List<Stat>();

            foreach (Stat s in requiredGiven)
                ret.Add(new Stat(s));

            foreach (Stat s in possibleGiven)
                if(rand.Next(0, 2) == 0)
                    ret.Add(new Stat(s));

            return ret;
        }

        //the default way to get the random required stats
        //most children should override this
        public virtual List<Stat> getRandomStatsRequired(int itemLevel, string quality, int itemlevel)
        {
            List<Stat> ret = new List<Stat>();

            foreach (Stat s in requiredRequired)
                ret.Add(new Stat(s));

            foreach (Stat s in possibleRequired)
                if (rand.Next(0, 2) == 0)
                    ret.Add(new Stat(s));

            return ret;
        }

        //the default way to get the random quality
        //most children should override this
        public virtual string getRandomQuality()
        {
            return qualities[rand.Next(0, qualities.Count)];
        }

        //the default way to get the random type modifier
        //most children should override this
        public virtual string getRandomTypeModifier()
        {
            if (typeModifier.Count > 0)
                return typeModifier[rand.Next(0, typeModifier.Count)];
            else
                return "";
        }

        //the default way to get a random image
        //most children should override this
        public virtual Bitmap getRandomImage()
        {
            return images[rand.Next(0, images.Count)];
        }

        //returns the color based on the quality
        //most children should override this
        public virtual Color getColor(string quality)
        {
            Color ret;
            switch (qualities.IndexOf(quality))
            {
                case 0: ret = Color.White; break;
                case 1: ret = Color.Green; break;
                case 2: ret = Color.Blue; break;
                case 3: ret = Color.Purple; break;
                case 4: ret = Color.Orange; break;

                default: ret = Color.White; break;
            }

            return ret;
        }

        //returns the quality multiplier for stat calculations
        //most children should override this
        public virtual int getQualityMultiplier(string quality)
        {
            return qualities.IndexOf(quality) + 1;
        }
    }
}
