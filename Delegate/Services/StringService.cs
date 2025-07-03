using System.Linq;
using Project.Delegate;

namespace Project.Services
{
    public static class StringService
    {
        public static int CountVowels(string s) =>
            s.ToLower().Count(c => "aeiou".Contains(c));

        public static int CountConsonants(string s) =>
            s.ToLower().Count(c => "bcdfghjklmnpqrstvwxyz".Contains(c));

        public static int GetLength(string s) => s.Length;
    }
}