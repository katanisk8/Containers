﻿using DoubleLinkedList;
using System;

class Program
{
   static void Main(string[] args)
   {
      try
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

         ItemList.AddBefore(2, -5);

         Console.WriteLine(string.Format("Count = {0}", ItemList.Count));

      }
      catch (Exception ex)
      {
         Console.WriteLine(string.Format("Wyjatek: {0}", ex.Message));
      }

      Console.Read();
   }
}