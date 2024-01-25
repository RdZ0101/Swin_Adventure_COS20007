using NUnit.Framework;
using Swin_Adventure;
using System.Collections.Generic;

namespace NunitTest
{
    public class Tests
    {
        IdentifiableObject id;
        IdentifiableObject noId;
        [SetUp]
        public void Setup()
        {
            id = new IdentifiableObject(new string[] { "fred", "bob" });
            noId = new IdentifiableObject(new string[] { });
        }

        [Test]
        public void TestAreYou()
        {
            Assert.IsTrue(id.AreYou("fred"));
            Assert.IsTrue(id.AreYou("bob"));
        }

        [Test]
        public void TestNotAreYou() 
        {
            Assert.IsFalse(id.AreYou("wilma"));
            Assert.IsFalse(id.AreYou("boby"));
        }

        [Test]
        public void TestCaseSensitive()
        {
            id = new IdentifiableObject(new string[] { "fred", "b0b" });

            Assert.IsTrue(id.AreYou("FRED"));
            Assert.IsTrue(id.AreYou("b0B"));

        }

        [Test]
        public void TestFirstID() 
        {
            Assert.That(id.FirstId, Is.EqualTo("fred"));
            Assert.That(noId.FirstId, Is.EqualTo(""));
        }

        [Test]
        public void TestAddID()
        {
            id.AddIdentifier("Wilma");
            Assert.IsTrue(id.AreYou("FRED"));
            Assert.IsTrue(id.AreYou("BOB"));
            Assert.IsTrue(id.AreYou("wilma"));
        }
        
    }

}