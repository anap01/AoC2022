namespace AoC2022;

[TestClass]
public class Day4 : AoCTestClass
{
    [TestMethod]
    public void Part1()
    {
        var input = DayInputLines();
        var pairs = 0;
        foreach (var line in input)
        {
            var elfSection = line.Split(",");
            var s1 = elfSection[0].Split("-").Select(int.Parse).ToArray();
            var s2 = elfSection[1].Split("-").Select(int.Parse).ToArray();
            if ((s2[0] >= s1[0] && s2[1] <= s1[1]) ||
                (s1[0] >= s2[0] && s1[1] <= s2[1]))
            {
                pairs++;
            }
        }

        TestContext.WriteLine($"{pairs}");
    }
    
    [TestMethod]
    public void Part2()
    {
        var input = DayInputLines();
        var pairs = 0;
        foreach (var line in input)
        {
            var elfSection = line.Split(",");
            var s1 = elfSection[0].Split("-").Select(int.Parse).ToArray();
            var s2 = elfSection[1].Split("-").Select(int.Parse).ToArray();
            if (s2[0] > s1[1] || s1[1] < s2[0] || s1[0] > s2[1] || s1[1] < s2[0])
            {
                continue;
            }
            pairs++;
        }

        TestContext.WriteLine($"{pairs}");
    }
    
    private const string TestInput = @"2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8";
    
}