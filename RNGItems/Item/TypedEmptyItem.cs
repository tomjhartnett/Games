using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGItems
{
    public class TypedEmptyItem : EmptyItem
    {
        public string type { get; protected set; }

        public TypedEmptyItem(string Type) : base()
        {
            type = type;
        }

        public TypedEmptyItem(Item i) : base(i)
        {
            type = i.type;
        }

        public override bool equipItem(Item Item)
        {
            if(item.type.Equals(type))
            {
                item = Item;
                return true;
            }

            return false;
        }
    }
}
