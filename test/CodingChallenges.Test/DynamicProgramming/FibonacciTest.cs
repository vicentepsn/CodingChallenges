namespace CodingChallenges.DynamicProgramming.Test
{
    public class FibonacciTest
    {
        [Fact]
        public void Test01()
        {
            var value = 0;
            var expected = 0;

            var output = Fibonacci.CalcFibonacci(value);

            Assert.Equal(expected, output);
        }
        
        [Fact]
        public void Test02()
        {
            var value = 1;
            var expected = 1;

            var output = Fibonacci.CalcFibonacci(value);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Test03()
        {
            var value = 2;
            var expected = 1;

            var output = Fibonacci.CalcFibonacci(value);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Test04()
        {
            var value = 3;
            var expected = 2;

            var output = Fibonacci.CalcFibonacci(value);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Test05()
        {
            var value = 10;
            var expected = 55;

            var output = Fibonacci.CalcFibonacci(value);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Test06()
        {
            var value = 20;
            var expected = 6765;

            var output = Fibonacci.CalcFibonacci(value);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Test07()
        {
            var value = 70;
            var expected = 190392490709135;

            var output = Fibonacci.CalcFibonacci(value);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Recursive_01()
        {
            var value = 10;
            var expected = 55;

            var output = Fibonacci.CalcFibonacci_Recursive(value);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Recursive_02()
        {
            var value = 30;
            var expected = 832040;

            var output = Fibonacci.CalcFibonacci_Recursive(value);

            Assert.Equal(expected, output);
        }
    }
}
