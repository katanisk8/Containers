using System.Collections;
using System.Collections.Generic;
using Containers.Exceptions;

namespace Containers.DoubleLinkedList
{
   public class DoubleLinkedList<TValue> : IDoubleLinkedList<TValue>
   {
      public IDoubleLinkedListElement<TValue> First { get; set; } = null;
      public IDoubleLinkedListElement<TValue> Last { get; set; } = null;
      public uint Count { get; private set; } = 0;
      public bool IsEmpty { get { return First == null && Last == null; } }

      public void Add(TValue value)
      {
         AddLast(value);
      }

      public void AddFirst(TValue value)
      {
         IDoubleLinkedListElement<TValue> element = CreateElement(value);

         if (IsEmpty)
         {
            AddFirstElement(element);
         }
         else
         {
            First.Prev = element;
            element.Next = First;
            First = element;
            IncrementCounter();
         }
      }

      public void AddLast(TValue value)
      {
         IDoubleLinkedListElement<TValue> element = CreateElement(value);

         if (IsEmpty)
         {
            AddFirstElement(element);
         }
         else
         {
            Last.Next = element;
            element.Prev = Last;
            Last = element;
            IncrementCounter();
         }
      }

      public void AddBefore(TValue valueBefore, TValue value)
      {
         IDoubleLinkedListElement<TValue> elementBefore = CreateElement(valueBefore);
         IDoubleLinkedListElement<TValue> element = FirstOrDefault(value, null);

         if (element == null)
         {
            throw new ElementNotFoundException<TValue>(value, this);
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
            IncrementCounter();
         }
      }

      public void AddAfter(TValue valueAfter, TValue value)
      {
         IDoubleLinkedListElement<TValue> elementAfter = CreateElement(valueAfter);
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
            IncrementCounter();
         }
      }

      public void RemoveFirst()
      {
         if (IsEmpty)
         {
            throw new EmptyListException<TValue>();
         }
         else
         {
            First = First.Next;
            EraseElement(First.Prev);
            First.Prev = null;
            DecrementCounter();
         }
      }

      public void RemoveLast()
      {
         if (IsEmpty)
         {
            throw new EmptyListException<TValue>();
         }
         else
         {
            Last = Last.Prev;
            EraseElement(Last.Next);
            Last.Next = null;
            DecrementCounter();
         }
      }

      public void Remove(TValue value)
      {
         IDoubleLinkedListElement<TValue> element = FirstOrDefault(value, null);

         if (element == null)
         {
            throw new ElementNotFoundException<TValue>(value);
         }
         else if (element.Prev == null)
         {
            RemoveFirst();
         }
         else if (element.Next == null)
         {
            RemoveLast();
         }
         else
         {
            element.Prev.Next = element.Next;
            element.Next.Prev = element.Prev;
            EraseElement(element);
            DecrementCounter();
         }
      }

      public void Clear()
      {
         IDoubleLinkedListElement<TValue> element = First;

         while (element != null)
         {
            var nextElement = element.Next;

            EraseElement(element);
            DecrementCounter();

            element = nextElement;
         }

         First = null;
         Last = null;
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

      private void EraseElement(IDoubleLinkedListElement<TValue> element)
      {
         element.Prev = null;
         element.Next = null;
         element = null;
      }

      private IDoubleLinkedListElement<TValue> CreateElement(TValue value)
      {
         return new DoubleLinkedListElement<TValue>(value);
      }

      private void AddFirstElement(IDoubleLinkedListElement<TValue> element)
      {
         First = element;
         Last = element;
         IncrementCounter();
      }

      private void IncrementCounter()
      {
         ++Count;
      }

      private void DecrementCounter()
      {
         --Count;
      }

      #region IEnumerable
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
      #endregion
   }
}