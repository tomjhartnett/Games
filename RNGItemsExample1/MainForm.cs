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
            characterPanel.BackColor = Color.LightGray;
            characterPanel.Width = Width / 3;
            characterPanel.Height = Height;
            characterPanel.Location = new Point((Width * 2) / 3, 0);
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
            Dictionary<string, List<Bitmap>> typesAndImages = ImageLoader.getTypesAndImages(@"..\\..\\Images");

            List<ItemClass> itemClasses = new List<ItemClass>();
            ItemClass back = new ItemClass("back");
            itemClasses.Add(back);
            itemGenerator = new ItemGenerator(itemClasses);
        }

        //form key down event
        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
