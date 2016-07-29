using POGOProtos.Inventory;
using POGOProtos.Inventory.Item;
using SnipeBot.UserLogger;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SnipeBot.Utils
{
    public static class StringUtils
    {
        public static string GetSummedFriendlyNameOfItemAwardList(IEnumerable<ItemAward> items)
        {
            var enumerable = items as IList<ItemAward> ?? items.ToList();

            if (!enumerable.Any())
                return string.Empty;

            return
                enumerable.GroupBy(i => i.ItemId)
                          .Select(kvp => new { ItemName = kvp.Key.ToString(), Amount = kvp.Sum(x => x.ItemCount) })
                          .Select(y => $"{y.Amount} x {y.ItemName}")
                          .Aggregate((a, b) => $"{a}, {b}");
        }
        public static double ToDouble(this string str)
        {
            double o = 0;

            if (double.TryParse(str, out o))
            {
                return o;
            }
            Logger.Write($"Could not parse double: {str})");
            return o;
        }
        public static int ToInt(this string str)
        {
            int o = 0;

            if (int.TryParse(str, out o))
            {
                return o;
            }
            Logger.Write($"Could not parse int: {str})");
            return o;
        }
        public static Color ToColor(this string str)
        {
            return Helpers.ColorFromHex(str);
        }
        public static string StripTags(this string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }
    }
}
