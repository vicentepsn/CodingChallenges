using DataStructures.Extensions;

namespace CodingChallenges.LinkedLists.Test
{
    public class PalindromeLinkedListTest
    {
        [Fact]
        public void test1()
        {
            var p = new PalindromeLinkedList();

            int[] inputArr = new int[] { 1, 2, 2, 1 };
            bool expected = true;
            var inputNode = inputArr.ConvertArrayToLinkedList();

            var output = p.IsPalindrome(inputNode);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void test2()
        {
            var p = new PalindromeLinkedList();

            int[] inputArr = new int[] { 1, 2, 3, 2, 1 };
            bool expected = true;
            var inputNode = inputArr.ConvertArrayToLinkedList();

            var output = p.IsPalindrome(inputNode);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void test3()
        {
            var p = new PalindromeLinkedList();

            int[] inputArr = new int[] { 1 };
            bool expected = true;
            var inputNode = inputArr.ConvertArrayToLinkedList();

            var output = p.IsPalindrome(inputNode);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void test4()
        {
            var p = new PalindromeLinkedList();

            int[] inputArr = new int[] { 1, 2, 3, 4, 2, 1 };
            bool expected = false;
            var inputNode = inputArr.ConvertArrayToLinkedList();

            var output = p.IsPalindrome(inputNode);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void test5()
        {
            var p = new PalindromeLinkedList();

            int[] inputArr = new int[] { 1, 1, 2, 3, 2, 1 };
            bool expected = false;
            var inputNode = inputArr.ConvertArrayToLinkedList();

            var output = p.IsPalindrome(inputNode);

            Assert.Equal(expected, output);
        }
    }
}
