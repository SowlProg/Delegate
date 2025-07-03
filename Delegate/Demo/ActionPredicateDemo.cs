using System;
using Project.Delegate;

namespace Project.Demos
{
    public static class ActionPredicateFuncDemo
    {
        public static void Show()
        {
            Console.WriteLine("\n===== Action/Predicate/Func Demo =====");

            Action showTime = () => Console.WriteLine($"Current time: {DateTime.Now:HH:mm:ss}");
            Action showDate = () => Console.WriteLine($"Today's date: {DateTime.Now:MM/dd/yyyy}");

            showTime();
            showDate();

            Func<double, double, double> triangleArea = (b, h) => 0.5 * b * h;
            Console.WriteLine($"Triangle area: {triangleArea(10, 5)}");
        }
    }
}