namespace AoC2022;

[TestClass]
public class Day6 : AoCTestClass
{
    [TestMethod]
    public void Part1()
    {
        var input = DayInput;
        var list = new List<char>();
        foreach (var (c, i) in input.Select((c, i) => (c, i)))
        {
            list.Add(c);
            if (list.Count == 4)
            {
                if (list.ToHashSet().Count == 4)
                {
                    TestContext.Write($"{i + 1}");
                    break;
                }
                list.RemoveAt(0);
            }
        }
    }

    [TestMethod]
    public void Part2()
    {
        var input = DayInput;
        var list = new List<char>();
        foreach (var (c, i) in input.Select((c, i) => (c, i)))
        {
            list.Add(c);
            if (list.Count == 14)
            {
                if (list.ToHashSet().Count == 14)
                {
                    TestContext.Write($"{i + 1}");
                    break;
                }

                list.RemoveAt(0);
            }
        }
    }

    private const string TestInput1 = @"mjqjpqmgbljsphdztnvjfqwrcgsmlb";
    private const string TestInput2 = @"bvwbjplbgvbhsrlpgdmjqwftvncz";
    private const string TestInput3 = @"nppdvjthqldpwncqszvftbrmjlhg";
    private const string TestInput4 = @"mjqjpqmgbljsphdztnvjfqwrcgsmlb";
    private const string TestInput5 = @"mjqjpqmgbljsphdztnvjfqwrcgsmlb";
    
}