namespace AoC2022;

[TestClass]
public class Day10 : AoCTestClass
{
    [TestMethod]
    public void Part1()
    {
        var input = DayInput.EnumerateLines();
        // input = TestInput.EnumerateLines();
        var cycle = 0;
        var X = 1;
        var cycles = new Stack<int>(new[] { 220, 180, 140, 100, 60, 20 });
        var signalStrength = 0;
        foreach (var line in input)
        {
            var addCycle = 1;
            var addX = 0;
            if (line.StartsWith("addx"))
            {
                addCycle = 2;
                addX = int.Parse(line[5..]);
            }

            cycle += addCycle;
            if (cycles.Count > 0 && cycle >= cycles.Peek())
            {
                var theCycle = cycles.Pop();
                signalStrength += X * theCycle;
            }

            X += addX;
        }
        TestContext.Write($"{signalStrength}");
    }

    [TestMethod]
    public void Part2()
    {
        var input = DayInput.EnumerateLines();
        // input = TestInput.EnumerateLines();
        var cycle = 0;
        var X = 1;
        foreach (var line in input)
        {
            Print(cycle, X);
            if (line.StartsWith("addx"))
            {
                cycle++;
                Print(cycle, X);
                X += int.Parse(line[5..]);
            }

            cycle++;
        }
    }

    private void Print(int cycle, int X)
    {
        if (Math.Abs(cycle % 40 - X) <= 1)
            TestContext.Write("#");
        else
            TestContext.Write(".");
        if (cycle % 40 == 39)
            TestContext.WriteLine("");
    }

    private const string TestInput = @"addx 15
addx -11
addx 6
addx -3
addx 5
addx -1
addx -8
addx 13
addx 4
noop
addx -1
addx 5
addx -1
addx 5
addx -1
addx 5
addx -1
addx 5
addx -1
addx -35
addx 1
addx 24
addx -19
addx 1
addx 16
addx -11
noop
noop
addx 21
addx -15
noop
noop
addx -3
addx 9
addx 1
addx -3
addx 8
addx 1
addx 5
noop
noop
noop
noop
noop
addx -36
noop
addx 1
addx 7
noop
noop
noop
addx 2
addx 6
noop
noop
noop
noop
noop
addx 1
noop
noop
addx 7
addx 1
noop
addx -13
addx 13
addx 7
noop
addx 1
addx -33
noop
noop
noop
addx 2
noop
noop
noop
addx 8
noop
addx -1
addx 2
addx 1
noop
addx 17
addx -9
addx 1
addx 1
addx -3
addx 11
noop
noop
addx 1
noop
addx 1
noop
noop
addx -13
addx -19
addx 1
addx 3
addx 26
addx -30
addx 12
addx -1
addx 3
addx 1
noop
noop
noop
addx -9
addx 18
addx 1
addx 2
noop
noop
addx 9
noop
noop
noop
addx -1
addx 2
addx -37
addx 1
addx 3
noop
addx 15
addx -21
addx 22
addx -6
addx 1
noop
addx 2
addx 1
noop
addx -10
noop
noop
addx 20
addx 1
addx 2
addx 2
addx -6
addx -11
noop
noop
noop";
}