using System;
using Swin_Adventure;

namespace Swin_Adventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Swin Adventure..");
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your player description: ");
            string description = Console.ReadLine();
            Player player = new Player(name, description);

            string[] identsGun = { "Weapon", "AK47", "Rifle" };
            Item weapon = new Item(identsGun, "AK47 rifle", "Accurate to 800m");

            string[] identsMedKit = { "MediKit", "Lv3 Health", "Medi pack" };
            Item medkit = new Item(identsMedKit, "Level 3 Health pack", "FirstAid kit");

            player.Inventory.Put(weapon);
            player.Inventory.Put(medkit);

            string[] identsBag = new[] { "bag", "backpack" };
            Bag bag = new Bag(identsBag, "Level 3 Backpack", "Standard army bag");
            player.Inventory.Put(bag);

            string[] identsGem = { "Gem", "Object", "Gives invincibility" };
            Item gem = new Item(identsGem, "Blue diamond", "Gives 5 seconds of invincibility");
            bag.Inventory.Put(gem);

            string[] identsLocation = { "EN" };
            Location location1 = new Location(identsLocation, "EN", "Engineering Building");

            string[] identsBomb = { "Bomb", "Explosive", "Weapon" };
            Item bomb = new Item(identsBomb, "Bomb", "Explosive device");

            // Create "ATC" location
            string[] identsAtc = { "ATC" };
            Location location2 = new Location(identsAtc, "ATC", "Advanced Technologies Center");

            // Add the bomb to the "ATC" location
            location2.Inventory.Put(bomb);

            // Create a path between the locations
            Path pathToAtc = new Path(new string[] { "path1" }, "Path to ATC", "A path leading to ATC", location2);
            location1.AddPath(pathToAtc);

            // Set the player's initial location
            player.Location = location1;

            CommandProcessor commandProcessor = new CommandProcessor();
            commandProcessor.AddCommand(new LookCommand());
            commandProcessor.AddCommand(new MoveCommand());

            Console.WriteLine("Type 'Q' to exit");
            string[] commandList = new[] { "" };

            while (commandList[0] != "Q")
            {
                Console.Write("Command -> ");
                string choice = Console.ReadLine();
                commandList = choice.Split(' ');

                string result = commandProcessor.ProcessCommand(player, commandList);
                Console.WriteLine(result);
            }
        }
    }
}
