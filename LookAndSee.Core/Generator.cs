using System;
using System.Collections.Generic;
using System.Linq;
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
            for (var i = 0; i < n; i++)
            {
                Next();
            }
            return Current;
        }

        public string Next()
        {
            var keyCounts = CountDigits(Current);
            Current = CreateNext(keyCounts);
            return Current;
        }

        private string CreateNext(List<KeyCount> groups)
        {
            var sb = new StringBuilder();
            foreach (var group in groups)
            {
                sb.Append(group.Count);
                sb.Append(group.Key);
            }
            return sb.ToString();
        }

        private List<KeyCount> CountDigits(string s)
        {
            var characters = s.Split();
            var digits = new List<KeyCount>();
            var index = 0;
            var count = 0;

            while(index < characters.Length)
            {
                if(index == 0)
                {
                    count++;
                } else if(characters[index] != characters[index-1])
                {
                    digits.Add(new KeyCount { Key=characters[index-1], Count = count });
                }else
                {
                    count++;
                }
                index++;
            }
           

            return digits;
        }

        private class KeyCount
        {
            public string Key { get; set; }
            public int Count { get; set; }
        }
    }
}
