namespace AoC2022;

[TestClass]
public class Day8 : AoCTestClass
{
    [TestMethod]
    public void Part1()
    {
        var input = DayInput.EnumerateLines();
        // input = TestInput.EnumerateLines();
        var map = input.Select(c => c.Select(c => int.Parse(c.ToString())).ToArray()).ToArray();
        int visible = map.Length * 2 + map[0].Length * 2 - 4;
        for (int row = 1; row < map.Length - 1; row++)
        {
            for (int col = 1; col < map[row].Length - 1; col++)
            {
                if (Visible(row, col))
                    visible++;
            }
        }
        TestContext.Write($"{visible}");
        bool Visible(int r, int c)
        {
            var vis = true;
            int height = map[r][c];
            for (var i = r - 1; i >= 0; i--)
            {
                if (map[i][c] < height) 
                    continue;
                
                vis = false;
                break;
            }
            if (vis)
                return true;
            vis = true;
            for (var i = r + 1; i < map.Length; i++)
            {
                if (map[i][c] < height) 
                    continue;
                
                vis = false;
                break;
            }
            if (vis)
                return true;
            vis = true;
            for (var i = c - 1; i >= 0; i--)
            {
                if (map[r][i] < height) 
                    continue;
                
                vis = false;
                break;
            }
            if (vis)
                return true;
            vis = true;
            for (var i = c + 1; i < map[r].Length; i++)
            {
                if (map[r][i] < height) 
                    continue;
                
                vis = false;
                break;
            }
            return vis;
        }
    }

    [TestMethod]
    public void Part2()
    {
        var input = DayInput.EnumerateLines();
        // input = TestInput.EnumerateLines();
        var map = input.Select(c => c.Select(c => int.Parse(c.ToString())).ToArray()).ToArray();
        var score = 0;
        for (int row = 1; row < map.Length - 1; row++)
        {
            for (int col = 1; col < map[row].Length - 1; col++)
            {
                score = Math.Max(score, Score(row, col));
            }
        }
        TestContext.Write($"{score}");
        int Score(int r, int c)
        {
            var score = 1;
            var height = map[r][c];
            int i;
            for (i = r - 1; i >= 0; i--)
            {
                if (map[i][c] >= height)
                {
                    break;
                }
            }

            var trees = r - i - (i < 0 ? 1 : 0);
            score *= trees;
            for (i = r + 1; i < map.Length; i++)
            {
                if (map[i][c] >= height)
                {
                    break;
                }
            }
            trees = i - r - (i == map.Length ? 1 : 0);
            score *= trees;
            for (i = c - 1; i >= 0; i--)
            {
                if (map[r][i] >= height)
                {
                    break;
                }
            }

            trees = c - i - (i < 0 ? 1 : 0);
            score *= trees;
            for (i = c + 1; i < map[r].Length; i++)
            {
                if (map[r][i] >= height)
                {
                    break;
                }
            }

            trees = i - c - (i == map[r].Length ? 1 : 0);
            score *= trees;
            return score;
        }
    }

    private const string TestInput = @"30373
25512
65332
33549
35390";
}