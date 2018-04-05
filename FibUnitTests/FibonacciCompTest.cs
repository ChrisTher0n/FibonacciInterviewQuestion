using Microsoft.VisualStudio.TestTools.UnitTesting;
using FibonacciSequenceCalculator;
using System;
using System.Numerics;

namespace FibUnitTests
{
    [TestClass]
    public class FibonacciCompTest
    {
        IComputeFib fibClassOnTest;

        [TestMethod]
        public void InstanciateIterTest()
        {
            fibClassOnTest = new ComputeFibNumIteratively();
            Assert.IsNotNull(fibClassOnTest);
        }

        [TestMethod]
        public void ComputeIterativeTest()
        {
            BigInteger answer = 0;
            fibClassOnTest = new ComputeFibNumIteratively();
            answer = fibClassOnTest.ComputeFib(25);
            Assert.AreEqual((UInt64)75025, answer);
        }

        [TestMethod]
        public void ComputeRecursiveTest()
        {
            BigInteger answer = 0;
            fibClassOnTest = new ComputeFibNumRecursively();
            answer = fibClassOnTest.ComputeFib(25);
            Assert.AreEqual((UInt64)75025, answer);
        }

        [TestMethod]
        public void IterativeMinTest()
        {
            BigInteger answer = 0;
            fibClassOnTest = new ComputeFibNumIteratively();
            answer = fibClassOnTest.ComputeFib(0);
            Assert.AreEqual((UInt64)0, answer);
        }

        [TestMethod]
        public void IterativeOneTest()
        {
            BigInteger answer = 0;
            fibClassOnTest = new ComputeFibNumIteratively();
            answer = fibClassOnTest.ComputeFib(1);

            Assert.AreEqual((UInt64)1, answer);
        }

        [TestMethod]
        public void IterativeMaxTest()
        {
            BigInteger answer = 0;
            fibClassOnTest = new ComputeFibNumIteratively();
            answer = fibClassOnTest.ComputeFib(1476);
            //Actual 1.3069892237633987E+308
            //Displayed 1.3069892237634E+308
            Assert.AreEqual(1.3069892237633987E+308, answer);
        }

        /*
        [TestMethod]
        public void IterativeOverMaxTest()
        {6
            ulong answer = 0;
            fibClassOnTest = new ComputeFibNumIteratively();
            answer = fibClassOnTest.ComputeFib(1477);
            Assert.IsTrue(UInt64.MaxValue
                .IsPositiveInfinity(answer));
        }
        */
    }
}
