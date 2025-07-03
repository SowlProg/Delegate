using Project.Delegate;

namespace Project.Demos
{
    public static class ChainCheckDemo
    {
        public static void Show()
        {
            Console.WriteLine("\n===== Validation Chain =====");

            NumberValidator chain = IsPositive;
            chain += IsEven;
            chain += IsMultipleOfTen;

            Console.WriteLine("Testing number 20:");
            chain(20);

            static bool IsPositive(int n) => LogCheck(n > 0, "positive");
            static bool IsEven(int n) => LogCheck(n % 2 == 0, "even");
            static bool IsMultipleOfTen(int n) => LogCheck(n % 10 == 0, "multiple of 10");

            static bool LogCheck(bool condition, string description)
            {
                Console.WriteLine($"• {description}? {condition}");
                return condition;
            }
        }
    }
}