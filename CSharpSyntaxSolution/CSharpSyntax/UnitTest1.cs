namespace CSharpSyntax
{
    public class UnitTest1
    {
        [Fact]
        public void CanAddTwoNumbers()
        {
            //throw new Exception("Blammo");
            //given
            int a = 10; int b = 20; int answer;
            //when
            answer = a + b; //system under test
            //then
            Assert.Equal(30, answer);
        }

        [Theory]
        [InlineData(10, 20, 30)]
        [InlineData(10, 5, 15)]
        [InlineData(2, 8, 10)]
        public void CanAddAnyTwoIntegers(int a, int b, int expected)
        {
            int answer = a + b;
            Assert.Equal(expected, answer);
        }

        [Theory]
        [InlineData("Sierra", "Taylor", "Taylor, Sierra")]
        [InlineData("Sierra ", "   Taylor", "Taylor, Sierra")]
        [InlineData("         Sierra    ", "Taylor        ", "Taylor, Sierra")]
        public void FormattingMyName(string first, string last, string expected)
        {
            string fullName = Utils.FormatName(first, last);
            Assert.Equal(expected, fullName);
        }

    }
}