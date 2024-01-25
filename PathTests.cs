using Swin_Adventure;
using NUnit.Framework;

namespace PathTest
{
    public class Tests
    {
        private Path _path;
        private Location _location1;
        private Location _location2;
        private Player _player;
        [SetUp]
        public void Setup()
        {
            string[] identsPath = { "north", "n" };
            string[] identsLocation1 = { "ATC" };
            string[] identsLocation2 = { "EN" };
            _location1 = new Location(identsLocation1, "ATC Location", "Advanced Technologies Center");
            _location2 = new Location(identsLocation2, "EN Location", "Engineering Building");
            _path = new Path(identsPath, "North", "North Path", _location2);
            _player = new Player("Tony", "Player 1");
            _location1.AddPath(_path);  
        }

        [Test]
        public void TestPathLocation()
        {
            Location _expected = _location2;
            Location _actual = _path.Destination;
            Assert.That(_actual, Is.EqualTo(_expected));
        }

        [Test] public void TestPathName() 
        {
            string _expected = "North";
            string _actual = _path.Name;
            Assert.That(_actual, Is.EqualTo(_expected));
        }

        [Test] public void TestLocatePath()
        { 
            GameObject _actual = _path;
            Assert.That(_actual, Is.EqualTo(_location1.Locate("north")));
        }
    }
}