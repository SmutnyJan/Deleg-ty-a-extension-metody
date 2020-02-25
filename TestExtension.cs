using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Delegáty_a_extensionmetody
{
    public static class TestExtensions
    {
        static Random rnd = new Random();
        // RandomElement
        public static T RandomElement<T>(this IList<T> list)
        {
            if (list.Count == 0)
            {
                throw new Exception("Pole má 0 prvků.");
            }

            else
            {
                int index = rnd.Next(list.Count);
                return (list[index]);
            }
        }

        // RandomElementsWhere
        public static string RandomElementsWhere(this IList<string> list, string contains, int count)
        {
            IList<string> temp = new List<string>();

            string str = "";
            if (list.Count == 0)
            {
                throw new Exception("Pole má 0 prvků.");
            }
            else
            {
                foreach (var st in list.GroupBy(st => st, (key, group) => new { color = key, count = count }).Where(x => x.color.Contains(contains)).Take(count))
                {
                    str += st.color.ToString() + " ";
                }
            }
            if (str.Length == 0) {
                Exception e = new Exception(String.Format("Žádný prvek neobsahuje {0}", contains));

                throw e;
            }
            return str;
        }


        // AppearanceGreaterThen
        public static IList<string> AppearanceGreaterThen<T>(this IList<T> list, int param)
        {
            IList<string> temp = new List<string>();
            if (list.Count == 0)
            {
                throw new Exception("Pole má 0 prvků.");
            }
            else
            {
                foreach (var st in list.GroupBy(s => s, (key, group) => new { color = key, count = group.Count() }).Where(x => x.count >= param))
                {
                    temp.Add(st.color.ToString());
                }
            }
            if (temp.Count == 0)
            {
                Exception e = new Exception(String.Format("Žádný prvek není obsažen více jak {0}", param));

                throw e;
            }
            else
            {
                return temp;
            }
        }
    }
}
