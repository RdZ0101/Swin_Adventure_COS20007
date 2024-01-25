using NUnit.Framework;
using Swin_Adventure;


namespace ItemTest
{
    public class Tests
    {
        private Item _TestItem;
        private string[] idents = new[] { "Mark42", "The Prodigal Son"}; 
        [SetUp]
        public void Setup()
        {
            _TestItem = new Item(idents, "Mark42", "Mk 42 was the latest suit of armor built");

        }

        [Test]
        public void TestItemIsIdentifiable()
        {
            Assert.True(_TestItem.AreYou(id: "Mark42"));
        }

        [Test]
        public void TestShortDescription()
        {
            Assert.That(_TestItem.ShortDescription, Is.EqualTo("Mark42 (mark42)"));
        }

        [Test]
        public void TestLongDescription()
        {
            Assert.That(_TestItem.FullDescription, Is.EqualTo("Mk 42 was the latest suit of armor built"));
        }
    }
}