using DoubleLinkedList;

class Program
{
   static void Main(string[] args)
   {
      DoubleLinkedList<int> ItemList = new DoubleLinkedList<int>();

      ItemList.AddFirst(2);
      ItemList.AddFirst(1);
      ItemList.AddFirst(0);
      ItemList.AddLast(4);
      ItemList.AddLast(5);


      ItemList.AddBefore(3, 4);
   }
}