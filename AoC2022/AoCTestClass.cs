namespace AoC2022
{
    public class AoCTestClass
    {
        public TestContext TestContext { get; set; }

        protected string DayInput()
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("cookie",Environment.GetEnvironmentVariable("sessionCookie"));
            string input =
                client.GetStringAsync($"https://adventofcode.com/2022/day/{GetType().Name[3..]}/input").Result;
            return input.Trim();
        }
    }
}
