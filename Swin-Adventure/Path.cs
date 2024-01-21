using Swin_Adventure;
using System;

public class Path : GameObject
{
    private bool _Isblocked;
    public Location Destination { get; set; }
    public bool Blocked { get; set; }
    public Path(string[] ids, string name, string desc, Location destination) : base(ids, name, desc)
    {
        Destination = destination;
        Blocked = _Isblocked;
    }

    public Path(string[] ids, string name, string desc) : base(ids, name, desc)
    {
    }
}

