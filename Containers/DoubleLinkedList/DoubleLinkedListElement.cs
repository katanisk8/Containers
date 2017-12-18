namespace Containers.DoubleLinkedListElement
{
   public class DoubleLinkedListElement<TValue>
   {
      public DoubleLinkedListElement<TValue> Prev { get; set; } = null;
      public DoubleLinkedListElement<TValue> Next { get; set; } = null;
      public TValue Value { get; private set; }

      public DoubleLinkedListElement(TValue value)
      {
         Value = value;
      }
   }
}