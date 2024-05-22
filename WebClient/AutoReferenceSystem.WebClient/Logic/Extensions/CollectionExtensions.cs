using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoReferenceSystem.WebClient.Logic.Extensions
{
    public static class CollectionExtensions
    {
        public static string AsOneString(this IEnumerable<string> collection, string delimeter = " ; ")
        {
            int count = collection.Count();
            StringBuilder builder = new StringBuilder(count * 10 * delimeter.Length);
            foreach (var message in collection)
            {
                builder.Append($"{message}{delimeter}");
            }
            return builder.ToString();
        }
    }
}
