using System.Collections.Generic;

namespace Containers
{
   public interface IContainer<TValue> : IEnumerable<TValue>
   {
      uint Count { get; }
      bool IsEmpty { get; }
      void Add(TValue value);
      void Remove(TValue value);
      void Clear();
   }
}
