using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LookAndSee.Core
{
    public class Generator
    {
        public string Current { get; private set; }

        public Generator()
        {
            Current = "1";
        }

        public string Next(int n)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            
            for (var i = 0; i < n; i++)
            {
                Next();
            }

            stopwatch.Stop();
            
            Console.WriteLine($"Generated {n+1}'th index of LookAndSee sequence in {stopwatch.Elapsed}.");
            Console.WriteLine($"Result has length {Current.Length}");

            return Current;
        }

        public string Next()
        {
            var keyCounts = CountDigits(Current);
            Current = CreateNext(keyCounts);
            return Current;
        }

        private static string CreateNext(IEnumerable<KeyCount> groups)
        {
            var sb = new StringBuilder();
            foreach (var group in groups)
            {
                sb.Append(group.Count);
                sb.Append(group.Key);
            }
            return sb.ToString();
        }

        private static IEnumerable<KeyCount> CountDigits(string s)
        {
            var characters = s.ToCharArray();
            var index = 0;
            var count = 0;

            while (index < characters.Length)
            {
                var character = characters[index];

                if (index + 1 == characters.Length) // Last character, close off final bucket
                {
                    yield return new KeyCount
                    {
                        Key = character.ToString(),
                        Count = ++count
                    };
                    yield break;
                }

                if (character != characters[index + 1]) // Does not match next character - last in the current bucket
                {
                    yield return new KeyCount
                    {
                        Key = character.ToString(),
                        Count = ++count
                    };
                    count = 0;
                }
                else // Match, same bucket, so increment count
                {
                    count++;
                }

                index++;
            }
        }

        private class KeyCount
        {
            public string Key { get; set; }
            public int Count { get; set; }
        }
    }
}
