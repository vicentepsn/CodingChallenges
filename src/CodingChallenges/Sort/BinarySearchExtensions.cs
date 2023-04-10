using System;

namespace CodingChallenges.Sort
{
    public static class BinarySearchExtensions
    {
        public static int BirarySearch<T>(T[] arr, T value) where T : IComparable<T>
            => BirarySearch(arr, value, 0, (arr?.Length ?? 0) - 1);

        public static int BirarySearch<T>(T[] arr, T value, int left, int right) where T : IComparable<T>
        {
            if (left > right)
                return ~left;

            int mid = (left + right) / 2;

            if (arr[mid].CompareTo(value) == 0)
                return mid;

            if (arr[mid].CompareTo(value) < 0)
                return BirarySearch(arr, value, left, mid - 1);

            return BirarySearch(arr, value, mid + 1, right);
        }
        
        public static int BirarySearchRef<T>(T[] arr, T target, ref int left, ref int right) where T : IComparable<T>
        {
            if (left > right)
                return ~left;

            int mid = (left + right) / 2;

            if (arr[mid].CompareTo(target) == 0)
                return mid;

            if (arr[mid].CompareTo(target) < 0)
            {
                left = mid + 1;
                return BirarySearchRef(arr, target, ref left, ref right);
            }
            right = mid - 1;
            return BirarySearchRef(arr, target, ref left, ref right);
        }

        public static int[] BirarySearchFirstAndLast<T>(T[] arr, T target) where T : IComparable<T>
        {
            int left = 0, right = arr.Length - 1;

            int idxFoundLeft = BirarySearchRef(arr, target, ref left, ref right);

            if (idxFoundLeft < 0)
                return new int[2] {-1, -1};

            int idxFoundRight = idxFoundLeft;

            int[] firstAndLast = { idxFoundLeft, idxFoundRight };

            idxFoundLeft = BirarySearchFirst(arr, target, left, idxFoundLeft - 1);
            if (idxFoundLeft >= 0)
                firstAndLast[0] = idxFoundLeft;

            idxFoundRight = BirarySearchLast(arr, target, idxFoundRight + 1, right);
            if (idxFoundRight >= 0)
                firstAndLast[1] = idxFoundRight;

            //while (true)
            //{
            //    int midLeft = idxFoundLeft - 1;
            //    idxFoundLeft = BirarySearchRef(arr, target, ref left, ref midLeft);

            //    if (idxFoundLeft < 0)
            //        break;
            //    else
            //        firstAndLast[0] = idxFoundLeft;
            //}

            //while (true)
            //{
            //    int midRight = idxFoundRight + 1;
            //    idxFoundRight = BirarySearchRef(arr, target, ref midRight, ref right);

            //    if (idxFoundRight < 0)
            //        break;
            //    else
            //        firstAndLast[1] = idxFoundRight;
            //}

            return firstAndLast;
        }

        public static int BirarySearchFirst<T>(T[] arr, T target) where T : IComparable<T>
            => BirarySearchFirst(arr, target, 0, arr.Length - 1);

        public static int BirarySearchFirst<T>(T[] arr, T target, int left, int right) where T : IComparable<T>
        {
            if (left > right)
                return ~left;

            int mid = (left + right) / 2;

            if (arr[mid].CompareTo(target) >= 0)
            {
                var idx = BirarySearchFirst(arr, target, left, mid - 1);
                return (idx < 0 && arr[mid].CompareTo(target) == 0) 
                    ? mid 
                    : idx;
            }

            return BirarySearchFirst(arr, target, mid + 1, right);
        }

        public static int BirarySearchFirst(int[] arr, int target)
            => BirarySearchFirst(arr, target, 0, arr.Length - 1);

        // ** ATENTION WITH PARAMETER POSITIONS **
        public static int BirarySearchFirst(int[] arr, int target, int left, int right)
        {
            if (left > right)
                return ~left;

            int mid = (left + right) / 2;

            if (arr[mid] >= target)
            {
                var idx = BirarySearchFirst(arr, target, left, mid - 1);
                return (idx < 0 && arr[mid] == target)
                    ? mid
                    : idx;
            }

            return BirarySearchFirst(arr, target, mid + 1, right);
        }

        public static int BirarySearchLast<T>(T[] arr, T target) where T : IComparable<T>
            => BirarySearchLast(arr, target, 0, arr.Length - 1);

        public static int BirarySearchLast<T>(T[] arr, T target, int left, int right) where T : IComparable<T>
        {
            if (left > right)
                return ~left;

            int mid = (left + right) / 2;

            if (target.CompareTo(arr[mid]) < 0)
                return BirarySearchLast(arr, target, left, mid - 1);

            var idx = BirarySearchLast(arr, target, mid + 1, right);
            return (idx < 0 && arr[mid].CompareTo(target) == 0)
                ? mid
                : idx;
        }

    }
}
