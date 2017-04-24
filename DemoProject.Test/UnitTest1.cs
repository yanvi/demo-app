using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoProject.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int nemorator = 10;
            int demonator = 5;
            int expected = 3;
            int Actual = nemorator / demonator;
            Assert.AreEqual(expected, Actual);
        }
    }
}
