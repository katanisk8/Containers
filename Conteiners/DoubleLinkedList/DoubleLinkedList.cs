namespace Conteiners.DoubleLinkedList
{
   public class DoubleLinkedList<TValue>
   {
      public DoubleLinkedListElement<TValue> First { get; set; } = null;
      public DoubleLinkedListElement<TValue> Last { get; set; } = null;

      public void AddFirst(TValue value)
      {
         DoubleLinkedListElement<TValue> element = new DoubleLinkedListElement<TValue>(value);

         if (First == null && Last == null)
         {
            First = element;
            Last = element;
         }
         else
         {
            First.Prev = element;
            element.Next = First;
            First = element;
         }
      }

      public void AddLast(TValue value)
      {
         DoubleLinkedListElement<TValue> element = new DoubleLinkedListElement<TValue>(value);

         if (First == null && Last == null)
         {
            First = element;
            Last = element;
         }
         else
         {
            Last.Next = element;
            element.Prev = Last;
            Last = element;
         }
      }

      public void AddBefore(TValue valueBefore, TValue value)
      {
         DoubleLinkedListElement<TValue> elementBefore = new DoubleLinkedListElement<TValue>(valueBefore);
         DoubleLinkedListElement<TValue> element = FindFirst(value);

         elementBefore.Prev = element.Prev;
         elementBefore.Next = element;
         element.Prev = elementBefore;
      }

      public DoubleLinkedListElement<TValue> FindFirst(TValue value)
      {
         DoubleLinkedListElement<TValue> element = First;

         while (element != null)
         {
            if (element.Value.Equals(value))
            {
               return element;
            }

            element = element.Next;
         }

         return null;
      }

      //void AddAfter(TValue value, TValue key)
      //void RemoveAll()
      //void RemoveFirst()
      //void RemoveLast()
      //void Remove(TValue value)
      //unsigned int Size()
      //bool IsEmpty()
   }
}