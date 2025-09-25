using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Strings
{
    public class OneAwayEdit
    {
        public bool CheckOneAwayEdit(string A, string B)
        {
            if(Math.Abs(A.Length - B.Length) > 1)
                return false;

            int idxA = 0;
            int idxB = 0;
            bool diffFound = false;

            while (idxA < A.Length && idxB < B.Length)
            {
                if (A[idxA] != B[idxB]) 
                { 
                    if (diffFound)
                        return false;

                    diffFound = true;

                    if (A.Length == B.Length)
                    {
                        idxA++;
                        idxB++;
                    }
                    else if (A.Length > B.Length)
                        idxA++;
                    else
                        idxB++;
                }
                else
                {
                    idxA++;
                    idxB++;
                }
            }

            return true;
        }
    }
}
