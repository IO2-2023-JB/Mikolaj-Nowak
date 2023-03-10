using test_TDD;

namespace Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("123", 123)]
        [InlineData("15, 900", 915)]
        [InlineData("15\n900", 915)]
        [InlineData("1, 2, 3\n4\n5, 6", 21)]
        [InlineData("1\n2\n3, 4, 5\n6", 21)]
        [InlineData("1\n\n2\n3, 4, 5\n6", 21)]
        [InlineData("15\n900,3021048", 915)]
        [InlineData("//#\n15#900", 915)]
        [InlineData("//?\n15?900", 915)]
        [InlineData("//!\n111!11", 122)]
        public void Tests(string numbers, int expected)
        {
            var result = StringCalculator.Add(numbers);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestNegativeNumbers()
        {
            var numbers = "10,43,532,-543,23,3,-11,-1";
            Assert.Throws<ArgumentException>(() => StringCalculator.Add(numbers));
        }
    }
}