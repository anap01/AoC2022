using System.Diagnostics;

namespace AoC2022;

[TestClass]
public class Day23 : AoCTestClass
{
    [TestMethod]
    public void Part1()
    {
        var input = DayInput.EnumerateLines();
        // input = TestInput2.EnumerateLines();
        var elves = input.SelectMany((line, row) => line.Select((c, col) => (c, col)).Where(c => c.c == '#').Select((c) => (row, c.col))).ToHashSet();
        var dir = new[] { 'N', 'S', 'W', 'E' };

        for (int round = 0; round < 10; round++)
        {
            var proposal = new Dictionary<(int row, int col), (int row, int col)>();

            foreach (var elf in elves)
            {
                var occupiedDirs = GetOccupiedDirs(elf).ToList();
                if (occupiedDirs.Count == 0)
                    continue;

                for (int i = 0; i < 4; i++)
                {
                    var direction = dir[(round + i) % 4];
                    if (occupiedDirs.Contains(direction) == false)
                    {
                        proposal[elf] = GetPosition(direction, elf);
                        break;
                    }
                }
            }

            var groupBy = proposal.GroupBy(kvp => kvp.Value);
            foreach (var destination in groupBy)
            {
                if (destination.Count() > 1)
                    continue;

                var keyValuePair = destination.Single();
                elves.Remove(keyValuePair.Key);
                elves.Add(keyValuePair.Value);
            }
        }

        IEnumerable<char> GetOccupiedDirs((int row, int col) elf)
        {
            if (elves.Any(e => e.row == elf.row - 1 && e.col >= elf.col - 1 && e.col <= elf.col + 1))
                yield return 'N';
            if (elves.Any(e => e.row == elf.row + 1 && e.col >= elf.col - 1 && e.col <= elf.col + 1))
                yield return 'S';
            if (elves.Any(e => e.col == elf.col - 1 && e.row >= elf.row - 1 && e.row <= elf.row + 1))
                yield return 'W';
            if (elves.Any(e => e.col == elf.col + 1 && e.row >= elf.row - 1 && e.row <= elf.row + 1))
                yield return 'E';
        }
        var minRow = elves.Min(e => e.row);
        var maxRow = elves.Max(e => e.row);
        var minCol = elves.Min(e => e.col);
        var maxCol = elves.Max(e => e.col);
        TestContext.Write($"{(maxRow - minRow + 1) * (maxCol - minCol + 1) - elves.Count}");
    }

    private static (int row, int col) GetPosition(char direction, (int row, int col) elf)
    {
        switch (direction)
        {
            case 'N':
                return (elf.row - 1, elf.col);
            case 'S':
                return (elf.row + 1, elf.col);
            case 'W':
                return (elf.row, elf.col - 1);
            case 'E':
                return (elf.row, elf.col + 1);
        }

        throw new Exception("Unknown direction");
    }

    private void DebugOutput(HashSet<(int row, int col)> elves)
    {
        var minRow = elves.Min(e => e.row);
        var maxRow = elves.Max(e => e.row);
        var minCol = elves.Min(e => e.col);
        var maxCol = elves.Max(e => e.col);
        for (var row = minRow; row <= maxRow; row++)
        {
            for (var col = minCol; col <= maxCol; col++)
            {
                Debug.Write(elves.Contains((row, col)) ? "#" : ".");
            }
            Debug.WriteLine("");
        }
    }
    
    [TestMethod]
    public void Part2()
    {
        var input = DayInput.EnumerateLines();
        input = TestInput.EnumerateLines();
        TestContext.Write($"");
    }

    private const string TestInput = @".....
..##.
..#..
.....
..##.
.....";
    
    private const string TestInput2 = @"....#..
..###.#
#...#.#
.#...##
#.###..
##.#.##
.#..#..";
}