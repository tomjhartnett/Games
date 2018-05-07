using RNGItems;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RNGItemsExample1
{
    public partial class MainForm : Form
    {
        private ItemGenerator itemGenerator { get; set; }
        private List<ItemClass> itemClasses { get; set; }
        
        public MainForm()
        {
            InitializeComponent();

            loadItemGenerator();

            initPanels();
        }

        private void initPanels()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            this.KeyDown += keyDown;

            drawInventory();
            drawCharacter();
            drawBattle();
        }

        private void drawCharacter()
        {
            //characterPanel.BackColor = Color.Red;
            characterPanel.Width = Width / 3;
            characterPanel.Height = Height;
            characterPanel.Location = new Point((Width * 2) / 3, 0);

            int starty = 0;
            for(int row = 0; row < 10; row++)
            {
                int startx = 0;
                for (int column = 0; column < 5; column++)
                {
                    Item randomInventoryItem = itemGenerator.getRandomItem(500);
                    Button b = randomInventoryItem.getButton();
                    b.Location = new Point(startx, starty);
                    b.BringToFront();
                    characterPanel.Controls.Add(b);
                    startx += b.Width + 30;
                }
                starty += 60;
            }
            Refresh();
        }

        private void drawBattle()
        {
            fightPanel.BackColor = Color.Black;
            fightPanel.Width = Width / 3;
            fightPanel.Height = Height;
            fightPanel.Location = new Point(0, 0);
        }

        private void drawInventory()
        {
            inventoryPanel.BackColor = Color.Gray;
            inventoryPanel.Width = Width / 3;
            inventoryPanel.Height = Height;
            inventoryPanel.Location = new Point(Width / 3, 0);

            Bitmap emptyImage = new Bitmap(@"..\\..\\empty.png");
        }

        private void loadItemGenerator()
        {
            //generate all qualities
            List<string> qualities = new List<string>() { "Common", "Uncommon", "Rare", "Epic", "Legendary" };
            //generate all standardStats
            List<string> standardStats = new List<string>() { "Strength", "Agility", "Stamina", "Critical Chance", "Dodge" };
            //generate all armorRequiredGiven
            List<string> standardArmorStats = new List<string>() { "Armor" };
            //generate all weaponRequiredGiven
            List<string> standardWeaponStats = new List<string>() { "Min Damage", "Max Damage" };
            //generate all qualities
            List<string> armorTypeModifiers = new List<string>() { "Cloth", "Mail", "Leather", "Plate" };
            Dictionary<string, List<Bitmap>> typesAndImages = ImageLoader.getTypesAndImages(@"..\\..\\Images");
            Dictionary<string, List<Bitmap>> images = ImageLoader.getTypesAndImages(@"..\\..\\Images");
            //generate some random growth formula to test
            StandardStatGrowth growth = new StandardStatGrowth();

            itemClasses = new List<ItemClass>();
            string typeName = "Back";
            ItemClass back = new ItemClass(typeName, new ArmorTextGenerator(getNamesPath(typeName)), armorTypeModifiers, qualities, images[typeName.ToLower()], 
                getMergedStats(new List<List<string>>() { standardStats, standardArmorStats }), 
                getMergedStats(new List<List<string>>() { standardStats, standardArmorStats }), 
                new List<Stat>() { }, 
                getMergedStats(standardArmorStats));
            itemClasses.Add(back);
            itemGenerator = new ItemGenerator(itemClasses);
        }

        //returns the path for the names of that type, based on the default file system
        private string namesPath = @"..\\..\\names\";
        private string getNamesPath(string type)
        {
            return namesPath + type.ToLower() + ".txt";
        }

        //generates a random stat based on our standardStatGrowth formula
        private Stat getRandomStandardGrowthStat(string name)
        {
            return new Stat(name, new StandardStatGrowth());
        }

        //makes list of stats from a list of some string statname lists
        private List<Stat> getMergedStats(List<List<string>> statlists)
        {
            List<Stat> ret = new List<Stat>();

            foreach(List<string> statlist in statlists)
                foreach (string name in statlist)
                    ret.Add(getRandomStandardGrowthStat(name));

            return ret;
        }

        //makes list of stats from a list of some string statname lists
        private List<Stat> getMergedStats(List<string> statlist)
        {
            List<Stat> ret = new List<Stat>();
            
            foreach (string name in statlist)
                ret.Add(getRandomStandardGrowthStat(name));

            return ret;
        }

        //form key down event
        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
