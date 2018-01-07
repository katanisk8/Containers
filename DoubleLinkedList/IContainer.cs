namespace Containers
{
    public interface IContainer<TValue>
    {
        uint Count { get; }
        void Add(TValue value);
        void Remove(TValue value);
        void Clear();
        bool IsEmpty();
    }
}
