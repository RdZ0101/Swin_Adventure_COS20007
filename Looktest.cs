using NUnit.Framework;
using Swin_Adventure;

namespace LookCommandTest
{
    public class Looktests
    {
        private LookCommand _lookCommand;
        private Player _player;
        private Bag _bag;
        private Item _weapon;
        private Item _gem;

        [SetUp]
        public void Setup()
        {
            _lookCommand = new LookCommand();
            _player = new Player("Jack", "Player1");
            _bag = new Bag(new[] { "bag" }, "Lv 3 Bag", "Biggest bag");
            _weapon = new Item(new string[] { "Gun", "AK47" }, "a gun", "Most reliable gun");
            _gem = new Item(new string[] { "gem", "GEM" }, "a gem", "This gives free health");
        }

        [Test]
        public void TestLookAtMe()
        {
            _player.Inventory.Put(_weapon);
            string[] command = new[] { "look", "at", "inventory" };
            Assert.That(_lookCommand.Execute(_player, command), Is.EqualTo(_player.FullDescription));
        }

        [Test]
        public void TestLookAtGem()
        {
            _player.Inventory.Put(_gem);
            string[] input = new[] { "look", "at", "gem" };
            Assert.That(_lookCommand.Execute(_player, input), Is.EqualTo(_gem.FullDescription));
        }

        [Test]
        public void TestLookAtUnknown()
        {
            string[] input = new[] { "look", "at", "unknown" };
            Assert.That(_lookCommand.Execute(_player, input), Is.EqualTo("I can't find the unknown.\n"));
        }

        [Test]
        public void TestLookAtGemInMe()
        {
            _player.Inventory.Put(_gem);
            string[] input = new[] { "look", "at", "gem", "in", "inventory" };
            Assert.That(_lookCommand.Execute(_player, input), Is.EqualTo(_gem.FullDescription));
        }

        [Test]
        public void TestLookAtGemInBag()
        {
            _bag.Inventory.Put(_gem);
            _player.Inventory.Put(_bag);
            string[] input = new[] { "look", "at", "gem", "in", "bag" };
            Assert.That(_lookCommand.Execute(_player, input), Is.EqualTo(_gem.FullDescription));
        }

        [Test]
        public void TestLookAtGemInNoBag()
        {
            string[] input = new[] { "look", "at", "gem", "in", "bag" };
            Assert.That(_lookCommand.Execute(_player, input), Is.EqualTo("I cannot find the bag.\n"));
        }

        [Test]
        public void TestLookAtNoGemInBag()
        {
            _player.Inventory.Put(_bag);
            string[] input = new[] { "look", "at", "gem", "in", "bag" };
            Assert.That(_lookCommand.Execute(_player, input), Is.EqualTo("I can't find the gem.\n"));
        }

        [Test]
        public void TestInvalidLook()
        {
            string[] input;

            input = new[] { "look" };
            Assert.That(_lookCommand.Execute(_player, input), Is.EqualTo("I can't find the location.\n"));

            input = new[] { "hello" };
            Assert.That(_lookCommand.Execute(_player, input), Is.EqualTo("I can't find the location.\n"));

            input = new[] { "look", "around" };
            Assert.That(_lookCommand.Execute(_player, input), Is.EqualTo("I don't know how to look like that.\n"));

            input = new[] { "look", "at", "a", "at", "b" };
            Assert.That(_lookCommand.Execute(_player, input), Is.EqualTo("I don't know how to look like that.\n"));

            input = new[] { "look", "at", "item", "inside" };
            Assert.That(_lookCommand.Execute(_player, input), Is.EqualTo("I don't know how to look like that.\n"));

            input = new[] { "look", "at", "item", "inside", "bag" };
            Assert.That(_lookCommand.Execute(_player, input), Is.EqualTo("I don't know how to look like that.\n"));
        }



    }

}
