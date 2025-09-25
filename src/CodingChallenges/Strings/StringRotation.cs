using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Strings
{
    public class StringRotation
    {
        // not tested
        public bool IsStringRotated(string A, string B)
        {
            if (string.IsNullOrEmpty(A) || string.IsNullOrEmpty(B) || A.Length != B.Length || A.Equals(B)) 
                return false;

            int leftA = 1;
            int rightA = 0;
            int leftB = 0;

            while (leftA < A.Length && rightA < A.Length)
            {
                if (A[leftA] == B[0])
                {
                    rightA = leftA + 1;
                    leftB++;
                    while (rightA < A.Length)
                    {
                        if (A[rightA] == B[leftB])
                        {
                            rightA++;
                            leftB++;
                        }
                        else
                        {
                            leftA++;
                            leftB = 0;
                            break;
                        }
                    }
                }
                else
                    leftA++;
            }

            if (leftA < A.Length && B.Substring(leftB).Equals(A.Substring(0, leftA)))
                return true;

            return false;
        }

        public bool IsStringRotated_book(string A, string B)
        {
            if (string.IsNullOrEmpty(A) || string.IsNullOrEmpty(B) || A.Length != B.Length || A.Equals(B))
                return false;

            string A_B = A + A;
            return A_B.Contains(B);
        }
    }
}
