using System;
using System.Numerics;
using System.Diagnostics;
//using System.Threading;
using System.ComponentModel;

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

                //Return type from ComputeFibNum has been set to BigInteger so it could concievably handle infinite digits.
                //But as a design exercise to limiting runtime of program to reasonable amount of time limit has been artificailly set at 5000.
                //User will be prompted to confirm they really need a number calculater with in excess of 1045 digits
                if (requiredNum > 5000) //Max Fibonacci sequence number that can fit in a double
                {
                    Console.WriteLine("You are about to compute a fairly large number and it may take some time to complete. Continue? Y/N");
                    ConsoleKeyInfo input = Console.ReadKey();

                    if (input.Key != ConsoleKey.Y)
                    {
                        return;
                    }    
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

            Console.Write("The {0}{1} Fibonacci sequence number is : {2}", requiredNum, CorrectOrdinal(requiredNum), getSeqNum.TimedComputation());
            //Compute Fib number asynchronously and print it out
            //getSeqNum.TimedComputation();
            Console.ReadKey();
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
        private BackgroundWorker worker = new BackgroundWorker();
        private double timeSpan;

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

        /// <summary>
        /// Inititialization of Backgroundworker
        /// </summary>
        
        /*
        public void InitBackgroundWorker()
        {
            worker.DoWork += new DoWorkEventHandler(WorkerDoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(WorkerCompleted);
        }

        private void WorkerDoWork(object sender, DoWorkEventArgs args)
        {
            args.Result = InternalTimedComputation();
        }

        private void WorkerCompleted(object sender, RunWorkerCompletedEventArgs args)
        {
            Console.Write($"{args.Result}");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Excecution took {timeSpan} milliseconds");
        }

        public void TimedComputation()
        {
            InitBackgroundWorker();
            worker.RunWorkerAsync();
        }

        */

        /// <summary>Simple method using very rudimentary Dependency injection through use of IComputeFib interface insctance being passed in and used.
        /// Also measures the execution time in miliseconds. Useful for algorithm tweaking.
        /// </summary>
        /// <param name="comp">IComputeFib instance to compute seq with</param>
        /// <param name="seqNum">Number in Sequence to find</param>
        /// <returns>A double containing requested position in Fibonacci sequence </returns>
        //private UInt64 InternalTimedComputation()

        public BigInteger TimedComputation()
        {
            BigInteger fibNum = 0;
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
            timeSpan = sw.Elapsed.TotalMilliseconds;

            return fibNum;
        }
    }
}



