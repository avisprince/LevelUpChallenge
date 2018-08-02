using LevelUpChallenge.Solution1;
using LevelUpChallenge.Solution2;
using LevelUpChallenge.Solution2.Countable;
using System;
using System.Threading;

namespace LevelUpChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RunSolution1();
            Console.WriteLine();
            RunSolution2();

            KeepConsoleOpen();
        }

        private static void RunSolution1()
        {
            PrintHeader("Solution 1");

            var obj1 = new ACountableClass();
            var obj2 = new ACountableClass();
            var obj3 = new ASecondCountableClass();
            obj3.Dispose();

            var output = Countable.PrintInstancesCount();
            Console.Write(output);
        }

        private static void RunSolution2()
        {
            PrintHeader("Solution 2");

            var countableInstanceFactory = new CountableInstanceFactory();
            var obj1 = countableInstanceFactory.Create(typeof(CountableClass1));
            var obj2 = countableInstanceFactory.Create(typeof(CountableClass1));
            var obj3 = countableInstanceFactory.Create(typeof(CountableClass2));
            using (var obj4 = countableInstanceFactory.Create(typeof(CountableClass2))) { }
            obj3.Dispose();

            var output = CountableInstanceFactory.PrintInstancesCount();
            Console.Write(output);
        }

        private static void PrintHeader(string text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static void KeepConsoleOpen()
        {
            // Wait for Ctrl+c to kill program
            var resetEvent = new ManualResetEvent(false);

            Console.CancelKeyPress += (sender, eArgs) =>
            {
                resetEvent.Set();
                eArgs.Cancel = true;
            };

            Console.WriteLine();
            Console.WriteLine("Program has finished running. Type Ctrl+c to exit.");

            resetEvent.WaitOne();
        }
    }
}
