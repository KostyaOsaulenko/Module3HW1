using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3HW1
{
    public class Starter
    {
        public void Run()
        {
            MyList<int> myList = new MyList<int>();
            Print(myList);
            myList.Add(5);
            var arry1 = new int[] { 4, 3, 2 };
            myList.AddRange(arry1);
            myList.Add(1);
            Print(myList);
            myList.Remove(2);
            Print(myList);
            myList.Sort(new Comparer());
            Print(myList);
            myList.RemoveAt(3);
            Print(myList);
        }

        public void Print<T>(MyList<T> myList)
        {
            Console.WriteLine();
            foreach (var item in myList)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
