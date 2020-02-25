using System;
using System.Collections.Generic;
using Delegáty_a_extensionmetody;
using System.Linq;

namespace Delegáty_a_extensionmetody
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<int> empty = new List<int>();
            IList<string> colors = new List<string> 
            { 
                "red", "blue", "green", "magenta", "yellow", "cyan", "purple", "orange", "azure", "black", "white","gray","brown","gold", "silver", "red", "yellow", "purple", "green", "green", "red", "red"
            };
            Console.WriteLine(colors.RandomElement());
            IList<string> mylist = new List<string>();
            mylist = colors.AppearanceGreaterThen(2);
            foreach(var i in mylist)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(mylist.RandomElementsWhere("e", 25));



        }
    }
}
