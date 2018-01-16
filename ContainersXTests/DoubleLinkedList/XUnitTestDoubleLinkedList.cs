using Xunit;
using Containers.DoubleLinkedList;
using Containers.Exceptions;

public class XUnitTestDoubleLinkedList
{
   [Fact]
   public void AddFirstTest()
   {
      IDoubleLinkedList<int> list = new DoubleLinkedList<int>();

      list.AddFirst(4);
      list.AddFirst(3);
      list.AddFirst(2);
      list.AddFirst(1);
      list.AddFirst(0);

      CheckListOrder(list);
   }

   [Fact]
   public void AddLastTest()
   {
      IDoubleLinkedList<int> list = new DoubleLinkedList<int>();

      list.AddLast(0);
      list.AddLast(1);
      list.AddLast(2);
      list.AddLast(3);
      list.AddLast(4);

      CheckListOrder(list);
   }

   [Fact]
   public void AddBeforeTest()
   {
      IDoubleLinkedList<int> list = new DoubleLinkedList<int>();

      list.AddLast(1);
      list.AddLast(4);
      list.AddBefore(3, 4);
      Assert.Throws<ElementNotFoundException<int>>(() => list.AddAfter(2, -5));
      list.AddBefore(2, 3);
      list.AddBefore(0, 1);
      Assert.Throws<ElementNotFoundException<int>>(() => list.AddAfter(-2, 5));

      CheckListOrder(list);
   }

   [Fact]
   public void AddAfterTest()
   {
      IDoubleLinkedList<int> list = new DoubleLinkedList<int>();

      list.AddLast(0);
      list.AddLast(3);
      list.AddAfter(4, 3);
      Assert.Throws<ElementNotFoundException<int>>(() => list.AddAfter(-2, 5));
      list.AddAfter(1, 0);
      list.AddAfter(2, 1);
      Assert.Throws<ElementNotFoundException<int>>(() => list.AddAfter(5, 5));

      CheckListOrder(list);
   }

   [Fact]
   public void ClearTest()
   {
      IDoubleLinkedList<int> list = new DoubleLinkedList<int>();

      list.AddLast(0);
      list.AddLast(1);
      list.AddLast(2);
      list.AddLast(3);
      list.AddLast(4);

      Assert.Equal((int)list.Count, 5);

      list.Clear();

      Assert.Equal((int)list.Count, 0);
      Assert.Equal(list.First, null);
      Assert.Equal(list.Last, null);
      Assert.Equal(list.Last, list.First);
   }

   [Fact]
   public void FirstOrDefaultTest()
   {
      IDoubleLinkedList<int> list = new DoubleLinkedList<int>();

      list.AddLast(0);
      list.AddLast(1);
      list.AddLast(2);

      Assert.Equal(list.FirstOrDefault(0, null).Value, 0);
      Assert.Equal(list.FirstOrDefault(1, null).Value, 1);
      Assert.Equal(list.FirstOrDefault(2, null).Value, 2);
   }

   [Fact]
   public void IsEmptyTest()
   {
      IDoubleLinkedList<int> list = new DoubleLinkedList<int>();

      Assert.Equal(list.IsEmpty, true);

      list.AddFirst(0);

      Assert.Equal(list.IsEmpty, false);

      list.AddLast(1);
      list.AddLast(2);

      Assert.Equal(list.IsEmpty, false);

   }
   
   [Fact]
   public void RemoveEmptyTest()
   {
      IDoubleLinkedList<int> list = new DoubleLinkedList<int>();

      Assert.Equal<uint>(0, list.Count);
      
      Assert.Throws<EmptyListException>(() => { list.RemoveFirst(); });
      Assert.Equal<uint>(0, list.Count);
      Assert.Throws<EmptyListException>(() => { list.RemoveLast(); ; });
      Assert.Equal<uint>(0, list.Count);
      
      Assert.Equal<uint>(0, list.Count);
      Assert.Throws<ElementNotFoundException<int>>(() => { list.Remove(-1); });
      Assert.Equal<uint>(0, list.Count);
      Assert.Throws<ElementNotFoundException<int>>(() => { list.Remove(0); });
      Assert.Equal<uint>(0, list.Count);
      Assert.Throws<ElementNotFoundException<int>>(() => { list.Remove(1000000); });
      Assert.Equal<uint>(0, list.Count);
   }

   [Fact]
   public void RemoveFirstTest()
   {
      IDoubleLinkedList<int> list = new DoubleLinkedList<int>();

      list.AddFirst(2);
      list.AddFirst(1);
      list.AddFirst(0);

      list.RemoveFirst();

      Assert.NotEmpty(list);
      Assert.DoesNotContain(0, list);
      Assert.Contains(1, list);
      Assert.Contains(2, list);
      Assert.Equal(1, list.First.Value);
      Assert.Equal(2, list.First.Next.Value);
   }

   [Fact]
   public void RemoveLastTest()
   {
      IDoubleLinkedList<int> list = new DoubleLinkedList<int>();

      list.AddLast(0);
      list.AddLast(1);
      list.AddLast(2);

      list.RemoveLast();

      Assert.NotEmpty(list);
      Assert.DoesNotContain(2, list);
      Assert.Contains(0, list);
      Assert.Contains(1, list);
      Assert.Equal(1, list.Last.Value);
      Assert.Equal(0, list.Last.Prev.Value);
   }

   [Fact]
   public void RemoveTest()
   {
      IDoubleLinkedList<int> list = new DoubleLinkedList<int>();

      list.AddLast(0);
      list.AddLast(1);
      list.AddLast(2);

      list.Remove(1);

      Assert.NotEmpty(list);
      Assert.DoesNotContain(1, list);
      Assert.Contains(0, list);
      Assert.Contains(2, list);
      Assert.Equal(0, list.First.Value);
      Assert.Equal(2, list.Last.Value);
      Assert.Equal(list.First, list.Last.Prev);
      Assert.Equal(list.Last, list.First.Next);
   }

   private void CheckListOrder(IDoubleLinkedList<int> list)
   {
      //0
      Assert.NotEqual(list.First, null);
      Assert.NotEqual(list.First.Next, null);
      Assert.Equal(list.First.Prev, null);
      Assert.Equal(list.First.Value, 0);

      //1
      Assert.NotEqual(list.First.Next.Next, null);
      Assert.NotEqual(list.First.Next.Prev, null);
      Assert.Equal(list.First.Next.Value, 1);

      //2
      Assert.NotEqual(list.First.Next.Next.Next, null);
      Assert.NotEqual(list.First.Next.Next.Prev, null);
      Assert.Equal(list.First.Next.Next.Value, 2);

      //3
      Assert.NotEqual(list.First.Next.Next.Next.Next, null);
      Assert.NotEqual(list.First.Next.Next.Next.Prev, null);
      Assert.Equal(list.First.Next.Next.Next.Value, 3);

      //4
      Assert.NotEqual(list.Last, null);
      Assert.NotEqual(list.Last.Prev, null);
      Assert.Equal(list.Last.Next, null);
      Assert.Equal(list.Last.Value, 4);

      Assert.Equal((int)list.Count, 5);
   }
}