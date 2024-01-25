using NUnit.Framework;
using Swin_Adventure;

namespace CommandProcessorTests
{
    public class CommandProcessorTests
    {
        private CommandProcessor commandProcessor;
        private Player player;
        private Location location1;
        private Location location2;

        [SetUp]
        public void Setup()
        {
            commandProcessor = new CommandProcessor();
            player = new Player("John", "Adventurer");

            location1 = new Location(new string[] { "location1" }, "Location 1", "Description 1");
            location2 = new Location(new string[] { "location2" }, "Location 2", "Description 2");

            Path pathToLocation2 = new Path(new string[] { "path1" }, "Path to Location 2", "A path leading to Location 2", location2);
            location1.AddPath(pathToLocation2);
            player.Location = location1;

            MoveCommand moveCommand = new MoveCommand();
            commandProcessor.AddCommand(moveCommand);

            LookCommand lookCommand = new LookCommand();
            commandProcessor.AddCommand(lookCommand);
        }


        [Test]
        public void ProcessCommand_LookCommand()
        {
            string result = commandProcessor.ProcessCommand(player, new string[] { "look", "at", "location1" });

            string expectedDescription = "You are in Location 1. Description 1\nYou can see:\n";


            Assert.That(result, Is.EqualTo(expectedDescription));
        }



        [Test]
        public void ProcessCommand_MoveCommand_ValidPath()
        {
            string result = commandProcessor.ProcessCommand(player, new string[] { "move", "path1" });

            Assert.That(result, Is.EqualTo("You have moved to Location 2."));
            Assert.That(player.Location, Is.EqualTo(location2));
        }

        [Test]
        public void ProcessCommand_MoveCommand_InvalidPath()
        {
            string result = commandProcessor.ProcessCommand(player, new string[] { "move", "invalidpath" });

            Assert.That(result, Is.EqualTo("You can't go that way."));
            Assert.That(player.Location, Is.EqualTo(location1));
        }
    }
}
