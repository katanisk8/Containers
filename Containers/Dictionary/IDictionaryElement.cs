namespace Containers.Dictionary
{
   public interface IDictionaryElement<TKey, TValue>
   {
      int HashCode { get; }
      TKey Key { get; }
      TValue Value { get; }
      IDictionaryElement<TKey, TValue> Parent { get; set; }
      IDictionaryElement<TKey, TValue> LChild { get; set; }
      IDictionaryElement<TKey, TValue> RChild { get; set; }
   }
}
