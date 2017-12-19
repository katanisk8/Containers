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
      ItemList.AddLast(6);
      ItemList.AddLast(7);
      ItemList.AddLast(8);
      ItemList.AddLast(9);

      ItemList.AddBefore(5, 6);
      ItemList.AddBefore(4, 5);
      ItemList.AddBefore(3, 4);

      foreach (var item in ItemList)
      {
         Console.WriteLine(item.ToString());
      }

      Console.WriteLine(string.Format("Count = {0}", ItemList.Count));

      Console.Read();
   }
}