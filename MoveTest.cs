using NUnit.Framework;
using Swin_Adventure;

namespace MoveTest
{
    public class MoveTest
    {
        private Location _location1;
        private Location _location2;
        private Path _pathToLocation2;
        private Player _player;
        private MoveCommand _moveCommand;

        [SetUp]
        public void SetUp()
        {

            _location1 = new Location(new string[] { "location1" }, "Location 1", "Description 1");
            _location2 = new Location(new string[] { "location2" }, "Location 2", "Description 2");


            _pathToLocation2 = new Path(new string[] { "path1" }, "Path to Location 2", "A path leading to Location 2", _location2);
            _location1.AddPath(_pathToLocation2);

          
            _player = new Player("Player", "Test player");
            _player.Location = _location1;


            _moveCommand = new MoveCommand();
        }

        [Test]
        public void TestValidMove()
        {
            // Test moving from location1 to location2
            string[] command = new string[] { "move", "path1" };
            string result = _moveCommand.Execute(_player, command);
            Assert.That(result, Is.EqualTo("You have moved to Location 2."));
            Assert.That(_player.Location, Is.EqualTo(_location2));
        }

        [Test]
        public void TestInvalidMove()
        {

            string[] command = new string[] { "move", "invalidpath" };
            string result = _moveCommand.Execute(_player, command);
            Assert.That(result, Is.EqualTo("You can't go that way."));
            Assert.That(_player.Location, Is.EqualTo(_location1));
        }
    }
}

