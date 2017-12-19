using DoubleLinkedList;
using System;

class Program
{
   static void Main(string[] args)
   {
      DoubleLinkedList<int> ItemList = new DoubleLinkedList<int>();

      ItemList.AddFirst(2);
      ItemList.AddFirst(1);
      ItemList.AddFirst(0);
      ItemList.AddLast(4);
      ItemList.AddLast(5);

      ItemList.AddBefore(3, 4);

      foreach (var item in ItemList)
      {
         Console.WriteLine(item.ToString());
      }

      Console.WriteLine(string.Format("Count = {0}", ItemList.Count));

      Console.Read();
   }
}