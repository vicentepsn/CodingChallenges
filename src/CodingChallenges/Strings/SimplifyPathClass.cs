using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenges.Strings
{
    /// <summary>
    /// Related   : String, Stack
    /// Title     : 71. Simplify Path
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/simplify-path/description/
    /// Approachs : -
    /// Companies : Facebook 47, Amazon 5, Google 4, Microsoft 3 (2023-04-12)
    /// </summary>
    public static class SimplifyPathClass
    {
        // My solution using a List
        public static string SimplifyPath(string path)
        {
            string[] components = path.Split("/");
            List<string> list = new List<string>(components.Length);

            foreach (string directory in components)
            {
                if (directory.Equals(".") || string.IsNullOrEmpty(directory))
                    continue;

                if (directory.Equals(".."))
                {
                    if (list.Count > 0)
                    {
                        list.RemoveAt(list.Count - 1);
                    }
                }
                else
                {
                    list.Add(directory);
                }
            }

            //StringBuilder result = new StringBuilder();
            //foreach (string dir in list)
            //{
            //    result.Append("/");
            //    result.Append(dir);
            //}

            //return result.Length > 0 ? result.ToString() : "/";

            return "/" + string.Join('/', list);
        }

        // Author solution using a Stack (adapted to C#)
        public static string SimplifyPath_1(string path)
        {
            Stack<string> stack = new Stack<string>();
            string[] components = path.Split("/");

            foreach (string directory in components)
            {
                if (directory.Equals(".") || string.IsNullOrEmpty(directory))
                    continue;

                if (directory.Equals(".."))
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
                else
                {
                    stack.Push(directory);
                }
            }

            StringBuilder result = new StringBuilder();
            for (int i = stack.Count - 1; i >= 0; i--)
            {
                string dir = stack.ElementAt(i);
                result.Append("/");
                result.Append(dir);
            }

            return result.Length > 0 ? result.ToString() : "/";
        }
    }
}
