using IDoubleLinkedListElement;

namespace IDoubleLinkedList
{
   public interface IDoubleLinkedList<TValue>
   {
      IDoubleLinkedListElement<TValue> First { get; set; }
      IDoubleLinkedListElement<TValue> Last { get; set; }

      void AddAfter(TValue valueBefore, TValue value);
      void AddBefore(TValue valueBefore, TValue value);
      void AddFirst(TValue value);
      void AddLast(TValue value);
      IDoubleLinkedListElement<TValue> FirstOrDefault(TValue value, IDoubleLinkedListElement<TValue> _default);
      bool IsEmpty();
   }
}