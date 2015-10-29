using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
