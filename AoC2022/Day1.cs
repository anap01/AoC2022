namespace AoC2022;

[TestClass]
public class Day1 : AoCTestClass
{
    [TestMethod]
    public void Part1()
    {
        var input = DayInput;
        var stringReader = new StringReader(input);
        var max = 0;
        var current = 0;
        while (stringReader.ReadLine() is { } line)
        {
            if (line == "")
            {
                max = Math.Max(current, max);
                current = 0;
                continue;
            }
            var value = int.Parse(line);
            current += value;
        }
        max = Math.Max(current, max);

        TestContext.WriteLine($"{max}");
    }

    [TestMethod]
    public void Part2()
    {
        var result = Calories().OrderByDescending(i => i).Take(3).Sum();

        TestContext.WriteLine($"{result}");
    }

    private IEnumerable<int> Calories()
    {
        var input = DayInput;
        var stringReader = new StringReader(input);
        var current = 0;
        while (stringReader.ReadLine() is { } line)
        {
            if (line == "")
            {
                yield return current;
                current = 0;
                continue;
            }

            var value = int.Parse(line);
            current += value;
        }

        yield return current;
    }

    private const string TestInput = @"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000";
    
}