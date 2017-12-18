using System.Collections.Generic;

namespace DoubleLinkedList
{
   public interface IDoubleLinkedList<TValue>
   {
      DoubleLinkedListElement<TValue> First { get; set; }
      DoubleLinkedListElement<TValue> Last { get; set; }

      void AddAfter(TValue valueBefore, TValue value);
      void AddBefore(TValue valueBefore, TValue value);
      void AddFirst(TValue value);
      void AddLast(TValue value);
      DoubleLinkedListElement<TValue> FindFirst(TValue value);
      bool IsEmpty();
   }
}