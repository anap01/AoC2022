namespace AoC2022;

[TestClass]
public class Day2 : AoCTestClass
{
    private readonly Dictionary<(string, string), int> _mResult1 = new()
    {
        { ("A", "X"), 1 + 3},
        { ("A", "Y"), 2 + 6},
        { ("A", "Z"), 3 },
        { ("B", "X"), 1 },
        { ("B", "Y"), 2 + 3},
        { ("B", "Z"), 3 + 6},
        { ("C", "X"), 1 + 6},
        { ("C", "Y"), 2 },
        { ("C", "Z"), 3 + 3},
    };
    
    private readonly Dictionary<(string, string), int> _mResult2 = new()
    {
        { ("A", "X"), 0 + 3},
        { ("A", "Y"), 3 + 1},
        { ("A", "Z"), 6 + 2},
        { ("B", "X"), 0 + 1},
        { ("B", "Y"), 3 + 2},
        { ("B", "Z"), 6 + 3},
        { ("C", "X"), 0 + 2},
        { ("C", "Y"), 3 + 3},
        { ("C", "Z"), 6 + 1},
    };
    
    [TestMethod]
    public void Part1()
    {
        var input = DayInput();
        var stringReader = new StringReader(input);
        var score = 0;
        while (stringReader.ReadLine() is { } line)
        {
            var round = line.Split(" ");
            score += _mResult1[(round[0], round[1])];
        }

        TestContext.WriteLine($"{score}");
    }
    
    [TestMethod]
    public void Part2()
    {
        var input = DayInput();
        var stringReader = new StringReader(input);
        var score = 0;
        while (stringReader.ReadLine() is { } line)
        {
            var round = line.Split(" ");
            score += _mResult2[(round[0], round[1])];
        }

        TestContext.WriteLine($"{score}");
    }
    
    private const string TestInput = @"A Y
B X
C Z";
    
}