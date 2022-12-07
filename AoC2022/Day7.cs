namespace AoC2022;

public class Dir
{
    public Dir(string name)
    {
        Name = name;
    }
    public string Name { get; set; }
    public List<Dir> Subdirs { get; set; } = new();
    public List<File> Files { get; set; } = new();

    public long Size => Files.Sum(f => f.Size) + Subdirs.Sum(d => d.Size);
}

public class File
{
    public File(string name, long size)
    {
        Name = name;
        Size = size;
    }

    public string Name { get; set; }
    public long Size { get; set; }
}

[TestClass]
public class Day7 : AoCTestClass
{
    [TestMethod]
    public void Part1and2()
    {
        var input = DayInput.EnumerateLines();
        var currentDir = new Stack<Dir>();
        var allDirs = new HashSet<Dir>();
        var root = new Dir("/");
        allDirs.Add(root);
        foreach (var line in input)
        {
            if (line.StartsWith("$ cd /"))
            {
                currentDir.Clear();
                currentDir.Push(root);
                continue;
            }
            if (line.StartsWith("$ cd .."))
            {
                currentDir.Pop();
                continue;
            }
            if (line.StartsWith("$ ls"))
                continue;
            if (line.StartsWith("$ cd"))
            {
                currentDir.Push(currentDir.Peek().Subdirs.First(d => d.Name == line[5..]));
                continue;
            }
            if (line.StartsWith("dir "))
            {
                var newDir = new Dir(line[4..]);
                currentDir.Peek().Subdirs.Add(newDir);
                allDirs.Add(newDir);
                continue;
            }

            var fileInput = line.Split(' ');
            currentDir.Peek().Files.Add(new File(fileInput[1], int.Parse(fileInput[0])));
        }

        var sum = allDirs.Where(d => d.Size <= 100000).Sum(d => d.Size);
        TestContext.WriteLine($"{sum}");
        var currentFree = 70_000_000 - root.Size;
        var needed = 30_000_000 - currentFree;
        var dir = allDirs.OrderBy(d => d.Size).First(d => d.Size > needed);
        TestContext.WriteLine($"{dir.Name} {dir.Size}");
    }


    private const string TestInput = @"$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k";
}