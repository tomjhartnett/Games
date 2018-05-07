using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGItems
{
    /*
     * This class is used to generate items. When initialized, this class requires all possible item types of the original project.
     * It then generates random items based on these itemclasses
     */ 
    public class ItemGenerator
    {
        //all possible item classes
        public List<ItemClass> itemClasses { get; private set; }
        //the random number generator for this generator
        private static Random rand = new Random(Guid.NewGuid().GetHashCode());

        //the project using this helper class must pass all possible itemclasses
        public ItemGenerator(List<ItemClass> Itemclasses)
        {
            itemClasses = Itemclasses;
        }

        //generates an item based on the passed info
        public Item getRandomItem(ItemClass itemClass, int itemlevel, string quality)
        {
            return new Item(itemClass, itemlevel, quality);
        }

        //generates an item based on the passed info
        public Item getRandomItem(ItemClass itemClass, int itemlevel)
        {
            return new Item(itemClass, itemlevel);
        }

        //generates an item based on the passed info
        public Item getRandomItem(int itemlevel)
        {
            return new Item(getRandomClass(), itemlevel);
        }

        //returns a random class, based on equal weight on all available itemClasses
        private ItemClass getRandomClass()
        {
            return itemClasses[rand.Next(0, itemClasses.Count)];
        }
    }
}
