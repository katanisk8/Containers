using System;
using System.Collections;
using System.Collections.Generic;

namespace DoubleLinkedList
{
   public class DoubleLinkedList<TValue> : IDoubleLinkedList<TValue>, IEnumerable<TValue>
   {

      public DoubleLinkedListElement<TValue> First { get; set; } = null;
      public DoubleLinkedListElement<TValue> Last { get; set; } = null;
      public uint Count { get; set; } = 0;

      public void AddFirst(TValue value)
      {
         DoubleLinkedListElement<TValue> element = new DoubleLinkedListElement<TValue>(value);

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
         DoubleLinkedListElement<TValue> element = new DoubleLinkedListElement<TValue>(value);

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
         DoubleLinkedListElement<TValue> elementBefore = new DoubleLinkedListElement<TValue>(valueBefore);
         DoubleLinkedListElement<TValue> element = FindFirst(value);

         if (IsEmpty())
         {
            Add(element);
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
         DoubleLinkedListElement<TValue> elementAfter = new DoubleLinkedListElement<TValue>(valueAfter);
         DoubleLinkedListElement<TValue> element = FindFirst(value);

         if (IsEmpty())
         {
            Add(element);
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

      public void Clear()
      {
         DoubleLinkedListElement<TValue> element = First;

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

      public DoubleLinkedListElement<TValue> FindFirst(TValue value)
      {
         DoubleLinkedListElement<TValue> element = First;

         while (element != null)
         {
            if (element.Value.Equals(value))
            {
               return element;
            }

            element = element.Next;
         }

         throw new Exception("Nie znaleziono elementu w kolekcji");
      }

      public bool IsEmpty()
      {
         return First == null && Last == null;
      }

      private void Add(DoubleLinkedListElement<TValue> element)
      {
         First = element;
         Last = element;
         Count++;
      }

      private IEnumerable<TValue> Events()
      {
         DoubleLinkedListElement<TValue> element = First;

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


      //void RemoveFirst()
      //void RemoveLast()
      //void Remove(TValue value)
   }
}