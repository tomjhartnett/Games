using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RNGItems
{
    /*
     * This class is meant to be a button attached to an item.
     * When the mouse is hovered over it, it also displays a panel.
     */ 
    public class ItemButton : Button
    {
        //item associated with this button
        public Item item { get; private set; }
        private bool panelCreated = false;

        //takes a button
        public ItemButton(Item i) : base()
        {
            item = i;
            Text = "hello";

            MouseEnter += mouseEnter;
        }

        //adds the panel when the mouse first enters
        private void mouseEnter(object sender, EventArgs e)
        {
            if(!panelCreated)
                Parent.Controls.Add(item.getPanel(this));
            panelCreated = true;
        }
    }
}
