using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _location;

        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            GameObject obj = _inventory.Fetch(id);
            if (obj != null)
            {
                return obj;
            }
            if (_location != null)
            {
                obj = _location.Locate(id);
                if (obj != null)
                {
                    return obj;
                }
            }
            else
                return null;
            return _inventory.Fetch(id);
            
        }


        public override string FullDescription
        {
            get
            {
                return $"You are {this.Name} {base.FullDescription}\nYou are Carrying:\n{_inventory.ItemList}";
            }
        }
        public Inventory Inventory { get { return _inventory; } }

        public Location Location
        {
            get
            { return _location; }
            set
            { _location = value; }
        }

        public string InventoryDescription => throw new NotImplementedException();
    }
}
