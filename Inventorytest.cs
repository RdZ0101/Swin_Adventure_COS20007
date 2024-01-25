using NUnit.Framework;
using Swin_Adventure;

namespace InventoryTest
{
    public class Tests
    {
        private Inventory _inventory;
        private Item _item;
        [SetUp]
        public void Setup()
        {
            _inventory = new Inventory();
            string[] idents = { "NUKE" };
            _item = new Item(idents, "Nuclear Missile", "Summon this to wipe out anything");
        }

        [Test]
        public void TestFindItem()
        {
            _inventory.Put(_item);
            Assert.True(_inventory.HasItem("NUKE"));
        }

        [Test]
        public void TestNoItemFind()
        {
            Assert.False(_inventory.HasItem("Hulk"));
        }

        [Test]
        public void TestFetchItem()
        {
            _inventory.Put(_item);
            Assert.AreEqual(_item, _inventory.Fetch("NUKE"));
        }

        [Test]
        public void TestTakeItem()
        {
            _inventory.Put(_item);
            _inventory.Take("NUKE");
            Assert.False(_inventory.HasItem("NUKE"));
        }

        [Test]
        public void TestItemList()
        {
            string[] identsMissile = { "Weapon", "NUKE", "Air Strike" };
            Item weapon = new Item(identsMissile, "Nuclear Missile", "Summon this to wipe out anything");

            string[] identsEnergy = { "Energy", "ARCReactor", "Power source" };
            Item Energy = new Item(identsEnergy, "Reactor", "Can power up any suit of armor");

            _inventory.Put(weapon);
            _inventory.Put(Energy);

            string expected = "\tNuclear Missile (weapon)\n\tReactor (energy)\n";
            Assert.That(_inventory.ItemList, Is.EqualTo(expected));

        }
    }
}