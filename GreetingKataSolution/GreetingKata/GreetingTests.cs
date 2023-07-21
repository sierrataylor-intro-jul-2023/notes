namespace GreetingKata
{
    public class GreetingTests
    {
        [Fact]
        public void CallsGreetMethod()
        {
            var greeter = new Greeter();
            var greeting = greeter.Greet("");
            Assert.NotNull(greeting);

        }


        [Theory]
        [InlineData("Sierra", "Hello, Sierra.")]
        [InlineData("Windom", "Hello, Windom.")]
        [InlineData("Ada", "Hello, Ada.")]
        public void ReturnGreetingWithName(string name, string expectedGreeting)
        {
            var greeter = new Greeter();
            var greeting = greeter.Greet(name);

            Assert.Equal(expectedGreeting, greeting);
        }

        [Fact]
        public void HandleNullParameter()
        {
            var greeter = new Greeter();
            var greeting = greeter.Greet(null);
            Assert.Equal("Hello, Buddy!", greeting);
        }

        [Fact]
        public void ShoutsWhenGivenUppercaseName()
        {
            var greeter = new Greeter();
            var greeting = greeter.Greet("BOB");
            Assert.Equal("HELLO, BOB!", greeting);
        }



        [Theory]
        [InlineData("Sierra",new string[] { "Windom" }, "Hello, Sierra and Windom!")]
        [InlineData("Windom", new string[] { "Bob" }, "Hello, Windom and Bob!")]
        [InlineData("Ada", new string[] { "Jane" }, "Hello, Ada and Jane!")]
        public void ReturnGreetingWithTwoNames(string name1, string[] names, string expectedGreeting)
        {
            var greeter = new Greeter();
            var greeting = greeter.Greet(name1, names);

            Assert.Equal(expectedGreeting, greeting);
        }

        [Theory]
        [InlineData("Sierra", new string[] { "Windom", "Hanna" }, "Hello, Sierra, Windom, and Hanna!")]
        [InlineData("Windom", new string[] { "Bob", "Cole", "Joe" }, "Hello, Windom, Bob, Cole, and Joe!")]
        [InlineData("Ada", new string[] { "Jane", "Sue" }, "Hello, Ada, Jane, and Sue!")]
        public void ReturnGreetingWithArbitraryListOfNames(string name1, string[] names, string expectedGreeting)
        {
            var greeter = new Greeter();
            var greeting = greeter.Greet(name1, names);

            Assert.Equal(expectedGreeting, greeting);
        }
    }
}