using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsAppUnitTestDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsAppUnitTestDB.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void CountNWOrderTest()
        {
            long expected = 3;

            long actual = Program.CountNWOrder(10248);

            Assert.AreEqual(expected, actual);
        }
    }
}