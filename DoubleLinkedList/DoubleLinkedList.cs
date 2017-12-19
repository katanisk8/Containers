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
            First = element;
            Last = element;
            Count++;
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
            First = element;
            Last = element;
            Count++;
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
            First = element;
            Last = element;
            Count++;
         }
         else if (element == null)
         {
            return;
         }
         else
         {
            elementBefore.Prev = element.Prev;
            elementBefore.Next = element;
            element.Prev.Next = elementBefore;
            element = elementBefore;
            Count++;
         }
      }

      public void AddAfter(TValue valueBefore, TValue value)
      {
         DoubleLinkedListElement<TValue> elementBefore = new DoubleLinkedListElement<TValue>(valueBefore);
         DoubleLinkedListElement<TValue> element = FindFirst(value);

         if (IsEmpty())
         {
            First = element;
            Last = element;
            Count++;
         }
         else if (element == null)
         {
            return;
         }
         else
         {
            elementBefore.Prev = element.Prev;
            elementBefore.Next = element;
            element.Prev.Next = elementBefore;
            element = elementBefore;
            Count++;
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

         return null;
      }

      public bool IsEmpty()
      {
         return First == null && Last == null;
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


      //void RemoveAll()
      //void RemoveFirst()
      //void RemoveLast()
      //void Remove(TValue value)
   }
}