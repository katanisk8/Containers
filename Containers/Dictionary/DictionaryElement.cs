namespace Containers.Dictionary
{
    public class DictionaryElement<TKey, TValue> : IDictionaryElement<TKey, TValue>
    {
        public int HashCode { get { return Key.GetHashCode(); } }
        public TKey Key { get; private set; }
        public TValue Value { get; private set; }
        public IDictionaryElement<TKey, TValue> Parent { get; set; } = null;
        public IDictionaryElement<TKey, TValue> LChild { get; set; } = null;
        public IDictionaryElement<TKey, TValue> RChild { get; set; } = null;

        public DictionaryElement(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
}
