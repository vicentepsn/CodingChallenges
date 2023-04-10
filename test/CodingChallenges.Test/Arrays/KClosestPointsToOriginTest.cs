namespace CodingChallenges.Arrays.Test
{
    public class KClosestPointsToOriginTest
    {
        [Fact]
        public void test01()
        {
            var inputPoints = new int[][]
            {
                new int[]{1,3},
                new int[]{-2,2},
            };

            var inputK = 1;

            var expected = new int[][]
            {
                new int[]{-2,2},
            };

            var output = KClosestPointsToOrigin.KClosest(inputPoints, inputK);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void test02()
        {
            var inputPoints = new int[][]
            {
                new int[]{3,3},
                new int[]{5,-1},
                new int[]{-2,4},
            };

            var inputK = 2;

            var expected = new int[][]
            {
                new int[]{3,3},
                new int[]{-2,4},
            };

            var output = KClosestPointsToOrigin.KClosest(inputPoints, inputK);

            //output.OrderBy((a, b) => a[0].CompareTo(b[0]));
            Array.Sort<int[]>(output, (a, b) => a[0].CompareTo(b[0]) != 0 ? a[0].CompareTo(b[0]) : a[1].CompareTo(b[1]));
            Array.Sort<int[]>(expected, (a, b) => a[0].CompareTo(b[0]) != 0 ? a[0].CompareTo(b[0]) : a[1].CompareTo(b[1]));

            Assert.Equal(expected, output);
        }

    }
}

