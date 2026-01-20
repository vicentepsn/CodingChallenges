using CodingChallenges.LinkedLists;
using DataStructures.Extensions;
using ListNode = DataStructures.SinglyLinkedListNodeII;

namespace CodingChallenges.Test.LinkedLists;

public class RemoveNthNodeFromEndOfListTest
{
    [Fact]
    public void Test01()
    {
        int[] headArray = [1, 2, 3, 4, 5];

        ListNode head = headArray.ConvertArrayToLinkedListII();

        ListNode newHead = RemoveNthNodeFromEndOfList.RemoveNthFromEnd_v2(head, 2);

        int[] newHeadArray = newHead.ToArray();

        int[] expected = [1, 2, 3, 5];

        Assert.Equal(expected, newHeadArray);
    }

    [Fact]
    public void Test02()
    {
        int[] headArray = [1, 2];

        ListNode head = headArray.ConvertArrayToLinkedListII();

        ListNode newHead = RemoveNthNodeFromEndOfList.RemoveNthFromEnd_v2(head, 1);

        int[] newHeadArray = newHead.ToArray();

        int[] expected = [1];

        Assert.Equal(expected, newHeadArray);
    }
}
