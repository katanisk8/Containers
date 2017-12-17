using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Conteiners.DoubleLinkedList;

namespace ContainersTests
{
   [TestClass]
   public class DoubleLinkedListTests
   {
      [TestInitialize]
      public void Setup()
      {

      }

      [TestMethod]
      public void AddFirstTest()
      {
         DoubleLinkedList<int> list = new DoubleLinkedList<int>();

         list.AddFirst(4);
         list.AddFirst(3);
         list.AddFirst(2);
         list.AddFirst(1);
         list.AddFirst(0);

         CheckListOrder(list);
      }

      [TestMethod]
      public void AddLastTest()
      {
         DoubleLinkedList<int> list = new DoubleLinkedList<int>();

         list.AddLast(0);
         list.AddLast(1);
         list.AddLast(2);
         list.AddLast(3);
         list.AddLast(4);

         CheckListOrder(list);
      }

      [TestMethod]
      public void FindFirstTest()
      {
         DoubleLinkedList<int> list = new DoubleLinkedList<int>();

         list.AddLast(0);
         list.AddLast(1);
         list.AddLast(2);
         list.AddLast(3);
         list.AddLast(4);

         Assert.AreEqual(list.FindFirst(0).Value, 0);
         Assert.AreEqual(list.FindFirst(1).Value, 1);
         Assert.AreEqual(list.FindFirst(2).Value, 2);
         Assert.AreEqual(list.FindFirst(3).Value, 3);
         Assert.AreEqual(list.FindFirst(4).Value, 4);
      }

      [TestMethod]
      public void AddBeforeTest()
      {
         DoubleLinkedList<int> list = new DoubleLinkedList<int>();

         list.AddLast(0);
         list.AddLast(4);
         list.AddBefore(3, 4);
         ExceptException(() => { list.AddBefore(2, -5); });
         list.AddBefore(2, 3);
         list.AddBefore(1, 2);
         ExceptException(() => { list.AddBefore(2, 5); });

         CheckListOrder(list);
      }

      private void ExceptException(Action action)
      {
         try
         {
            action();
            Assert.Fail();
         }
         catch (Exception)
         {

         }
      }

      private void CheckListOrder(DoubleLinkedList<int> list)
      {
         //0
         Assert.AreNotEqual(list.First, null);
         Assert.AreNotEqual(list.First.Next, null);
         Assert.AreEqual(list.First.Prev, null);
         Assert.AreEqual(list.First.Value, 0);

         //1
         Assert.AreNotEqual(list.First.Next.Next, null);
         Assert.AreNotEqual(list.First.Next.Prev, null);
         Assert.AreEqual(list.First.Next.Value, 1);

         //2
         Assert.AreNotEqual(list.First.Next.Next.Next, null);
         Assert.AreNotEqual(list.First.Next.Next.Prev, null);
         Assert.AreEqual(list.First.Next.Next.Value, 2);

         //3
         Assert.AreNotEqual(list.First.Next.Next.Next.Next, null);
         Assert.AreNotEqual(list.First.Next.Next.Next.Prev, null);
         Assert.AreEqual(list.First.Next.Next.Next.Value, 3);

         //4
         Assert.AreNotEqual(list.Last, null);
         Assert.AreNotEqual(list.Last.Prev, null);
         Assert.AreEqual(list.Last.Next, null);
         Assert.AreEqual(list.Last.Value, 4);
      }
   }
}