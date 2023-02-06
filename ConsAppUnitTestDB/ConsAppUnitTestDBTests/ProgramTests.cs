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
        public void CountCMFTest()
        {
            long expected = 9;
            long actual = Program.CountCMF("11000051");
    
            Assert.AreEqual(expected,actual);
        }
    }
}