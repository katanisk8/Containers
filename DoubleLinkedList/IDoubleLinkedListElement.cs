namespace DoubleLinkedList
{
   public interface IDoubleLinkedListElement<TValue>
   {
      DoubleLinkedListElement<TValue> Next { get; set; }
      DoubleLinkedListElement<TValue> Prev { get; set; }
      TValue Value { get; }
   }
}