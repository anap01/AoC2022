using System.Text.RegularExpressions;

namespace AoC2022;

[TestClass]
public class Day21 : AoCTestClass
{
    [TestMethod]
    public void Part1()
    {
        var input = DayInput.EnumerateLines();
        // input = TestInput.EnumerateLines();
        var monkeys = new Dictionary<string, Func<long>>();
        foreach (var line in input)
        {
            var split = line.Split(": ");
            if (Regex.IsMatch(split[1], @"\d+"))
            {
                monkeys.Add(split[0], () => long.Parse(split[1]));
            }
            else
            {
                var strings = split[1].Split(' ');
                monkeys.Add(split[0], () => Operate(monkeys[strings[0]](), monkeys[strings[2]](), strings[1]));
            }
        }
        TestContext.Write($"{monkeys["root"]()}");
    }

    private static long Operate(long first, long second, string op)
    {
        switch (op)
        {
            case "+":
                return first + second;
            case "-":
                return first - second;
            case "*":
                return first * second;
            case "/":
                return first / second;
        }

        throw new InvalidOperationException();
    }

    [TestMethod]
    public void Part2()
    {
        var input = DayInput.EnumerateLines();
        input = TestInput.EnumerateLines();
        TestContext.Write($"");
    }

    private const string TestInput = @"root: pppw + sjmn
dbpl: 5
cczh: sllz + lgvd
zczc: 2
ptdq: humn - dvpt
dvpt: 3
lfqf: 4
humn: 5
ljgn: 2
sjmn: drzm * dbpl
sllz: 4
pppw: cczh / lfqf
lgvd: ljgn * ptdq
drzm: hmdt - zczc
hmdt: 32";
}