using DataStructures;
using System;

namespace CodingChallenges.LinkedLists
{
    /* Given a linkedList that contains odd and even integers, separate the original
    * list into 2 linkedLists, with the first one containing only even integers and the 
    * second one containing only odd integers. Perform this in-place */

   //public class Node
   // {
   //     public int Data;
   //     public Node Next;
   //     public Node Previous;
   // }

    public static class SplitOddsAndEvensClass
    {
        public static void Main(string[] args)
        {
            // you can write to stdout for debugging purposes, e.g.
            Console.WriteLine("This is a debug message");
        }

        public static (Node OddHead, Node EvenHead) SplitIntoEvenAndOdd(Node head)
        {
            Node oddHead = null;
            Node evenHead = null;

            Node oddTail = null;
            Node evenTail = null;


            var currentNode = head;


            while (currentNode != null)
            {
                var nextNode = currentNode?.right;

                if (currentNode.data % 2 == 0)
                {
                    if (evenTail == null)
                    {
                        evenHead = currentNode;
                        evenTail = currentNode;
                    }
                    else
                    {
                        currentNode.left = evenTail;
                        evenTail.right = currentNode;
                        evenTail = currentNode;
                    }
                }
                else
                {
                    if (oddTail == null)
                    {
                        oddHead = currentNode;
                        oddTail = currentNode;
                    }
                    else
                    {
                        currentNode.left = oddTail;
                        oddTail.right = currentNode;
                        oddTail = currentNode;
                    }
                }
                currentNode = nextNode;
            }

            evenTail.right = null;
            oddTail.right = null;

            return (oddHead, evenHead);
        }

    }
}
