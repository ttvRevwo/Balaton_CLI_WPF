using Microsoft.VisualStudio.TestTools.UnitTesting;
using BalatonCLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalatonCLI.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        [DataRow("A",100,80000)]
        [DataRow("B", 100, 60000)]
        [DataRow("C", 100, 10000)]
        [DataRow("A", 10, 0)]
        public void AdoTest(string adosav, int terulet, int eredmeny)
        {
            Assert.AreEqual(eredmeny, Program.Ado(adosav, terulet));
        }

    }
}