using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LookAndSee.Core
{
    public class Generator
    {
        public string Result { get; private set; } = "1";
        private int Index { get; set; } = 1;

        public string Next(int n = 1)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            
            for (var i = 0; i < n; i++)
            {
                Process();
            }

            stopwatch.Stop();
            
            Console.WriteLine($"Generated index {Index} of LookAndSee sequence in {stopwatch.Elapsed}.");
            Console.WriteLine($"Result has length {Result.Length}");

            return Result;
        }

        private void Process()
        {
            var buckets = CreateBuckets(Result);
            Result = buckets.CreateSequence();
            Index++;
        }


        private static IEnumerable<Bucket> CreateBuckets(string input)
        {
            var characters = input.ToCharArray();
            var index = 0;
            var count = 0;

            while (index < characters.Length)
            {
                var character = characters[index];

                if (index + 1 == characters.Length) // Last character of input, close off final bucket
                {
                    yield return new Bucket
                    {
                        Key = character.ToString(),
                        Count = ++count
                    };
                    yield break;
                }

                if (character != characters[index + 1]) // last character in the current bucket
                {
                    yield return new Bucket
                    {
                        Key = character.ToString(),
                        Count = ++count
                    };
                    count = 0;
                }
                else // Match in same bucket
                {
                    count++;
                }

                index++;
            }
        }
    }
}
