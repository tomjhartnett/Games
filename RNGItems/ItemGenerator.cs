using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGItems
{
    /*
     * This class is used to generate items. When initialized, this class first reads in stat/type/typemodifier/names, by grabbing them from text files based on the passed path names.
     * Then, getRandomItem can be called to get an item. Most combinations of qualifiers can be passed in to generate exactly the required item.
     */ 
    public class ItemGenerator
    {
        //all possible stats, read from file
        private List<Stat> stats { get; set; }
        //possible nouns for items based on the type
        private Dictionary<string, List<string>> namesByType { get; set; }
        //the various types that an item can be (i.e. sword, ring, belt)
        public List<string> types { get; private set; }
        //modifiers to the types (i.e. two handed, one handed, mail, cloth)
        public List<Item.TypeModifier> typeModifiers { get; private set; }
        //the random number generator for this generator
        private Random rand = new Random(Guid.NewGuid().GetHashCode());

        //on creation, require paths for loading the item info possibilities
        //since the files can be in a seperate project, allows for different item types and stats
        public ItemGenerator(Dictionary<string, List<string>> types, string statFilePath, string typesFilePath, string typeModifiersFilePath, string namesByTypeFilePath)
        {
            stats = loadStats(statFilePath);
            types = loadTypes(typesFilePath);
            typeModifiers = loadTypeModifiers(typeModifiersFilePath);
            namesByType = loadNamesByType(namesByTypeFilePath);
        }

        //generates an item based on the passed info
        public Item getRandomItem(int itemlevel, Item.Quality quality, Item.Type type, Item.TypeModifier typeModifier)
        {
            Dictionary<Stat, int> statsRequired = getRandomStatsRequired(itemlevel);
            Dictionary<Stat, int> statsGiven = getRandomStatsGiven(itemlevel, quality, type);
            string name = getRandomName(quality, type);

            Item ret = null;

            if (type == Item.Type.SWORD || type == Item.Type.BOW)
            {
                Tuple<int, int> damage = getDamage(itemlevel, quality);
                ret = new Weapon(name, itemlevel, quality, statsGiven, statsRequired, type, typeModifier, damage.Item1, damage.Item2);
            } else if (type == Item.Type.HELMET)
            {
                int armor = getArmor(itemlevel, quality);
                ret = new Armor(name, itemlevel, quality, statsGiven, statsRequired, type, typeModifier, armor);
            }
            else
                ret = new Item(name, itemlevel, quality, statsGiven, statsRequired, type, typeModifier);

            return ret;
        }

        //generates an item based on the passed info
        public Item getRandomItem(int itemlevel, Item.Type type, Item.TypeModifier typeModifier)
        {
            Item.Quality quality = getRandomQuality();

            Dictionary<Stat, int> statsRequired = getRandomStatsRequired(itemlevel);
            Dictionary<Stat, int> statsGiven = getRandomStatsGiven(itemlevel, quality, type);
            string name = getRandomName(quality, type);

            Item ret = null;

            if (type == Item.Type.SWORD || type == Item.Type.BOW)
            {
                Tuple<int, int> damage = getDamage(itemlevel, quality);
                ret = new Weapon(name, itemlevel, quality, statsGiven, statsRequired, type, typeModifier, damage.Item1, damage.Item2);
            }
            else if (type == Item.Type.HELMET)
            {
                int armor = getArmor(itemlevel, quality);
                ret = new Armor(name, itemlevel, quality, statsGiven, statsRequired, type, typeModifier, armor);
            }
            else
                ret = new Item(name, itemlevel, quality, statsGiven, statsRequired, type, typeModifier);

            return ret;
        }

        //this function generates stats that this item gives to the wearer, based on itemlevel and quality
        //algorithm currently is a random number between (itemlevel and 4xitemlevel) and then multiplied by the quality modifier
        //of common = 1, uncommon = 2, rare = 4, epic = 8, legendary = 20
        private Dictionary<Stat, int> getRandomStatsGiven(int itemlevel, Item.Quality quality, Item.Type type)
        {
            Dictionary<Stat, int> ret = new Dictionary<Stat, int>();

            int modifier = 1;
            switch (quality)
            {
                case Item.Quality.COMMON:
                    modifier = 1;
                    break;
                case Item.Quality.UNCOMMON:
                    modifier = 2;
                    break;
                case Item.Quality.RARE:
                    modifier = 4;
                    break;
                case Item.Quality.EPIC:
                    modifier = 8;
                    break;
                case Item.Quality.LEGENDARY:
                    modifier = 20;
                    break;

                default:
                    modifier = 1;
                    break;
            }

            foreach (Stat stat in stats)
                ret.Add(stat, rand.Next(itemlevel * 2, itemlevel * 4) * modifier);

            return ret;
        }

        //this function generates stats that are required in order to wear this item, based on itemlevel
        //algorithm currently is a random number between (itemlevel and 4xitemlevel)
        private Dictionary<Stat, int> getRandomStatsRequired(int itemlevel)
        {
            Dictionary<Stat, int> ret = new Dictionary<Stat, int>();

            foreach (Stat stat in stats)
                ret.Add(stat, rand.Next(itemlevel, itemlevel * 4));

            return ret;
        }

        //this function generates a random name based on the type and quality
        //the algorithm is currently to ignore quality and generate a random name based on type, no weights
        private string getRandomName(Item.Quality quality, Item.Type type)
        {
            string name = "";

            int index = rand.Next(0, namesByType[type].Count - 1);
            name = namesByType[type][index];

            return name;
        }

        //this function generates random damage based on the type and quality
        //the algorithm is currently to assign weight to quality to itemlevel
        private Tuple<int, int> getDamage(int itemlevel, Item.Quality quality)
        {
            int modifier = 1;
            switch (quality)
            {
                case Item.Quality.COMMON:
                    modifier = 1;
                    break;
                case Item.Quality.UNCOMMON:
                    modifier = 2;
                    break;
                case Item.Quality.RARE:
                    modifier = 4;
                    break;
                case Item.Quality.EPIC:
                    modifier = 8;
                    break;
                case Item.Quality.LEGENDARY:
                    modifier = 20;
                    break;

                default:
                    modifier = 1;
                    break;
            }

            int mindamage = rand.Next(itemlevel, itemlevel * 2) * modifier;
            int maxdamage = rand.Next(itemlevel * 2, itemlevel * 4) * modifier * 2;

            return new Tuple<int, int>(mindamage, maxdamage);
        }

        //this function generates random damage based on the type and quality
        //the algorithm is currently to assign weight to quality to itemlevel
        private int getArmor(int itemlevel, Item.Quality quality)
        {
            int modifier = 1;
            switch (quality)
            {
                case Item.Quality.COMMON:
                    modifier = 1;
                    break;
                case Item.Quality.UNCOMMON:
                    modifier = 2;
                    break;
                case Item.Quality.RARE:
                    modifier = 4;
                    break;
                case Item.Quality.EPIC:
                    modifier = 8;
                    break;
                case Item.Quality.LEGENDARY:
                    modifier = 20;
                    break;

                default:
                    modifier = 1;
                    break;
            }

            int armor = rand.Next(itemlevel, itemlevel * 2) * modifier;

            return armor;
        }

        //this function generates a random quality based on itemlevel
        //current algorithm is equal weights
        private Item.Quality getRandomQuality()
        {
            return (Item.Quality)(rand.Next(Enum.GetNames(typeof(Item.Quality)).Length));
        }

        //this function is supposed to generate stats from a file
        //it currently just adds 3 names to the stats
        private List<Stat> loadStats(string filePath)
        {
            List<Stat> ret = new List<Stat>();

            ret.Add(new Stat("Strength"));
            ret.Add(new Stat("Intelligence"));
            ret.Add(new Stat("Stamina"));

            return ret;
        }

        //this function is supposed to generate stats from a file
        //it currently just adds 3 names to the typemodifiers
        private List<Item.TypeModifier> loadTypeModifiers(string filePath)
        {
            List<Item.TypeModifier> ret = new List<Item.TypeModifier>();

            ret.Add(Item.TypeModifier.ONE_HANDED);
            ret.Add(Item.TypeModifier.CLOTH);
            ret.Add(Item.TypeModifier.LEATHER);
            ret.Add(Item.TypeModifier.TWO_HANDED);

            return ret;
        }

        //this function is supposed to generate names from a file
        //it currently just adds 3 types to the names
        private Dictionary<Item.Type, List<string>> loadNamesByType(string filePath)
        {
            Dictionary<Item.Type, List<string>> ret = new Dictionary<Item.Type, List<string>>();

            ret.Add(Item.Type.SWORD, new List<string> { "Greatsword" , "Blade" });
            ret.Add(Item.Type.HELMET, new List<string> { "Halfhelm", "Full Helm" });
            ret.Add(Item.Type.BOW, new List<string> { "Longbow", "Shortbow" });
            ret.Add(Item.Type.RING, new List<string> { "Signet Ring", "Band" });

            return ret;
        }

        //this function is supposed to generate types from a file
        //it currently just adds 3 hardcoded values
        private List<Item.Type> loadTypes(string filePath)
        {
            List<Item.Type> ret = new List<Item.Type>();

            ret.Add(Item.Type.BOW);
            ret.Add(Item.Type.HELMET);
            ret.Add(Item.Type.RING);
            ret.Add(Item.Type.SWORD);

            return ret;
        }
    }
}
