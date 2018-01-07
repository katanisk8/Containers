namespace Containers.DoubleLinkedList
{
    public class DoubleLinkedListElement<TValue> : IDoubleLinkedListElement<TValue>
    {
        public IDoubleLinkedListElement<TValue> Prev { get; set; } = null;
        public IDoubleLinkedListElement<TValue> Next { get; set; } = null;
        public TValue Value { get; private set; }

        public DoubleLinkedListElement(TValue value)
        {
            Value = value;
        }
    }
}
