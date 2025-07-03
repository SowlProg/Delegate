using System;
using System.IO;
using Project.Delegate;

namespace Project.Demos
{
    public static class MultiDelegateDemo
    {
        public static void Show()
        {
            Console.WriteLine("\n===== Multicast Delegate =====");

            MultiDelegate multi = DisplayMessage;
            multi += LogMessage;
            multi("Test message");

            static void DisplayMessage(string msg) =>
                Console.WriteLine($"DISPLAY: {msg}");

            static void LogMessage(string msg) =>
                File.AppendAllText("log.txt", $"{DateTime.Now}: {msg}\n");
        }
    }
}