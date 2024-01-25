using NUnit.Framework;
using Swin_Adventure;

namespace BagTest
{
    public class Bagtest
    {
        private Bag _bag;
        private Bag _bagInAbag;
        private Item _weapon;
        private Item _suit;

        [SetUp]
        public void Setup()
        {
            string[] idents = new[] { "DuffleBag", "Sidebag" };
            _bag = new Bag (idents, "Gym Bag", "And bank robberies");

            string[] identsbagInAbag = new[] { "School backpack"};
            _bagInAbag = new Bag(identsbagInAbag, "Built for daily use", "Durable");

            string[] identsBomb = new[] { "Weapon", "C4", "Bomb" };
            _weapon = new Item(identsBomb, "Explosive", "Blasts through anything");

            string[] identsArmor = new[] { "Suit of armor", "Mark 42" };
            _suit = new Item(identsArmor, "Mark 42 suit", "Best available armor");

        }

        [Test]
        public void TestBagLocatesItems()
        {
            _bag.Inventory.Put(_weapon);
            _bag.Inventory.Put(_suit);

            Assert.AreSame(_weapon, _bag.Locate("weapon"));
            Assert.AreSame(_suit, _bag.Locate("suit of armor"));

        }

        [Test]
        public void TestBagLocatesNothing()
        {
            Assert.AreSame(null,_bag.Locate("fail"));
        }

        [Test]
        public void TestGetBagLocatesItself()
        {
            Assert.AreSame(_bag, _bag.Locate("DuffleBag"));
            Assert.AreSame(_bag, _bag.Locate("Sidebag"));
        }

        [Test]
        public void TestBagFullDescription()
        {
            _bag.Inventory.Put(_weapon);
            _bag.Inventory.Put(_suit);

            Assert.AreEqual($"In the Gym Bag you can see:\n\tExplosive (weapon)\n\tMark 42 suit (suit of armor)\n",_bag.FullDescription);
        }

        [Test]
        public void TestGetBagInBag() 
        {
            _bag.Inventory.Put(_bagInAbag);
            _bagInAbag.Inventory.Put(_weapon);

            Assert.AreSame(_bagInAbag, _bagInAbag.Locate("School backpack"));
            Assert.AreSame(_weapon, _bagInAbag.Locate("C4"));
            Assert.AreSame(null, _bag.Locate("C4"));
        }
    }
}