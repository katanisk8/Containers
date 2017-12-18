﻿namespace DoubleLinkedList
{
   public class DoubleLinkedList<TValue>
   {
      public DoubleLinkedListElement<TValue> First { get; set; } = null;
      public DoubleLinkedListElement<TValue> Last { get; set; } = null;

      public void AddFirst(TValue value)
      {
         DoubleLinkedListElement<TValue> element = new DoubleLinkedListElement<TValue>(value);

         if (IsEmpty())
         {
            First = element;
            Last = element;
         }
         else
         {
            First.Prev = element;
            element.Next = First;
            First = element;
         }
      }

      public void AddLast(TValue value)
      {
         DoubleLinkedListElement<TValue> element = new DoubleLinkedListElement<TValue>(value);

         if (IsEmpty())
         {
            First = element;
            Last = element;
         }
         else
         {
            Last.Next = element;
            element.Prev = Last;
            Last = element;
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

      //void RemoveAll()
      //void RemoveFirst()
      //void RemoveLast()
      //void Remove(TValue value)
      //unsigned int Size()
   }
}