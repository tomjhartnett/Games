using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RNGItems
{
    public class EmptyItem : PictureBox
    {
        public Item item { get; protected set; }
        public string type { get; protected set; }

        public EmptyItem()
        {
            this.SetAutoSizeMode(AutoSizeMode.GrowAndShrink);
            initItemListeners();
        }

        public EmptyItem(Item Item)
        {
            item = Item;
            this.Image = item.image;
            initItemListeners();
        }

        public virtual bool equipItem(Item Item)
        {
            item = Item;
            this.Image = item.image;
            return true;
        }

        protected void initItemListeners()
        {
            MouseUp += mouseUp;
        }

        private void mouseUp(object sender, MouseEventArgs e)
        {
            foreach (Control c in Form.ActiveForm.Controls)
                if (c.Location == e.Location)
                    if (c.GetType() == typeof(ItemButton))
                        equipItem(((ItemButton)c).item);
        }
    }
}
