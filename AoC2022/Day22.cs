using System.Collections;

namespace AoC2022;

[TestClass]
public class Day22 : AoCTestClass
{
    [TestMethod]
    public void Part1()
    {
        using var reader = new StringReader(DayInput);
        var map = ReadMap(reader, out var start);
        (int row, int col)[] delta = { (0, 1), (1, 0), (0, -1), (-1, 0) };
        var facing = 0;
        var pos = start;
        foreach (var instruction in ReadInstruction(reader))
        {
            switch (instruction)
            {
                case 'R':
                    facing = (facing + 1) % 4;
                    break;
                case 'L':
                    facing = (facing + 3) % 4;
                    break;
                default:
                    for (var i = 0; i < (int)instruction; i++)
                    {
                        var test = (pos.row + delta[facing].row, pos.col + delta[facing].col);
                        if (map.ContainsKey(test) == false)
                        {
                            test = facing switch
                            {
                                0 => (pos.row, map.Keys.Where(p => p.row == pos.row).Min(p => p.col)),
                                1 => (map.Keys.Where(p => p.col == pos.col).Min(p => p.row), pos.col),
                                2 => (pos.row, map.Keys.Where(p => p.row == pos.row).Max(p => p.col)),
                                3 => (map.Keys.Where(p => p.col == pos.col).Max(p => p.row), pos.col),
                                _ => throw new Exception()
                            };
                        }

                        if (map[test] == '.')
                            pos = test;
                        else if (map[test] == '#')
                            break;
                    }

                    break;
            }
        }
        TestContext.Write($"{1000L * pos.row + 4 * pos.col + facing}");
    }

    private IEnumerable ReadInstruction(StringReader reader)
    {
        var digit = 0;
        while (reader.Read() is { } c)
        {
            if (c == -1)
            {
                if (digit != 0)
                    yield return digit;
                yield break;
            }
            
            if (char.IsDigit((char)c))
                digit = digit * 10 + c - '0';
            if (c is not ('L' or 'R')) 
                continue;
            
            if (digit != 0)
            {
                yield return digit;
                digit = 0;
            }

            yield return (char)c;
        }
    }

    private static Dictionary<(int row, int col), char> ReadMap(StringReader reader, out (int row, int col) start)
    {
        var map = new Dictionary<(int row, int col), char>();
        var row = 1;
        start = (-1, -1);
        while (reader.ReadLine() is { } line)
        {
            if (line == "")
                break;
            foreach (var (c, col) in line.Select((c, col) => (c, col + 1)))
            {
                if (c == ' ') 
                    continue;
                
                if (start == (-1, -1))
                    start = (row, col);
                
                map.Add((row, col), c);
            }
            row++;
        }

        return map;
    }

    [TestMethod]
    public void Part2()
    {
        using var reader = new StringReader(DayInput);
        var map = ReadMap(reader, out var start);
        var width = map.Keys.Count(p => p.row == 1) / 2;
        (int row, int col)[] delta = { (0, 1), (1, 0), (0, -1), (-1, 0) };
        var facing = 0;
        var pos = start;
        foreach (var instruction in ReadInstruction(reader))
        {
            switch (instruction)
            {
                case 'R':
                    facing = (facing + 1) % 4;
                    break;
                case 'L':
                    facing = (facing + 3) % 4;
                    break;
                default:
                    for (var i = 0; i < (int)instruction; i++)
                    {
                        var test = (pos.row + delta[facing].row, pos.col + delta[facing].col);
                        var finalFacing = facing;
                        if (map.ContainsKey(test) == false)
                        {
                            switch (facing)
                            {
                                case 0:
                                    var side = (pos.row - 1) / width;
                                    switch (side)
                                    {
                                        case 0:
                                            test = (3 * width + 1 - pos.row, 2 * width);
                                            finalFacing = 2;
                                            break;
                                        case 1:
                                            test = (width, 2 * width + pos.row % width);
                                            finalFacing = 3;
                                            break;
                                        case 2:
                                            test = (width + 1 - pos.row % width, 3 * width);
                                            finalFacing = 2;
                                            break;
                                        case 3:
                                            test = (3 * width, width + pos.row % width);
                                            finalFacing = 3;
                                            break;
                                        default:
                                            throw new Exception();
                                    }

                                    break;
                                case 1:
                                    side = (pos.col - 1) / width;
                                    switch (side)
                                    {
                                        case 0:
                                            test = (1, 2 * width + pos.col);
                                            finalFacing = 1;
                                            break;
                                        case 1:
                                            test = (2 * width + pos.col, width);
                                            finalFacing = 2;
                                            break;
                                        case 2:
                                            test = (pos.col = width, 2 * width);
                                            finalFacing = 2;
                                            break;
                                        default:
                                            throw new Exception();
                                    }

                                    break;
                                case 2:
                                    side = (pos.row - 1) / width;
                                    switch (side)
                                    {
                                        case 0:
                                            test = (3 * width + 1 - pos.row % width, 1);
                                            finalFacing = 0;
                                            break;
                                        case 1:
                                            test = (2 * width + 1, pos.row - width);
                                            finalFacing = 1;
                                            break;
                                        case 2:
                                            test = (width + 1 - pos.row % width, width + 1);
                                            finalFacing = 0;
                                            break;
                                        case 3:
                                            test = (1, width + pos.row % width);
                                            finalFacing = 1;
                                            break;
                                        default:
                                            throw new Exception();
                                    }

                                    break;
                                case 3:
                                    side = (pos.col - 1) / width;
                                    switch (side)
                                    {
                                        case 0:
                                            test = (width + pos.col, width + 1);
                                            finalFacing = 0;
                                            break;
                                        case 1:
                                            test = (3 * width + pos.col % width, 1);
                                            finalFacing = 0;
                                            break;
                                        case 2:
                                            test = (4 * width, pos.col % width);
                                            finalFacing = 3;
                                            break;
                                        default:
                                            throw new Exception();
                                    }

                                    break;
                                default:
                                    throw new Exception();
                            }
                        }

                        if (map[test] == '.')
                        {
                            pos = test;
                            facing = finalFacing;
                        }
                        else if (map[test] == '#')
                            break;
                    }

                    break;
            }
        }
        TestContext.Write($"{1000L * pos.row + 4 * pos.col + facing}");
    }

    private const string TestInput = @"        ...#
        .#..
        #...
        ....
...#.......#
........#...
..#....#....
..........#.
        ...#....
        .....#..
        .#......
        ......#.

10R5L5R10L4R5L5";
}