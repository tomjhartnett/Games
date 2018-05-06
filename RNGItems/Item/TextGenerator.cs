using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RNGItems
{
    //an abstract class that is used by itemclasses to generate the required text for that class of item
    public abstract class TextGenerator
    {
        public abstract string getName();

        public abstract string getText(Item i);

        public abstract Panel getPanel(Item i, Button b);
    }
}
