namespace CodingChallenges.Stack.Test
{
    public class MinRemoveToMakeValidParenthesesTest
    {
        [Fact]
        public void test1()
        {
            var input = "lee(t(c)o)de)";

            var output = MinRemoveToMakeValidParentheses.MinRemoveToMakeValid(input);

            Assert.True(validateParentesis(output));
        }

        [Fact]
        public void test2()
        {
            var input = "a)b(c)d";

            var output = MinRemoveToMakeValidParentheses.MinRemoveToMakeValid(input);

            Assert.True(validateParentesis(output));
        }

        [Fact]
        public void test3()
        {
            var input = "))((";

            var output = MinRemoveToMakeValidParentheses.MinRemoveToMakeValid(input);

            Assert.True(validateParentesis(output));
        }

        [Fact]
        public void test4()
        {
            var input = "())()(((";
            var expected = "()()";

            var output = MinRemoveToMakeValidParentheses.MinRemoveToMakeValid(input);

            Assert.Equal(expected, output);
        }

        private bool validateParentesis(string s)
        {
            var stack = new Stack<char>();

            foreach(char c in s)
            {
                if(c == '('){
                    stack.Push(c);
                }
                else if (c == ')' && stack.Count > 0)
                {
                    stack.Pop();
                }
                else if (c == ')')
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}
