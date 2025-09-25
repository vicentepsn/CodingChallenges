using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Extensions
{
    public static class ListNodeExtension
    {
        public static SinglyLinkedListNode CloneData(SinglyLinkedListNode ListNode) => new SinglyLinkedListNode() { data = ListNode.data };

        public static SinglyLinkedListNode ConvertArrayToLinkedList(this int[] arr)
        {
            if (arr.Length == 0)
                return null;

            SinglyLinkedListNode head = new SinglyLinkedListNode()
            {
                data = arr[0]
            };

            SinglyLinkedListNode tail = head;

            for (int i = 1; i < arr.Length; i++)
            {
                SinglyLinkedListNode ListNode = new SinglyLinkedListNode() { data = arr[i] };
                tail.next = ListNode;
                tail = ListNode;
            }
            return head;
        }

        public static string ToStr(this SinglyLinkedListNode ListNode)
        {
            if (ListNode == null)
                return "";
            var result = new StringBuilder($"[{ListNode.data}");
            SinglyLinkedListNode current = ListNode.next;
            while (current != null)
            {
                result.Append($", {current.data}");
                current = current.next;
            }
            result.Append("]");

            return result.ToString();
        }
    }

}
