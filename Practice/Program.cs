using System;
using System.Collections.Generic;

namespace EnumeratorHandsOnQuiz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HANDS-ON C# ENUMERATOR QUIZ");
            Console.WriteLine("============================");
            Console.WriteLine("Complete each challenge by writing the missing code.");
            Console.WriteLine("Run the program to verify your solutions.\n");

            Challenge1();
            Challenge2();
            Challenge3();
            Challenge4();
            Challenge5();

            Console.WriteLine("\nQuiz completed! Check your console output against expected results.");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        // CHALLENGE 1: Basic Enumerator Usage
        // Fill in the missing code to manually enumerate through a collection
        static void Challenge1()
        {
            Console.WriteLine("CHALLENGE 1: Manual Enumeration");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Task: Use manual enumerator to print each book with its position");
            Console.WriteLine("Expected output: 'Position 0: Dune', 'Position 1: 1984', 'Position 2: Holes'");

            var books = new List<string> { "Dune", "1984", "Holes" };
            
            // TODO: Create an enumerator from the books collection
            // var enumerator = ???

            // TODO: Use a while loop with MoveNext() to iterate
            // Print each book with format "Position X: BookName"
            // Don't forget proper disposal!

            /* YOUR CODE HERE */
            using (var enumerator = books.GetEnumerator())
            {
                int position = 0;
                while (enumerator.MoveNext())
                {
                    Console.WriteLine($"Position {position}: {enumerator.Current}");
                    position++;
                }
            }
            /* END YOUR CODE */

            Console.WriteLine();
        }

        // CHALLENGE 2: Exception Handling
        // Fix the buggy code that misuses the enumerator
        static void Challenge2()
        {
            Console.WriteLine("CHALLENGE 2: Fix the Bugs");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Task: Fix the code below - it has enumerator usage bugs");

            var numbers = new List<int> { 10, 20, 30 };

            // BUGGY CODE - Fix the issues
            Console.WriteLine("Attempting to fix buggy enumerator code...");
            
            /* BUGGY CODE - UNCOMMENT AND FIX:
            var enumerator = numbers.GetEnumerator();
            
            // Bug 1: Accessing Current before MoveNext
            Console.WriteLine("First number: " + enumerator.Current);
            
            // Bug 2: Not using proper resource management
            while (enumerator.MoveNext())
            {
                Console.WriteLine("Number: " + enumerator.Current);
            }
            // Bug 3: No disposal
            */

            // FIXED CODE:
            using (var enumerator = numbers.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Console.WriteLine("Number: " + enumerator.Current);
                }
            }

            Console.WriteLine();
        }

        // CHALLENGE 3: Comparison with foreach
        // Write equivalent manual enumerator code for a foreach loop
        static void Challenge3()
        {
            Console.WriteLine("CHALLENGE 3: foreach Equivalence");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Task: Write manual enumerator code equivalent to this foreach:");
            Console.WriteLine("foreach (string name in names) { Console.WriteLine($\"Hello, {name}!\"); }");

            var names = new List<string> { "Alice", "Bob", "Charlie" };

            Console.WriteLine("\nOriginal foreach output:");
            foreach (string name in names)
            {
                Console.WriteLine($"Hello, {name}!");
            }

            Console.WriteLine("\nYour manual enumerator equivalent:");
            
            // TODO: Write manual enumerator code that produces identical output
            /* YOUR CODE HERE */
            using (var enumerator = names.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Console.WriteLine($"Hello, {enumerator.Current}!");
                }
            }
            /* END YOUR CODE */

            Console.WriteLine();
        }

        // CHALLENGE 4: Advanced - Custom Enumerable Class
        // Complete the implementation of a custom enumerable class
        static void Challenge4()
        {
            Console.WriteLine("CHALLENGE 4: Custom Enumerable");
            Console.WriteLine("------------------------------");
            Console.WriteLine("Task: Complete the SimpleBookCollection class implementation");

            var bookCollection = new SimpleBookCollection();
            bookCollection.AddBook("Foundation");
            bookCollection.AddBook("Ender's Game");

            Console.WriteLine("Testing custom enumerable with foreach:");
            foreach (string book in bookCollection)
            {
                Console.WriteLine($"Book: {book}");
            }

            Console.WriteLine("Testing custom enumerable with manual enumerator:");
            using (var enumerator = bookCollection.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Console.WriteLine($"Manual: {enumerator.Current}");
                }
            }

            Console.WriteLine();
        }

        // CHALLENGE 5: Performance and Memory
        // Identify and fix performance issues with multiple enumeration
        static void Challenge5()
        {
            Console.WriteLine("CHALLENGE 5: Performance Optimization");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Task: Fix the performance issue in this code");

            var expensiveData = GetExpensiveData();

            // PERFORMANCE PROBLEM - This enumerates multiple times
            Console.WriteLine("Problematic code (enumerates multiple times):");
            Console.WriteLine($"Count: {expensiveData.Count()}");
            Console.WriteLine($"First: {expensiveData.First()}");
            Console.WriteLine($"Contains 'Item2': {expensiveData.Contains("Item2")}");

            Console.WriteLine("\nOptimized code (enumerate once):");
            
            // TODO: Fix by materializing the enumerable once
            /* YOUR CODE HERE */
            var materializedData = expensiveData.ToList();
            Console.WriteLine($"Count: {materializedData.Count}");
            Console.WriteLine($"First: {materializedData.First()}");
            Console.WriteLine($"Contains 'Item2': {materializedData.Contains("Item2")}");
            /* END YOUR CODE */

            Console.WriteLine();
        }

        // Helper method that simulates expensive data retrieval
        static IEnumerable<string> GetExpensiveData()
        {
            Console.WriteLine("  [Expensive operation executed]");
            yield return "Item1";
            yield return "Item2";
            yield return "Item3";
        }
    }

    // CHALLENGE 4: Complete this class implementation
    public class SimpleBookCollection : IEnumerable<string>
    {
        private List<string> books = new List<string>();

        public void AddBook(string book)
        {
            books.Add(book);
        }

        // TODO: Implement the generic GetEnumerator method
        public IEnumerator<string> GetEnumerator()
        {
            return books.GetEnumerator();
        }

        // TODO: Implement the non-generic GetEnumerator method
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

/* 
INSTRUCTOR SOLUTION KEY:

Challenge 1:
using (var enumerator = books.GetEnumerator())
{
    int position = 0;
    while (enumerator.MoveNext())
    {
        Console.WriteLine($"Position {position}: {enumerator.Current}");
        position++;
    }
}

Challenge 2:
// Fixed version removes Current access before MoveNext and adds proper disposal
using (var enumerator = numbers.GetEnumerator())
{
    while (enumerator.MoveNext())
    {
        Console.WriteLine("Number: " + enumerator.Current);
    }
}

Challenge 3:
using (var enumerator = names.GetEnumerator())
{
    while (enumerator.MoveNext())
    {
        Console.WriteLine($"Hello, {enumerator.Current}!");
    }
}

Challenge 4:
public IEnumerator<string> GetEnumerator()
{
    return books.GetEnumerator();
}

System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
{
    return GetEnumerator();
}

Challenge 5:
var materializedData = expensiveData.ToList();
Console.WriteLine($"Count: {materializedData.Count}");
Console.WriteLine($"First: {materializedData.First()}");
Console.WriteLine($"Contains 'Item2': {materializedData.Contains("Item2")}");

EXPECTED OUTPUT:
The expensive operation should only execute once in the optimized version,
demonstrating the performance improvement of single enumeration.
*/
