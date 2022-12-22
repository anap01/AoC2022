namespace AoC2022;

[TestClass]
public class Day12 : AoCTestClass
{
    [TestMethod]
    public void Part1()
    {
        var input = DayInput.EnumerateLines();
        // input = TestInput.EnumerateLines();
        var heightmap = input.Select(r => r.ToArray()).ToArray();
        var start = Find('S');
        heightmap[start.y][start.x] = 'a';
        var end = Find('E');
        heightmap[end.y][end.x] = 'z';
        (int x, int y) Find(char c)
        {
            for (var row = 0; row < heightmap.Length; row++)
            {
                for (var col = 0; col < heightmap[row].Length; col++)
                {
                    if (heightmap[row][col] == c)
                    {
                        return (col, row);
                    }
                }
            }
            throw new Exception("Start not found");
        }
        
        var openSet = new Dictionary<(int x, int y), int>();
        openSet[start] = 0;
        var visited = new HashSet<(int, int)>();
        while (openSet.Count > 0)
        {
            var minScore = openSet.Values.Min();
            var (node, score) = openSet.First(kvp => kvp.Value == minScore);
            if (node == end)
                TestContext.WriteLine($"{score}");

            openSet.Remove(node);
            visited.Add(node);
            foreach (var dest in Destinations(node).Where(n => !visited.Contains(n)))
            {
                var testScore = score + 1;
                if (openSet.TryGetValue(dest, out var currentScore))
                {
                    if (testScore < currentScore)
                        openSet[dest] = testScore;
                }
                else
                {
                    openSet[dest] = testScore;
                }
            }

            IEnumerable<(int, int)> Destinations((int x, int y) coord)
            {
                var currentElevation = heightmap[coord.y][coord.x];
                if (node.x > 0 && Reachable(coord.x - 1, coord.y))
                    yield return (node.x - 1, node.y);
                if (node.x < heightmap[node.y].Length - 1 && Reachable(coord.x + 1, coord.y))
                    yield return (node.x + 1, node.y);
                if (node.y > 0 && Reachable(coord.x, coord.y - 1))
                    yield return (node.x, node.y - 1);
                if (node.y < heightmap.Length - 1 && Reachable(coord.x, coord.y + 1))
                    yield return (node.x, node.y + 1);
                
                bool Reachable(int x, int y)
                {
                    return heightmap[y][x] - currentElevation <= 1;
                }
            }
        }
    }

    [TestMethod]
    public void Part2()
    {
        var input = DayInput.EnumerateLines();
        input = TestInput.EnumerateLines();
        TestContext.Write($"");
    }

    private const string TestInput = @"Sabqponm
abcryxxl
accszExk
acctuvwj
abdefghi";
}