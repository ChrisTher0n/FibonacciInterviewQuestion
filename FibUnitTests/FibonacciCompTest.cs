using Microsoft.VisualStudio.TestTools.UnitTesting;
using FibonacciSequenceCalculator;

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
            double answer = 0;
            fibClassOnTest = new ComputeFibNumIteratively();
            answer = fibClassOnTest.ComputeFib(25);
            Assert.AreEqual(75025, answer);
        }

        [TestMethod]
        public void ComputeRecursiveTest()
        {
            double answer = 0;
            fibClassOnTest = new ComputeFibNumRecursively();
            answer = fibClassOnTest.ComputeFib(25);
            Assert.AreEqual(75025, answer);
        }

        [TestMethod]
        public void IterativeMinTest()
        {
            double answer = 0;
            fibClassOnTest = new ComputeFibNumIteratively();
            answer = fibClassOnTest.ComputeFib(0);
            Assert.AreEqual(0, answer);
        }

        [TestMethod]
        public void IterativeOneTest()
        {
            double answer = 0;
            fibClassOnTest = new ComputeFibNumIteratively();
            answer = fibClassOnTest.ComputeFib(1);
            Assert.AreEqual(1, answer);
        }

        [TestMethod]
        public void IterativeMaxTest()
        {
            double answer = 0;
            fibClassOnTest = new ComputeFibNumIteratively();
            answer = fibClassOnTest.ComputeFib(1476);
            //Actual 1.3069892237633987E+308
            //Displayed 1.3069892237634E+308
            Assert.AreEqual(1.3069892237633987E+308, answer);
        }

        [TestMethod]
        public void IterativeOverMaxTest()
        {
            double answer = 0;
            fibClassOnTest = new ComputeFibNumIteratively();
            answer = fibClassOnTest.ComputeFib(1477);
            Assert.IsTrue(double.IsPositiveInfinity(answer));
        }
    }
}
