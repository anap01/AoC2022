namespace AoC2022
{
    public class AoCTestClass
    {
        public TestContext TestContext { get; set; }

        protected string DayInput
        {
            get
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("cookie", Environment.GetEnvironmentVariable("sessionCookie"));
                var input =
                    client.GetStringAsync($"https://adventofcode.com/2022/day/{GetType().Name[3..]}/input").Result;
                return input.Trim();
            }
        }
    }
    
    public static class StringExtensions {

        public static IEnumerable<string> EnumerateLines(this string str)
        {
            using var reader = new StringReader(str);
            while (reader.ReadLine() is { } line)
            {
                yield return line;
            }
        }
    }
}
