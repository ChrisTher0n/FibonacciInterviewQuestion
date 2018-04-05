using System;

namespace FibonacciSequenceCalculator
{
    /// <summary>
    /// Fibonacci calculation interface
    /// </summary>
    public interface IComputeFib
    {
        /// <summary>
        /// IComputFib interface method
        /// </summary>
        double ComputeFib(int seqNum);
    }

    /// <summary>
    /// Main Recursive Fibonacci calculation class, implements IComputFib interface
    /// </summary>
    public class ComputeFibNumRecursively : IComputeFib
    {
        /// <summary>
        /// Fibonacci calculation using Recursive method
        /// </summary>
        /// <param name="seqNum">Number in Sequence to find</param>
        /// <returns>A double containing requested position in Fibonacci sequence </returns>
        public double ComputeFib(int seqNum)
        {
            if (seqNum <= 1)
                return seqNum;
            return ComputeFib(seqNum - 1) + ComputeFib(seqNum - 2);
        }
    }

    /// <summary>
    /// Main Iterative Fibonacci calculation class, implements IComputFib interface
    /// </summary>
    public class ComputeFibNumIteratively : IComputeFib
    {
        /// <summary>
        /// Fibonacci calculation using Iterative method
        /// </summary>
        /// <param name="seqNum">Number in Sequence to find</param>
        /// <returns>A double containing requested position in Fibonacci sequence </returns>
        public double ComputeFib(int seqNum)
        {
            double firstNum = 0, secondNum = 1, result = 0;

            if (seqNum == 0 || seqNum == 1)
                return seqNum;

            //Loop through sequence to requested number
            for (int i = 2; i <= seqNum; i++)
            {
                result = firstNum + secondNum;
                firstNum = secondNum;
                secondNum = result;
            }

            return result;
        }
    }
}
