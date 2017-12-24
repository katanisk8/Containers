namespace IDoubleLinkedListElement
{
   public interface IDoubleLinkedListElement<TValue>
   {
      IDoubleLinkedListElement<TValue> Next { get; set; }
      IDoubleLinkedListElement<TValue> Prev { get; set; }
      TValue Value { get; }
   }
}