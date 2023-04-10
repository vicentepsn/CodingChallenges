namespace CodingChallenges.Arrays.Test
{
    public class ItemsInContainerTest
    {
        [Fact]
        public void test01()
        {
            var s = "|**|*|*";
            var startIndices = new List<int> { 1, 1, 2, 3, 4 };
            var endIndices = new List<int> { 5, 6, 7, 7, 7 };

            var expected = new List<int> { 2, 3, 1, 1, 1 };

            var output = ItemsInContainer.numberOfItems(s, startIndices, endIndices);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void test02()
        {
            var s = "*******";
            var startIndices = new List<int> { 1, 1, 2, 4 };
            var endIndices = new List<int> { 5, 7, 6, 4 };

            var expected = new List<int> { 0, 0, 0, 0 };

            var output = ItemsInContainer.numberOfItems(s, startIndices, endIndices);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void test03()
        {
            var s = "|||||||";
            var startIndices = new List<int> { 1, 1, 2, 4 };
            var endIndices = new List<int> { 5, 7, 6, 4 };

            var expected = new List<int> { 0, 0, 0, 0 };

            var output = ItemsInContainer.numberOfItems(s, startIndices, endIndices);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void test04()
        {
            var s = "|*|*|*|*|*|*|";
            var startIndices = new List<int> { 1, 2, 2 };
            var endIndices = new List<int> { 13, 13, 12 };

            var expected = new List<int> { 6, 5, 4 };

            var output = ItemsInContainer.numberOfItems(s, startIndices, endIndices);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void test05()
        {
            var s = "****|*|*|****";
            var startIndices = new List<int> { 1, 2 };
            var endIndices = new List<int> { 13, 12 };

            var expected = new List<int> { 2, 2 };

            var output = ItemsInContainer.numberOfItems(s, startIndices, endIndices);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void test06()
        {
            var s = "**|||**";
            var startIndices = new List<int> { 1, 1, 2, 4 };
            var endIndices = new List<int> { 5, 7, 6, 4 };

            var expected = new List<int> { 0, 0, 0, 0 };

            var output = ItemsInContainer.numberOfItems(s, startIndices, endIndices);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void test07()
        {
            var s = "||***||";
            var startIndices = new List<int> { 1, 1, 2, 4 };
            var endIndices = new List<int> { 5, 7, 6, 4 };

            var expected = new List<int> { 0, 3, 3, 0 };

            var output = ItemsInContainer.numberOfItems(s, startIndices, endIndices);

            Assert.Equal(expected, output);
        }

    }
}
