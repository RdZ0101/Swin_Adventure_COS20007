using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Swin_Adventure;

namespace Locationtests
{
    public class LocationTest
    {
        private Location _location;
        private Item _weapon;
        private Item _armour;
        private Item _gem;

        [SetUp]
        public void Setup()
        {
            string[] identsLocation = { "ATC" };
            _location = new Location(identsLocation, "ATC Location", "Advanced Technologies Center");

            _armour = new Item(new[] { "Iorn suit" }, "MK42", "Can fly");
            _weapon = new Item(new string[] { "Gun", "AK47" }, "a gun", "Most reliable gun");
            _gem = new Item(new string[] { "gem", "GEM" }, "a gem", "This gives free health");

            _location.Inventory.Put(_weapon);
            _location.Inventory.Put(_armour);
            _location.Inventory.Put(_gem);
        }

        [Test]
        public void TestLocationIsIdentifiable()
        {
            Assert.True(_location.AreYou("ATC"));
        }

        [Test]
        public void TestLocationLocatesItems()
        {
            Assert.That(_location.Locate("Gun"), Is.SameAs(_weapon));
            Assert.That(_location.Locate("Iorn suit"), Is.SameAs(_armour));
            Assert.That(_location.Locate("gem"), Is.SameAs(_gem));
        }

        [Test]
        public void TestLocationLocatesItself()
        {
            Assert.That(_location.Locate("ATC"), Is.SameAs(_location));
        }

        [Test]
        public void TestLocationLocatesNothing()
        {
            Assert.That(_location.Locate("EN"), Is.EqualTo(null));
        }

        [Test]
        public void TestLocationFullDescription()
        {
            string expectedDescription = "You are in ATC Location. Advanced Technologies Center\nYou can see:\n" +"\ta gun (gun)\n" + "\tMK42 (iorn suit)\n" +"\ta gem (gem)\n";

            string actualDescription = _location.FullDescription;

            Assert.That(actualDescription, Is.EqualTo(expectedDescription));
        }



        [Test]
        public void TestLocationName()
        {
            Assert.That(_location.Name, Is.EqualTo("ATC Location"));
        }
    }
}