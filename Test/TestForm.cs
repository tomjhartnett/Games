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

        public void initItemTest()
        {
            Dictionary<string, List<string>> typesAndNames = new Dictionary<string, List<string>>();

            typesAndNames.Add("Sword", new List<string>() { "Greatsword", "Blade" });
            typesAndNames.Add("Bow", new List<string>() { "Longbow", "Shortbow" });
            typesAndNames.Add("Ring", new List<string>() { "Signet Ring", "Band" });
            typesAndNames.Add("Helmet", new List<string>() { "Halfhelm", "Full Helm" });

            ItemGenerator testGenerator = new ItemGenerator(typesAndNames, "fake", "fake", "fake", "fake");

            Item testItem = testGenerator.getRandomItem(100, Item.Type.SWORD, Item.TypeModifier.TWO_HANDED);

            testLbl.Text = testItem.ToString();
            Refresh();


            Button testButton = testItem.getButton();
            testButton.Location = new Point(100, 100);
            Controls.Add(testButton);
        }
    }
}
