namespace AoC2022;

[TestClass]
public class Day25 : AoCTestClass
{
    private readonly Dictionary<int,long> m_power = new();
    private readonly Dictionary<char, int> m_value = new()
    {
        { '2', 2 },
        { '1', 1 },
        { '0', 0 },
        { '-', -1 },
        { '=', -2 }
    };
    
    [TestMethod]
    public void Part1()
    {
        var input = DayInput.EnumerateLines();
        // input = TestInput.EnumerateLines();
        var sum = 0L;
        foreach (var line in input)
        {
            var snafu = line.ToArray();
            for (var i = 0; i < snafu.Length; i++)
            {
                var power = GetPower(snafu.Length - 1 -i);
                sum += m_value[snafu[i]] * power;
            }
        }

        TestContext.Write($"{ToSnafu(sum)}");
    }
    
    private static string ToSnafu(long value)
    {
        var pos = new List<long>();
        while (value > 0)
        {
            var remainder = value % 5;
            value /= 5;            
            if (remainder > 2)
            {
                remainder -= 5;
                value += 1;
            }
            pos.Add(remainder);
        }

        pos.Reverse();
        return new string(pos.Select(GetChar).ToArray());
    }

    private static char GetChar(long c) => c switch
    {
        2 => '2',
        1 => '1',
        0 => '0',
        -1 => '-',
        -2 => '=',
        _ => throw new Exception($"Unsupported value '{c}'")
    };

    [TestMethod]
    public void TestSnafu()
    {
        TestContext.WriteLine(ToSnafu(1));
        TestContext.WriteLine(ToSnafu(2));
        TestContext.WriteLine(ToSnafu(3));
        TestContext.WriteLine(ToSnafu(4));
        TestContext.WriteLine(ToSnafu(5));
        TestContext.WriteLine(ToSnafu(6));
        TestContext.WriteLine(ToSnafu(7));
        TestContext.WriteLine(ToSnafu(8));
        TestContext.WriteLine(ToSnafu(9));
        TestContext.WriteLine(ToSnafu(10));
        TestContext.WriteLine(ToSnafu(15));
        TestContext.WriteLine(ToSnafu(20));
        TestContext.WriteLine(ToSnafu(2022));
        TestContext.WriteLine(ToSnafu(12345));
        TestContext.WriteLine(ToSnafu(314159265));
    }
    private long GetPower(int pos)
    {
        if (m_power.TryGetValue(pos, out var value)) 
            return value;

        return m_power[pos] = (long)Math.Pow(5, pos);
    }

    [TestMethod]
    public void Part2()
    {
        var input = DayInput.EnumerateLines();
        input = TestInput.EnumerateLines();
        TestContext.Write($"");
    }

    private const string TestInput = @"1=-0-2
12111
2=0=
21
2=01
111
20012
112
1=-1=
1-12
12
1=
122";
}