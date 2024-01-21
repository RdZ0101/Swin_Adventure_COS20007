using System;

namespace Swin_Adventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            string itemToFind;
            IHaveInventory container;

            if (text.Length == 1)
            {
                container = p;
                itemToFind = "location";
            }
            else if (text.Length == 3 && text[1] == "at")
            {
                container = p;
                itemToFind = text[2];
            }
            else if (text.Length == 5 && text[3] == "in")
            {
                container = FetchContainer(p, text[4]);
                if (container == null)
                {
                    return $"I cannot find the {text[4]}.\n";
                }
                itemToFind = text[2];
            }
            else
            {
                return "I don't know how to look like that.\n";
            }

            return LookAtIn(itemToFind, container);
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            if (p.AreYou(containerId))
            {
                return p;
            }
            return p.Locate(containerId) as IHaveInventory;
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            GameObject obj = container.Locate(thingId);
            if (obj != null)
            {
                return obj.FullDescription;
            }
            return $"I can't find the {thingId}.\n";
        }
    }
}
