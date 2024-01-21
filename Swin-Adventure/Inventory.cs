using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public class Inventory
    {
        private List<Item> _items = new List<Item>();
        public Inventory() { }

        public bool HasItem(string id)
        {
            foreach (Item I in _items)
            {
                if (I.AreYou(id))
                    return true;
            }
            return false;
        }

        public void Put(Item item)
        {
            _items.Add(item);
        }
        public Item Take(string id)
        {
            foreach (Item I in _items)
            {
                if (I.AreYou(id))
                {
                    _items.Remove(I);
                    return I;
                }
            }
            return null;
        }
        public Item Fetch(string id)
        {
            foreach (Item I in _items)
            {
                if (I.AreYou(id))
                {
                    return I;
                }
            }
            return null;
        }
        public string ItemList
        {
            get
            {
                string itemlist = "";
                foreach (Item I in _items)
                {
                    itemlist += $"\t{I.ShortDescription}\n";
                }
                return itemlist;
            }
        }
    }
}
