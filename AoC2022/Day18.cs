namespace AoC2022;

[TestClass]
public class Day18 : AoCTestClass
{
    [TestMethod]
    public void Part1()
    {
        var input = DayInput.EnumerateLines();
        // input = TestInput.EnumerateLines();
        var droplets = new HashSet<(int, int, int)>();
        foreach (var line in input)
        {
            var coords = line.Split(',').Select(int.Parse).ToArray();
            droplets.Add((coords[0], coords[1], coords[2]));
        }

        var surface = 0;
        foreach (var droplet in droplets)
        {
            surface += 6 - AllDirections(droplet).Count(d => droplets.Contains(d));
        }
        TestContext.Write($"{surface}");
    }

    private IEnumerable<(int, int, int)> AllDirections((int x, int y, int z) droplet)
    {
        yield return (droplet.x - 1, droplet.y, droplet.z);
        yield return (droplet.x + 1, droplet.y, droplet.z);
        yield return (droplet.x, droplet.y - 1, droplet.z);
        yield return (droplet.x, droplet.y + 1, droplet.z);
        yield return (droplet.x, droplet.y, droplet.z - 1);
        yield return (droplet.x, droplet.y, droplet.z + 1);
    }

    [TestMethod]
    public void Part2()
    {
        var input = DayInput.EnumerateLines();
        input = TestInput.EnumerateLines();
        TestContext.Write($"");
    }

    private const string TestInput = @"2,2,2
1,2,2
3,2,2
2,1,2
2,3,2
2,2,1
2,2,3
2,2,4
2,2,6
1,2,5
3,2,5
2,1,5
2,3,5";
}