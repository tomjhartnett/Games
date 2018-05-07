using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RNGItems;

namespace Test
{
    public partial class TestForm : Form
    {
        /*
         * This class is meant to test the RNGItems project.
         */ 
        public TestForm()
        {
            InitializeComponent();

            initItemTest();
        }

        private void initItemTest()
        {
            //generate all qualities
            List<string> qualities = new List<string>() { "Common", "Uncommon", "Rare", "Epic", "Legendary" };
            //generate some random growth formula to test
            StandardStatGrowth growth = new StandardStatGrowth();

            Dictionary<string, List<Bitmap>> images = ImageLoader.getTypesAndImages(@"..\\..\\Images");

            //typesAndNames is all of our itemClasses for this project
            List<ItemClass> typesAndNames = new List<ItemClass>();
            //the ring is generated from the default item class because it has no special display/stats/etc
            ItemClass ring = new ItemClass("Ring", new TextGenerator("..\\..\\names\\ring.txt"), new List<string>() { }, qualities, images["finger"], 
                new List<Stat>() { getRandomStandardGrowthStat("Intelligence") }, 
                new List<Stat>() { getRandomStandardGrowthStat("Strength"), getRandomStandardGrowthStat("Stamina") }, 
                new List<Stat>() { }, 
                new List<Stat>() { getRandomStandardGrowthStat("Intelligence") } );
            typesAndNames.Add(ring);


            //get the generator and generate an item
            ItemGenerator testGenerator = new ItemGenerator(typesAndNames);
            Item testItem = testGenerator.getRandomItem(ring, 100);


            //display the item
            testLbl.Text = testItem.ToString();
            Refresh();

            ItemButton button = testItem.getButton();
            button.Location = new Point(100, 100);
            Controls.Add(button);
        }

        //generates a random stat based on our standardStatGrowth formula
        private Stat getRandomStandardGrowthStat(string name)
        {
            return new Stat(name, new StandardStatGrowth());
        }
    }
}
