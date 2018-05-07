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
        private List<TypeClass> typeClasses { get; set; }
        
        public MainForm()
        {
            InitializeComponent();

            loadItemGenerator();

            Resize += form_resize;
            this.KeyDown += keyDown;

            initPanels();
        }

        private void form_resize(object sender, EventArgs e)
        {
            drawPanels();
        }
        
        private void drawPanels()
        {
            drawInventory();
            drawCharacter();
            drawBattle();
            Refresh();
        }

        private void initPanels()
        {
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;


            initInventory();
            initCharacter();
            initBattle();
            Refresh();
        }

        private void initCharacter()
        {
            if(!Controls.Contains(characterPanel))
                Controls.Add(characterPanel);
            characterPanel.BackColor = Color.Gray;
            drawCharacter();
        }

        private void drawCharacter()
        {
            characterPanel.Controls.Clear();
            characterPanel.Height = Height;
            characterPanel.Width = Width / 3;
            characterPanel.Location = new Point(inventoryPanel.Location.X + inventoryPanel.Width, 0);
        }

        private void initBattle()
        {
            if (!Controls.Contains(battlePanel))
                Controls.Add(battlePanel);
            battlePanel.BackColor = Color.Black;

            drawBattle();
        }

        private void drawBattle()
        {
            battlePanel.Width = Width / 3;
            battlePanel.Height = Height;
            battlePanel.Location = new Point(0, 0);
            battlePanel.Controls.Clear();
            int starty = 0;
            for (int row = 0; row < 10; row++)
            {
                int startx = 0;
                for (int column = 0; column < 5; column++)
                {
                    Item randomInventoryItem = itemGenerator.getRandomItem(500);
                    Button b = randomInventoryItem.getButton();
                    b.Location = new Point(startx, starty);
                    b.BringToFront();
                    battlePanel.Controls.Add(b);
                    startx += b.Width + 30;
                }
                starty += 60;
            }
        }

        private void initInventory()
        {
            if (!Controls.Contains(inventoryPanel))
                Controls.Add(inventoryPanel);
            inventoryPanel.BackColor = Color.Gray;

            Bitmap emptyImage = new Bitmap(@"..\\..\\empty.png");

            drawInventory();
        }

        private void drawInventory()
        {
            inventoryPanel.Width = Width - (battlePanel.Width + characterPanel.Width);
            inventoryPanel.Height = Height;
            inventoryPanel.Location = new Point(battlePanel.Location.X + battlePanel.Width, 0);
            inventoryPanel.Controls.Clear();
        }

        //load and populate the item generator
        private void loadItemGenerator()
        {
            //generate all qualities
            List<string> qualities = new List<string>() { "Common", "Uncommon", "Rare", "Epic", "Legendary" };
            //generate all standardStats
            List<string> standardStats = new List<string>() { "Strength", "Agility", "Stamina", "Critical Chance", "Dodge" };
            //generate all armorRequiredGiven
            List<string> standardArmorStats = new List<string>() { "Armor" };
            //generate all weaponRequiredGiven
            List<string> standardWeaponStats = new List<string>() { "Mindamage", "Maxdamage" };
            //generate all qualities
            List<string> armorTypeModifiers = new List<string>() { "Cloth", "Mail", "Leather", "Plate" };
            List<string> weaponTypeModifiers = new List<string>() { "One-handed", "Two-handed", "Thrown" };
            List<string> trinketTypeModifiers = new List<string>() { "Ring", "Necklace", "Trinket" };
            Dictionary<string, List<Bitmap>> typesAndImages = ImageLoader.getTypesAndImages(@"..\\..\\Images");
            Dictionary<string, List<Bitmap>> images = ImageLoader.getTypesAndImages(@"..\\..\\Images");
            //generate some random growth formula to test
            StandardStatGrowth growth = new StandardStatGrowth();

            //make the common item classes
            ItemClass armor = new ItemClass(armorTypeModifiers, qualities,
                getMergedStats(new List<List<string>>() { standardStats, standardArmorStats }),
                getMergedStats(new List<List<string>>() { standardStats, standardArmorStats }),
                getMergedStats(new List<List<string>>() { }),
                getMergedStats(new List<List<string>>() { standardArmorStats }));
            ItemClass weapon = new ItemClass(weaponTypeModifiers, qualities,
                getMergedStats(new List<List<string>>() { standardStats }),
                getMergedStats(new List<List<string>>() { standardStats }),
                getMergedStats(new List<List<string>>() { }),
                getMergedStats(new List<List<string>>() { standardWeaponStats }));
            ItemClass trinket = new ItemClass(trinketTypeModifiers, qualities,
                getMergedStats(new List<List<string>>() { standardStats }),
                getMergedStats(new List<List<string>>() { standardStats, standardWeaponStats, standardArmorStats }),
                getMergedStats(new List<List<string>>() { }),
                getMergedStats(new List<List<string>>() { }));

            typeClasses = new List<TypeClass>();

            //make armors
            string typeName = "Cloak";
            TypeClass cloak = new TypeClass(typeName, new ArmorTextGenerator(getNamesPath(typeName)), images[typeName.ToLower()], armor);
            typeClasses.Add(cloak);

            typeName = "Chest";
            TypeClass chest = new TypeClass(typeName, new ArmorTextGenerator(getNamesPath(typeName)), images[typeName.ToLower()], armor);
            typeClasses.Add(chest);

            typeName = "Boots";
            TypeClass boots = new TypeClass(typeName, new ArmorTextGenerator(getNamesPath(typeName)), images[typeName.ToLower()], armor);
            typeClasses.Add(boots);

            typeName = "Gloves";
            TypeClass gloves = new TypeClass(typeName, new ArmorTextGenerator(getNamesPath(typeName)), images[typeName.ToLower()], armor);
            typeClasses.Add(gloves);

            typeName = "Helmet";
            TypeClass helmet = new TypeClass(typeName, new ArmorTextGenerator(getNamesPath(typeName)), images[typeName.ToLower()], armor);
            typeClasses.Add(helmet);

            typeName = "Legs";
            TypeClass legs = new TypeClass(typeName, new ArmorTextGenerator(getNamesPath(typeName)), images[typeName.ToLower()], armor);
            typeClasses.Add(legs);

            typeName = "Shoulder";
            TypeClass shoulder = new TypeClass(typeName, new ArmorTextGenerator(getNamesPath(typeName)), images[typeName.ToLower()], armor);
            typeClasses.Add(shoulder);

            typeName = "Belt";
            TypeClass belt = new TypeClass(typeName, new ArmorTextGenerator(getNamesPath(typeName)), images[typeName.ToLower()], armor);
            typeClasses.Add(belt);

            typeName = "Wrist";
            TypeClass wrist = new TypeClass(typeName, new ArmorTextGenerator(getNamesPath(typeName)), images[typeName.ToLower()], armor);
            typeClasses.Add(wrist);

            typeName = "Ring";
            TypeClass ring = new TypeClass(typeName, new TextGenerator(getNamesPath(typeName)), images[typeName.ToLower()], trinket);
            typeClasses.Add(ring);

            typeName = "Amulet";
            TypeClass amulet = new TypeClass(typeName, new TextGenerator(getNamesPath(typeName)), images[typeName.ToLower()], trinket);
            typeClasses.Add(amulet);

            typeName = "Trinket";
            TypeClass trink = new TypeClass(typeName, new TextGenerator(getNamesPath(typeName)), images[typeName.ToLower()], trinket);
            typeClasses.Add(trink);

            typeName = "Sword";
            TypeClass sword = new TypeClass(typeName, new WeaponTextGenerator(getNamesPath(typeName)), images[typeName.ToLower()], weapon);
            typeClasses.Add(sword);

            typeName = "Shield";
            TypeClass shield = new TypeClass(typeName, new ArmorTextGenerator(getNamesPath(typeName)), images[typeName.ToLower()], armor);
            typeClasses.Add(shield);

            typeName = "Mace";
            TypeClass mace = new TypeClass(typeName, new WeaponTextGenerator(getNamesPath(typeName)), images[typeName.ToLower()], weapon);
            typeClasses.Add(mace);

            typeName = "Axe";
            TypeClass axe = new TypeClass(typeName, new WeaponTextGenerator(getNamesPath(typeName)), images[typeName.ToLower()], weapon);
            typeClasses.Add(axe);

            typeName = "Dagger";
            TypeClass dagger = new TypeClass(typeName, new WeaponTextGenerator(getNamesPath(typeName)), images[typeName.ToLower()], weapon);
            typeClasses.Add(dagger);

            typeName = "Staff";
            TypeClass staff = new TypeClass(typeName, new WeaponTextGenerator(getNamesPath(typeName)), images[typeName.ToLower()], weapon);
            typeClasses.Add(staff);

            itemGenerator = new ItemGenerator(typeClasses);
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
