using System.Text.RegularExpressions;

namespace AoC2022;

[TestClass]
public class Day5 : AoCTestClass
{
    [TestMethod]
    public void Part1()
    {
        const int noCrates = 9;
        var input = DayInput().EnumerateLines();
        var crateInput = input.Take(8).Reverse();
        var crates = new Stack<char>[noCrates];
        for (var i = 0; i < noCrates; i++)
        {
            crates[i] = new Stack<char>();
        }
        foreach (var row in crateInput)
        {
            for (int i = 0; i < noCrates; i++)
            {
                var crate = row[1 + (i * 4)];
                if (crate >= 'A')
                    crates[i].Push(crate);
            }
        }

        foreach (var row in input.Skip(10))
        {
            var regex = new Regex("move (?<no>\\d+) from (?<src>\\d+) to (?<dst>\\d+)");
            var match = regex.Match(row);
            var no = int.Parse(match.Groups["no"].Value);
            var src = int.Parse(match.Groups["src"].Value);
            var dst = int.Parse(match.Groups["dst"].Value);
            for (var i = 0; i < no; i++)
            {
                crates[dst - 1].Push(crates[src - 1].Pop());
            }
        }

        foreach (var crate in crates)
        {
            TestContext.Write($"{crate.Peek()}");
        }
    }
    
    [TestMethod]
    public void Part2()
    {
        const int noCrates = 9;
        var input = DayInput().EnumerateLines();
        var crateInput = input.Take(8).Reverse();
        var crates = new Stack<char>[noCrates];
        for (var i = 0; i < noCrates; i++)
        {
            crates[i] = new Stack<char>();
        }
        foreach (var row in crateInput)
        {
            for (int i = 0; i < noCrates; i++)
            {
                var crate = row[1 + (i * 4)];
                if (crate >= 'A')
                    crates[i].Push(crate);
            }
        }

        foreach (var row in input.Skip(10))
        {
            var regex = new Regex("move (?<no>\\d+) from (?<src>\\d+) to (?<dst>\\d+)");
            var match = regex.Match(row);
            var no = int.Parse(match.Groups["no"].Value);
            var src = int.Parse(match.Groups["src"].Value);
            var dst = int.Parse(match.Groups["dst"].Value);
            var tmp = new Stack<char>();
            for (var i = 0; i < no; i++)
            {
                tmp.Push(crates[src - 1].Pop());
            }
            for (var i = 0; i < no; i++)
            {
                crates[dst - 1].Push(tmp.Pop());
            }
        }

        foreach (var crate in crates)
        {
            TestContext.Write($"{crate.Peek()}");
        }
    }
    
    private const string TestInput = @"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2";
    
}