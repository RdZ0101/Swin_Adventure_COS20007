using NUnit.Framework;
using Swin_Adventure;


namespace PlayerTests
{
    public class Tests
    {
        private Player _player;
        private Item _weapon;
        private Item _energy;

        [SetUp]
        public void Setup()
        {
            _player = new Player("Tony", "Player 1");

            string[] identsMissile = { "Weapon", "NUKE", "Air Strike" };
            _weapon = new Item(identsMissile, "Nuclear Missile", "Summon this to wipe out anything");

            string[] identsEnergy = { "Energy", "ARCReactor", "Power source" };
            _energy = new Item(identsEnergy, "Reactor", "Can power up any suit of armor");

            _player.Inventory.Put(_weapon);
            _player.Inventory.Put(_energy);
        }

        [Test]
        public void TestPlayerIsIdentifiable()
        {
            Assert.True(_player.AreYou("me"));
            Assert.True(_player.AreYou("inventory"));
        }

        [Test]
        public void TestPlayerLocatesItems()
        {
            Assert.That(_player.Locate("weapon"), Is.SameAs(_weapon));
            Assert.That(_player.Locate("energy"), Is.SameAs(_energy));
        }

        [Test]
        public void TestPlayerLocatesItself()
        {
            Assert.That(_player.Locate("me"), Is.SameAs(_player));
        }

        [Test]
        public void TestPlayerFullDescription() 
        {
            Assert.That(_player.FullDescription, Is.EqualTo("You are Tony Player 1\nYou are Carrying:\n\tNuclear Missile (weapon)\n\tReactor (energy)\n"));

        }
       
    }
}