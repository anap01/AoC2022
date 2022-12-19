using System.Text.RegularExpressions;

namespace AoC2022;

[TestClass]
public class Day15 : AoCTestClass
{
    [TestMethod]
    public void Part1()
    {
        const int row = 2000000;
        var input = DayInput.EnumerateLines();
        // input = TestInput.EnumerateLines();
        var regex = new Regex(@"[xy]=(-?\d+)");
        var sensors = new HashSet<Sensor>();
        foreach (var line in input)
        {
            var matches = regex.Matches(line);
            sensors.Add(new Sensor
            {
                Location = (int.Parse(matches[0].Groups[1].Value), int.Parse(matches[1].Groups[1].Value)),
                ClosestBeacon = (int.Parse(matches[2].Groups[1].Value), int.Parse(matches[3].Groups[1].Value))
            });
        }

        var BeaconsOnRow = sensors.Where(s => s.ClosestBeacon.y == row).DistinctBy(s => s.ClosestBeacon);
        var sensorsCoveringRow = sensors.Where(s => Math.Abs(s.Location.y - row) <= s.Distance);
        // var beaconsCoveringRow = sensorsCoveringRow.Where(s => s.Location.y == row).DistinctBy(s => s.Location);
        var xs = new HashSet<int>();
        foreach (var sensor in sensorsCoveringRow)
        {
            var dx = sensor.Distance - Math.Abs(sensor.Location.y - row);
            for (int x = sensor.Location.x - dx; x <= sensor.Location.x + dx; x++)
            {
                xs.Add(x);
            }
        }

        TestContext.Write($"{xs.Count - BeaconsOnRow.Count()}");//" - beaconsCoveringRow.Count()}");
    }

    public class Sensor
    {
        public (int x, int y) Location { get; set; }
        public (int x, int y) ClosestBeacon { get; set; }

        public int Distance => Math.Abs(ClosestBeacon.x - Location.x) + Math.Abs(ClosestBeacon.y - Location.y);
    }
    
    [TestMethod]
    public void Part2()
    {
        var input = DayInput.EnumerateLines();
        input = TestInput.EnumerateLines();
        TestContext.Write($"");
    }

    private const string TestInput = @"Sensor at x=2, y=18: closest beacon is at x=-2, y=15
Sensor at x=9, y=16: closest beacon is at x=10, y=16
Sensor at x=13, y=2: closest beacon is at x=15, y=3
Sensor at x=12, y=14: closest beacon is at x=10, y=16
Sensor at x=10, y=20: closest beacon is at x=10, y=16
Sensor at x=14, y=17: closest beacon is at x=10, y=16
Sensor at x=8, y=7: closest beacon is at x=2, y=10
Sensor at x=2, y=0: closest beacon is at x=2, y=10
Sensor at x=0, y=11: closest beacon is at x=2, y=10
Sensor at x=20, y=14: closest beacon is at x=25, y=17
Sensor at x=17, y=20: closest beacon is at x=21, y=22
Sensor at x=16, y=7: closest beacon is at x=15, y=3
Sensor at x=14, y=3: closest beacon is at x=15, y=3
Sensor at x=20, y=1: closest beacon is at x=15, y=3";
}