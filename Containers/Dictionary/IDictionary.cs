namespace Containers.Dictionary
{
    public interface IDictionary<TKey, TValue> : IContainer<IDictionaryElement<TKey, TValue>>
    {
        TValue this[TKey key] { get; set; }

        void Add(TKey key, TValue value);
        TValue GetValue(TKey key);
        bool TryGetValue(TKey key, out TValue value);
        void Remove(TKey key);
        bool ContainsKey(TKey key);
        bool ContainsValue(TValue value);
    }
}
