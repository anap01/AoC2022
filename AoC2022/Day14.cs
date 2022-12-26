using System.Collections;

namespace AoC2022;

[TestClass]
public class Day14 : AoCTestClass
{
    [TestMethod]
    public void Part1()
    {
        var input = DayInput.EnumerateLines();
        // input = TestInput.EnumerateLines();
        var caves = new Dictionary<(int, int), char>();
        var maxY = 0;
        foreach (var line in input)
        {
            IEnumerable<(int x, int y)>? points = line.Split(" -> ").Select(c => c.Split(",").Select(int.Parse).ToArray()).Select(c => (c[0], c[1]));
            var enumerator = points.GetEnumerator();
            enumerator.MoveNext();
            var first = enumerator.Current;
            while (enumerator.MoveNext())
            {
                var second = enumerator.Current;
                (int x, int y) min = (Math.Min(first.x, second.x), Math.Min(first.y, second.y));
                (int x, int y) max = (Math.Max(first.x, second.x), Math.Max(first.y, second.y));
                maxY = Math.Max(maxY, max.y);
                var d1 = Math.Sign(max.x - min.x);
                var d2 = Math.Sign(max.y - min.y);
                for (var i = min;
                     i.x <= max.x && i.y <= max.y;
                     i = (i.x + d1, i.y + d2))
                {
                    caves[i] = '#';
                }

                first = second;
            }
        }

        var placed = true;
        do
        {
            var grain = (500, 0);
            bool dropped;
            do
            {
                dropped = false;
                foreach (var test in Test(grain))
                {
                    if (caves.ContainsKey(test))
                        continue;
                    
                    caves.Remove(grain);
                    
                    if (grain.Item2 > maxY)
                    {
                        placed = false;
                        break;
                    }

                    dropped = true;
                    grain = test;
                    caves[grain] = 'o';
                    break;
                }
            } while (dropped);
        } while (placed);

        TestContext.Write($"{caves.Values.Count(c => c == 'o')}");
        
    }

    private IEnumerable<(int x, int y)> Test((int x, int y) grain)
    {
        yield return (grain.x, grain.y + 1);
        yield return (grain.x - 1, grain.y + 1);
        yield return (grain.x + 1, grain.y + 1);
    }

    [TestMethod]
    public void Part2()
    {
        var input = DayInput.EnumerateLines();
        // input = TestInput.EnumerateLines();
        var caves = new Dictionary<(int, int), char>();
        var maxY = 0;
        foreach (var line in input)
        {
            IEnumerable<(int x, int y)>? points = line.Split(" -> ").Select(c => c.Split(",").Select(int.Parse).ToArray()).Select(c => (c[0], c[1]));
            var enumerator = points.GetEnumerator();
            enumerator.MoveNext();
            var first = enumerator.Current;
            while (enumerator.MoveNext())
            {
                var second = enumerator.Current;
                (int x, int y) min = (Math.Min(first.x, second.x), Math.Min(first.y, second.y));
                (int x, int y) max = (Math.Max(first.x, second.x), Math.Max(first.y, second.y));
                maxY = Math.Max(maxY, max.y);
                var d1 = Math.Sign(max.x - min.x);
                var d2 = Math.Sign(max.y - min.y);
                for (var i = min;
                     i.x <= max.x && i.y <= max.y;
                     i = (i.x + d1, i.y + d2))
                {
                    caves[i] = '#';
                }

                first = second;
            }
        }

        (int, int) grain;
        do
        {
            grain = (500, 0);
            bool dropped;
            do
            {
                dropped = false;
                foreach (var test in Test(grain))
                {
                    if (caves.ContainsKey(test))
                        continue;
                    
                    caves.Remove(grain);
                    grain = test;
                    caves[grain] = 'o';
                    dropped = true;
                    break;
                }
            } while (dropped && grain.Item2 != maxY + 1);
        } while (grain != (500, 0));

        TestContext.Write($"{caves.Values.Count(c => c == 'o') + 1}");
        
    }

    private const string TestInput = @"498,4 -> 498,6 -> 496,6
503,4 -> 502,4 -> 502,9 -> 494,9";
}