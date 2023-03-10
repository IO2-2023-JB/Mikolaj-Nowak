namespace test_TDD
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var separators = new List<string>() { ",", "\n" };

            var sr = new StringReader(numbers);
            var firstLine = sr.ReadLine();
            if (!string.IsNullOrEmpty(firstLine) &&
                firstLine.StartsWith("//"))
            {
                var subs = firstLine[2];  
                separators.Add(subs.ToString());
                numbers = sr.ReadToEnd();
            }


            var integers = numbers.Split(separators.ToArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            if (integers.Where(x => x < 0).Any())
            {
                throw new ArgumentException();
            }
            return integers.Where(x => x <= 1000).Sum();
        }
    }
}
