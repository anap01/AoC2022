namespace AoC2022;

[TestClass]
public class Day9 : AoCTestClass
{
    [TestMethod]
    public void Part1()
    {
        var input = DayInput.EnumerateLines();
        // input = TestInput.EnumerateLines();
        var head = (row: 0, col: 0);
        var tail = (row: 0, col: 0);
        var visited = new HashSet<(int, int)> { tail };
        foreach (var line in input)
        {
            for (int i = 0; i < int.Parse(line[2..]); i++)
            {
                MoveHead(line[0]);
                MoveTail();
            }
        }

        TestContext.Write($"{visited.Count}");

        void MoveHead(char dir)
        {
            switch (dir)
            {
                case 'U':
                    head.row++;
                    break;
                case 'D':
                    head.row--;
                    break;
                case 'R':
                    head.col++;
                    break;
                case 'L':
                    head.col--;
                    break;
            }
        }

        void MoveTail()
        {
            if (Adjacent())
                return;
            var dx = Math.Sign(head.col - tail.col);
            var dy = Math.Sign(head.row - tail.row);
            tail.col += dx;
            tail.row += dy;
            visited.Add(tail);
        }

        bool Adjacent()
        {
            var dx = Math.Abs(head.col - tail.col);
            var dy = Math.Abs(head.row - tail.row);
            return dy <= 1 && dx <= 1;
        }
    }

    [TestMethod]
    public void Part2()
    {
        var input = DayInput.EnumerateLines();
        // input = TestInput2.EnumerateLines();
        var knots = new (int, int)[10];
        var visited = new HashSet<(int, int)> { knots[9] };
        foreach (var line in input)
        {
            for (int i = 0; i < int.Parse(line[2..]); i++)
            {
                MoveHead(line[0]);
                MoveTails();
            }
        }
        TestContext.Write($"{visited.Count}");

        void MoveHead(char dir)
        {
            switch (dir)
            {
                case 'U':
                    knots[0].Item1++;
                    break;
                case 'D':
                    knots[0].Item1--;
                    break;
                case 'R':
                    knots[0].Item2++;
                    break;
                case 'L':
                    knots[0].Item2--;
                    break;
            }
        }

        void MoveTails()
        {
            for (var i = 1; i < knots.Length; i++)
            {
                if (Adjacent(knots[i], knots[i - 1]))
                    continue;
                var dx = Math.Sign(knots[i - 1].Item2 - knots[i].Item2);
                var dy = Math.Sign(knots[i - 1].Item1 - knots[i].Item1);
                knots[i].Item2 += dx;
                knots[i].Item1 += dy;
                
            }
            visited.Add(knots[9]);
        }

        bool Adjacent((int, int) knot1, (int, int) knot2)
        {
            var dx = Math.Abs(knot1.Item2 - knot2.Item2);
            var dy = Math.Abs(knot1.Item1 - knot2.Item1);
            return dy <= 1 && dx <= 1;
        } 
    }

    private const string TestInput = @"R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2";
    
    private const string TestInput2 = @"R 5
U 8
L 8
D 3
R 17
D 10
L 25
U 20";
}