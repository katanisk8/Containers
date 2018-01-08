using Xunit;
using Containers.Dictionary;

public class XUnitTestDictionary
{
    [Fact]
    public void AddTest()
    {
        Dictionary<int, string> dictionary = new Dictionary<int, string>();

        dictionary.Add(0, "zero");
        dictionary.Add(1, "jeden");
        dictionary.Add(2, "dwa");
        dictionary.Add(3, "trzy");
        dictionary.Add(4, "cztery");
    }
}