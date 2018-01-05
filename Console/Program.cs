using DoubleLinkedList;
using System;

class Program
{
   static void Main(string[] args)
   {
      try
      {
         DoubleLinkedList<int> ItemList = new DoubleLinkedList<int>();
         
         ItemList.AddFirst(0);
         ItemList.AddLast(6);
         ItemList.AddLast(7);
         ItemList.AddLast(8);
         ItemList.AddLast(9);

         ItemList.AddAfter(1, 0);
         ItemList.AddAfter(2, 1);
         ItemList.AddBefore(5, 6);
         //ItemList.AddBefore(4, 5);
         ItemList.AddBefore(3, 4);
         

         foreach (var item in ItemList)
         {
            Console.WriteLine(item.ToString());
         }

         Console.WriteLine(string.Format("Count = {0}", ItemList.Count));
      }
      catch (Exception ex)
      {
         Console.WriteLine(ex.Message);
      }

      Console.Read();
   }
}