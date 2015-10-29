using NUnit.Framework;

namespace NHibernateTest.Tests
{
    [TestFixture]
    public class HelloWorld
    {
        [Test]
        public void Sample()
        {
            string text = "Hello world!";
            Assert.AreEqual("Hello world!", text);
        }
    }
}