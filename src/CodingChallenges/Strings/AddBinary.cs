using System;
using System.Text;

namespace CodingChallenges.Strings
{
    /// <summary>
    /// Groups    : String, Math
    /// Title     : 67. Add Binary
    /// Difficult : Easy
    /// Link      : https://leetcode.com/problems/add-binary/
    /// Approach  : Bit Manipulation
    /// </summary>
    public class AddBinary
    {
        //public static string addBinary(string a, string b)
        //{
        //    return Convert.ToString(Convert.ToInt32(a, 2) + Convert.ToInt32(b, 2), 2);
        //}

        // Complexity: T / S  =>  O(max(N, M))
        public static string addBinary(string a, string b)
        {
            int n = a.Length, m = b.Length;
            if (n < m) 
                return addBinary(b, a);
            int L = Math.Max(n, m);

            StringBuilder sb = new StringBuilder();
            int carry = 0, j = m - 1;
            for (int i = L - 1; i > -1; --i)
            {
                if (a[i] == '1') 
                    carry++;
                if (j > -1 && b[j--] == '1')
                    carry++;

                if (carry % 2 == 1) 
                    sb.Append('1');
                else 
                    sb.Append('0');

                carry /= 2;
            }
            if (carry == 1) 
                sb.Append('1');
            var ca = sb.ToString().ToCharArray();
            Array.Reverse(ca);

            return new string(ca);
        }

        //public string addBinary_2(string a, string b)
        //{
        //    BigInteger x = BigInteger.Parse(  new BigInteger(a, 2);
        //    BigInteger y = new BigInteger(b, 2);
        //    BigInteger zero = new BigInteger("0", 2);
        //    BigInteger carry, answer;
        //    while (y.compareTo(zero) != 0)
        //    {
        //        answer = x.xor(y);
        //        carry = x.and(y).shiftLeft(1);
        //        x = answer;
        //        y = carry;
        //    }
        //    return x.toString(2);
        //}
    }
}
