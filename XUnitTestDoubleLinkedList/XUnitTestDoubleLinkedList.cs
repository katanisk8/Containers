using Containers.DoubleLinkedList;
using Containers.Exceptions;
using Xunit;

namespace XUnitTestDoubleLinkedList
{
    public class XUnitTestDoubleLinkedList
    {

        [Fact]
        public void RemoveEmptyTest()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();

            Assert.Equal<uint>(0, list.Count);

            list.RemoveFirst();
            Assert.Equal<uint>(0, list.Count);
            list.RemoveLast();
            Assert.Equal<uint>(0, list.Count);
            Assert.Throws<ElementNotFoundException<int>>(()=> { list.Remove(-1); });
            Assert.Equal<uint>(0, list.Count);
            Assert.Throws<ElementNotFoundException<int>>(() => { list.Remove(0); });
            Assert.Equal<uint>(0, list.Count);
            Assert.Throws<ElementNotFoundException<int>>(() => { list.Remove(1000000); });
            Assert.Equal<uint>(0, list.Count);
        }

        [Fact]
        public void RemoveFirstTest()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();

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
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();

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
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();

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
    }
}
