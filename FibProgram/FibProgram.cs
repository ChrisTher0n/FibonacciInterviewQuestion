using System;
using System.Diagnostics;

namespace FibonacciSequenceCalculator
{
    //TASK:
    //Write a C# application that returns the nth number in the Fibonacci sequence. 
    //It’s up to the candidate how sophisticated the implementation should be.”
    //Developer: Christiaan Theron

    class FibProgram
    {
        static void Main(string[] args)
        {
            int requiredNum = 0;

            if (args.Length == 0)
            {
                Console.WriteLine("To which number in the Fibonacci sequence should we compute? ");
                //Handle user input gracefully
                if (!Int32.TryParse(Console.ReadLine(), out requiredNum))
                {
                    //Handle input error
                    Console.WriteLine("Please type only numbers when prompted");
                    Console.WriteLine("Or alternatively add the required sequence number as command line argument e.g : dotnet run 7");
                    return;
                }

                //Return type from ComputeFibNum has been arbitrarily set to double as a design exercise in limiting program scale and complexity
                if (requiredNum > 1476) //Max Fibonacci sequence number that can fit in a double
                {
                    Console.WriteLine("Please select sequence number smaller than 1476. Output will exceed size of Double ");
                    return;
                }

            }
            else
            {
                //Required number was entered on command line as argument
                //Handle user input gracefully
                if (!Int32.TryParse(args[0], out requiredNum))
                {
                    Console.WriteLine("Please add the required sequence number correctly as command line argument e.g : dotnet run 7");
                    return;
                }
            }

            Console.WriteLine("Computing to {0}{1} number in Fibonacci sequence", requiredNum, CorrectOrdinal(requiredNum));

            //Do it iteratively...much faster
            IComputeFib compFibIter = new ComputeFibNumIteratively();
            TimedComp getSeqNum = new TimedComp(compFibIter, requiredNum);
            
            //Execute main task
            Console.WriteLine("The {0}{1} Fibonacci sequence number is : {2}", requiredNum, CorrectOrdinal(requiredNum), getSeqNum.TimedComputation());
            Console.ReadLine();
        }

        /// <summary>
        /// Simple helper method to get corrrect ordinal for sequence number console text
        /// </summary>
        /// <param name="seqNum">Number in Sequence to find</param>
        /// <returns>Correct ordinal based on last digit of required number in sequence</returns>
        static string CorrectOrdinal(int seqNum)
        {
            int lastDigit = seqNum % 10;
            if (lastDigit == 1)
                return "st";
            else if (lastDigit == 2)
                return "nd";
            else if (lastDigit == 3)
                return "rd";
            else
                return "th";

        }
    }

    class TimedComp
    {
        
        private int sequenceNum;
        private IComputeFib timedCompute;
        
        /// <summary>
        /// Public constructor for TimedComp class
        /// </summary>
        /// <param name="comp">IComputeFib instance to compute seq with</param>
        /// <param name="seqNum">Number in Sequence to find</param>
        public TimedComp(IComputeFib comp, int seqNum)
        {
            timedCompute = comp;
            sequenceNum = seqNum;
        }

        

        /// <summary>Simple method using very rudimentary Dependency injection (Yes I realise this is complete overkill...but I mean...a Fibonacci sequence...I had to throw SOMETHING in here.)
        /// Also measures the execution time in miliseconds. Useful for algorithm tweaking.
        /// </summary>
        /// <param name="comp">IComputeFib instance to compute seq with</param>
        /// <param name="seqNum">Number in Sequence to find</param>
        /// <returns>A double containing requested position in Fibonacci sequence </returns>
        public double TimedComputation()
        {
            double fibNum = 0;
            //For monitoring execution times
            Stopwatch sw = Stopwatch.StartNew();

            //Use ICompFib class to compute number
            try
            {
                fibNum = timedCompute.ComputeFib(sequenceNum);
            }
            catch (Exception computeException)
            {
                //We could dive into computeException.Message and log it etc...but I'm not going to to that for brevity's sake
                throw new ApplicationException("A general error occurred while trying to compute Fibonacci sequence",computeException);
            }
            
            sw.Stop();
            Console.WriteLine();
            Console.WriteLine("Excecution took {0} milliseconds", sw.Elapsed.TotalMilliseconds);

            return fibNum;
        }
    }
}



