namespace AoC2022;

[TestClass]
public class Day3 : AoCTestClass
{
    [TestMethod]
    public void Part1()
    {
        var input = DayInput();
        var stringReader = new StringReader(input);
        var score = 0;
        while (stringReader.ReadLine() is { } line)
        {
            var size = line.Length/2;
            var intersect = line.Take(size).Intersect(line.Skip(size));
            var common = intersect.First();
            score += common - (char.IsUpper(common) ? 'A' - 27 : 'a' - 1);
        }

        TestContext.WriteLine($"{score}");
    }
    
    [TestMethod]
    public void Part2()
    {
        var input = DayInput();
        var stringReader = new StringReader(input);
        var score = 0;
        var previous = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        var i = 1;

        while (stringReader.ReadLine() is { } line)
        {
            previous = new string(line.Intersect(previous).ToArray());
            if (i % 3 == 0)
            {
                var common = previous.First();
                score += common - (char.IsUpper(common) ? 'A' - 27 : 'a' - 1);
                previous = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            }

            i++;
        }

        TestContext.WriteLine($"{score}");
    }
    
    private const string TestInput = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw";
    
}