using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Extensions
{
    public static class ListNodeExtension
    {
        public static ListNode CloneData(ListNode ListNode) => new ListNode() { val = ListNode.val };

        public static ListNode ConvertArrayToLinkedList(this int[] arr)
        {
            if (arr.Length == 0)
                return null;

            ListNode head = new ListNode()
            {
                val = arr[0]
            };

            ListNode tail = head;

            for (int i = 1; i < arr.Length; i++)
            {
                ListNode ListNode = new ListNode() { val = arr[i] };
                tail.next = ListNode;
                tail = ListNode;
            }
            return head;
        }

        public static string ToStr(this ListNode ListNode)
        {
            if (ListNode == null)
                return "";
            var result = new StringBuilder($"[{ListNode.val}");
            ListNode current = ListNode.next;
            while (current != null)
            {
                result.Append($", {current.val}");
                current = current.next;
            }
            result.Append("]");

            return result.ToString();
        }
    }

}
