using System;
using System.Linq;
using Project.Services;
using Project.Demos;
using Project.Delegate;

namespace Project
{
    class Program
    {
        static void Main()
        {
            // Task 1 - Array Filtering
            Console.WriteLine("===== Array Filtering =====");
            int[] data = Enumerable.Range(1, 20).ToArray();
            Console.WriteLine("Even numbers: " + string.Join(", ", ArrayService.GetEvenNumbers(data)));
            Console.WriteLine("Prime numbers: " + string.Join(", ", ArrayService.GetPrimeNumbers(data)));

            // Task 2 - Delegates
            ActionPredicateFuncDemo.Show();

            // Task 3 - Credit Card
            Console.WriteLine("\n===== Credit Card =====");
            var card = new CreditCard("1234-5678-9012-3456", "John Doe", DateTime.Now.AddYears(3), 1234, 5000);
            card.MoneyDeposited += amount => Console.WriteLine($"Deposited: {amount:C}");
            card.Deposit(1500);

            // Task 4 - String Analysis
            Console.WriteLine("\n===== String Analysis =====");
            string text = "Hello, World!";
            Console.WriteLine($"Vowels: {StringService.CountVowels(text)}");
            Console.WriteLine($"Length: {StringService.GetLength(text)}");

            // Task 5 - Multicast Delegate
            MultiDelegateDemo.Show();

            // Task 6 - Validation Chain
            ChainCheckDemo.Show();
        }
    }
}