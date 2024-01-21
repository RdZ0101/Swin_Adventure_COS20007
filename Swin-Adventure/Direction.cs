using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public abstract class Direction
    {
        public string Identifier { get; }
        public string Name { get; }

        public Direction(string identifier, string name)
        {
            Identifier = identifier;
            Name = name;
        }
    }


}
