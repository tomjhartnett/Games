using RNGItems;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    /*
     * This class is a child of TextGenerator and generates names and text for a Ring itemClass.
     */
    public class RingNameGenerator : TextGenerator
    {
        //use the base class, just modify the names
        public RingNameGenerator(List<string> names) : base(getModifiedNames(names))
        {}

        private static List<string> getModifiedNames(List<string> names)
        {
            names.Add("Band of Might");
            names.Add("Reaver Ring");

            return names;
        }
    }
}
