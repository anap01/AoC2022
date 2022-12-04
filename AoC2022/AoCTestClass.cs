namespace AoC2022
{
    public class AoCTestClass
    {
        public TestContext TestContext { get; set; }

        protected string DayInput()
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("cookie",Environment.GetEnvironmentVariable("sessionCookie"));
            var input =
                client.GetStringAsync($"https://adventofcode.com/2022/day/{GetType().Name[3..]}/input").Result;
            return input.Trim();
        }
        
        protected IEnumerable<string> DayInputLines() {
            return InputLines(DayInput());
        }
        
        protected IEnumerable<string> InputLines(string str) {
            using var reader = new StringReader(str);
            while (reader.ReadLine() is { } line) {
                yield return line;
            }
        }
    }
}
