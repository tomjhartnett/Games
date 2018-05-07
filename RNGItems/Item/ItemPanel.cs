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
     * This class is the panel that displays the tooltip.
     * The only real difference between this and a normal panel is that 
     * this panel checks the mouse position constantly and if it is outside the button, it removes this panel.
     */
    public class ItemPanel : Panel
    {
        private Timer timer;
        private Button button;
        public ItemPanel(Item item, Button b, List<Label> labels)
        {
            button = b;
            //starts invisible to eliminate tearing
            Visible = false;
            AutoSize = true;

            //back color to grey
            BackColor = Color.LightSlateGray;
            int height = 0;
            int maxwidth = 0;
            //go through each label to add to panel
            foreach (Label l in labels)
            {
                Controls.Add(l);
                //increase the total height by the label height
                height += l.Height;
                //if this label's width is greater than the most we've seen so far, set as current max
                if (l.Width > maxwidth)
                    maxwidth = l.Width;
            }

            //set the size based on the labels
            Size = new Size(maxwidth + 10, height + 10);

            //starts our timer to monitor the mouse
            timer = new Timer();
            timer.Interval = 1000 / 90;
            timer.Tick += checkIfEnabled;
            timer.Start();
        }

        //checks to see if the mouse is within the button, if not, make invisible
        private void checkIfEnabled(object sender, EventArgs e)
        {
            bool isIn = false;
            //gets the mouse position relative to the button (0,0 means mouse in top left of button)
            Point position = button.PointToClient(Cursor.Position);

            //sets this location to bottom right of the cursor
            this.Location = new Point(button.Parent.PointToClient(Cursor.Position).X + Cursor.Size.Width, button.Parent.PointToClient(Cursor.Position).Y + Cursor.Size.Height);

            //if the mouse is in the button, set isIn to true
            if (position.X > 0 && position.Y > 0 && position.X < button.Width && position.Y < button.Height)
                isIn = true;

            //take the panel to the front
            BringToFront();

            //set the panel visibility to whether it is in the button
            Visible = isIn;
        }
    }
}
