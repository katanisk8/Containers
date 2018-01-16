using Xunit;
using Containers.Dictionary;

public class XUnitTestDictionary
{
   private readonly string zero = "zero";
   private readonly string one = "one";
   private readonly string two = "two";
   private readonly string three = "three";
   private readonly string four = "four";

   [Fact]
   public void AddTest()
   {
      IDictionary<int, string> dic = new Dictionary<int, string>();

      dic.Add(0, zero);
      dic.Add(1, one);
      dic.Add(2, two);
      dic.Add(3, three);
      dic.Add(4, four);

      CheckListOrder(dic);
   }

   private void CheckListOrder(IDictionary<int, string> dic)
   {

      Assert.Equal(dic.IsEmpty, false);
      Assert.Equal(dic.Count, (uint)5);
      Assert.Equal(dic.Root.Parent, null);

      //0
      Assert.Equal(dic.Root.Key, 0);
      Assert.Equal(dic.Root.Value, zero);

      //1
      Assert.Equal(dic.Root.RChild.Key, 1);
      Assert.Equal(dic.Root.RChild.Value, one);
      Assert.Equal(dic.Root.LChild, null);
      Assert.Equal(dic.Root.RChild.LChild, null);

      //2
      Assert.Equal(dic.Root.RChild.RChild.Key, 2);
      Assert.Equal(dic.Root.RChild.RChild.Value, two);
      Assert.Equal(dic.Root.RChild.LChild, null);
      Assert.Equal(dic.Root.RChild.RChild.LChild, null);

      //3
      Assert.Equal(dic.Root.RChild.RChild.RChild.Key, 3);
      Assert.Equal(dic.Root.RChild.RChild.RChild.Value, three);
      Assert.Equal(dic.Root.RChild.RChild.LChild, null);
      Assert.Equal(dic.Root.RChild.RChild.RChild.LChild, null);

      //4
      Assert.Equal(dic.Root.RChild.RChild.RChild.RChild.Key, 4);
      Assert.Equal(dic.Root.RChild.RChild.RChild.RChild.Value, four);
      Assert.Equal(dic.Root.RChild.RChild.RChild.LChild, null);
      Assert.Equal(dic.Root.RChild.RChild.RChild.RChild.LChild, null);
   }
}