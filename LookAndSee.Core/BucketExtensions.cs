using System.Collections.Generic;
using System.Text;

namespace LookAndSee.Core
{
    internal static class BucketExtensions
    {
        public static string CreateSequence(this IEnumerable<Bucket> buckets)
        {
            var sb = new StringBuilder();
            foreach (var group in buckets)
            {
                sb.Append(group.Count);
                sb.Append(group.Key);
            }
            return sb.ToString();
        }
    }
}