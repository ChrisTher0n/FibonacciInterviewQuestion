Fibonacci Sequence calculation application by Chris Theron

The original development brief was:
    //Write a C# application that returns the nth number in the Fibonacci sequence. 
    //The application should be zipped up and sent to us for review. 
    //It’s up to the candidate how sophisticated the implementation should be.
	
I tried to fulfill the brief in the simplest way possible, but still showing at least some of the skills I've built up over the years.

The program is split up int a library that does the actual calculations, and a console application handling the user input.
It was developed in VS Community 2017 using .NET Core 2.0.

The application can be run in 2 different ways:
1) Running the app for the FibProgram directory e.g. dotnet run
   This enables the normal mode where the application prompts the user for input, calculates the relevant position in the sequence and print the result.
	
2) The second mode is to simply specify the sequence position on the command line e.g dotnet run 23

In both modes input should be handled gracefully, and in both a monitoring system times the execution times of the calculation and prints it with the answer.
It'll also guide user if errors are made on input and even print out correct ordinals in output. Useless but nice!

The FibonacciComp library has 2 ways of calculation the sequence: via recursion and via iteration.
Basic implementations for the two methods showed that iteration, even with a naive/simple algorithm is orders of magnitude faster.
This can be seen while running the unit test which will test both methods and print out the runtimes.
A simple interface is used to enable a Dependency injection (rudimentary but functional) in the test application.

All classes and methods are documented in the code and will generate XML docs and tooltips.

Thank you for this opportunity.

