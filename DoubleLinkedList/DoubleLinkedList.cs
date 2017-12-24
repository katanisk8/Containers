using System.Collections;
using System.Collections.Generic;
using IDoubleLinkedList;
using IDoubleLinkedListElement;
using DoubleLinkedListElement;

namespace DoubleLinkedList
{
    public class DoubleLinkedList<TValue> : IDoubleLinkedList<TValue>, IEnumerable<TValue>
    {

        public IDoubleLinkedListElement<TValue> First { get; set; } = null;
        public IDoubleLinkedListElement<TValue> Last { get; set; } = null;
        public uint Count { get; set; } = 0;

        public void AddFirst(TValue value)
        {
            IDoubleLinkedListElement<TValue> element = new DoubleLinkedListElement<TValue>(value);

            if (IsEmpty())
            {
                Add(element);
            }
            else
            {
                First.Prev = element;
                element.Next = First;
                First = element;
                Count++;
            }
        }

        public void AddLast(TValue value)
        {
            IDoubleLinkedListElement<TValue> element = new DoubleLinkedListElement<TValue>(value);

            if (IsEmpty())
            {
                Add(element);
            }
            else
            {
                Last.Next = element;
                element.Prev = Last;
                Last = element;
                Count++;
            }
        }

        public void AddBefore(TValue valueBefore, TValue value)
        {
            IDoubleLinkedListElement<TValue> elementBefore = new DoubleLinkedListElement<TValue>(valueBefore);
            IDoubleLinkedListElement<TValue> element = FirstOrDefault(value, null);

            if (element == null)
            {
                throw new ElementNotFoundException<TValue>(value);
            }
            else if (element.Prev == null)
            {
                AddFirst(valueBefore);
            }
            else
            {
                elementBefore.Prev = element.Prev;
                elementBefore.Next = element;
                element.Prev.Next = elementBefore;
                element.Prev = elementBefore;
                Count++;
            }
        }

        public void AddAfter(TValue valueAfter, TValue value)
        {
            IDoubleLinkedListElement<TValue> elementAfter = new DoubleLinkedListElement<TValue>(valueAfter);
            IDoubleLinkedListElement<TValue> element = FirstOrDefault(value, null);

            if (element == null)
            {
                throw new ElementNotFoundException<TValue>(value);
            }
            else if (element.Next == null)
            {
                AddLast(valueAfter);
            }
            else
            {
                elementAfter.Prev = element;
                elementAfter.Next = element.Next;
                element.Next.Prev = elementAfter;
                element.Next = elementAfter;
                Count++;
            }
        }

        public void RemoveFirst(TValue value)
        {
            First = null;
        }

        public void RemoveLast(TValue value)
        {
            Last = null;
        }

        public void Clear()
        {
            IDoubleLinkedListElement<TValue> element = First;

            First = null;
            Last = null;

            while (element != null)
            {
                var nextElement = element.Next;

                element = null;
                Count--;

                element = nextElement;
            }
        }

        public IDoubleLinkedListElement<TValue> FirstOrDefault(TValue value, IDoubleLinkedListElement<TValue> _default)
        {
            IDoubleLinkedListElement<TValue> element = First;

            while (element != null)
            {
                if (element.Value.Equals(value))
                {
                    return element;
                }

                element = element.Next;
            }

            return _default;
        }

        public bool IsEmpty()
        {
            return First == null && Last == null;
        }

        private void Add(IDoubleLinkedListElement<TValue> element)
        {
            First = element;
            Last = element;
            Count++;
        }

        private IEnumerable<TValue> Events()
        {
            IDoubleLinkedListElement<TValue> element = First;

            while (element != null)
            {
                yield return element.Value;
                element = element.Next;
            }
        }

        public IEnumerator<TValue> GetEnumerator()
        {
            return Events().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        //void Remove(TValue value)
    }
}