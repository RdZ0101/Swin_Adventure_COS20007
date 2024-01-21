using Swin_Adventure;
using System.Collections.Generic;
using System.Xml.Linq;

public class Location : GameObject, IHaveInventory
{
    private Inventory items;
    private List<Path> paths;

    public Location(string[] ids, string name, string desc) : base(ids, name, desc)
    {
        items = new Inventory();
        paths = new List<Path>();
    }

    public Path GetPath(string pathIdentifier)
    {
        return paths.Find(path => path.AreYou(pathIdentifier));
    }

    public void AddPath(Path path)
    {
        paths.Add(path);
    }

    public override string FullDescription
    {
        get
        {
            return $"You are in {Name}. {base.FullDescription}\nYou can see:\n{items.ItemList}";
        }
    }

    public Inventory Inventory { get { return items; } }

    // Modify the Locate method to check for paths as well
    public GameObject Locate(string id)
    {
        if (AreYou(id))
        {
            return this;
        }

        // Check for items in the location
        GameObject item = items.Fetch(id);
        if (item != null)
        {
            return item;
        }

        // Check for paths
        Path path = GetPath(id);
        if (path != null)
        {
            return path;
        }

        return null;
    }
}
