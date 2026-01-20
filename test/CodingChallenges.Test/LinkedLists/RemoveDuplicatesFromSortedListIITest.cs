using DataStructures.Extensions;
using ListNode = DataStructures.SinglyLinkedListNodeII;

namespace CodingChallenges.LinkedLists.Test;

public class RemoveDuplicatesFromSortedListIITest
{
    [Fact]
    public void Test01()
    {
        int[] headArray = [1, 2, 3, 3, 4, 4, 5];

        ListNode head = headArray.ConvertArrayToLinkedListII();

        ListNode newHead = RemoveDuplicatesFromSortedListII.DeleteDuplicates(head);

        int[] newHeadArray = newHead.ToArray();

        int[] expected = [1, 2, 5];

        Assert.Equal(expected, newHeadArray);
    }

    [Fact]
    public void Test02()
    {
        int[] headArray = [];

        ListNode head = headArray.ConvertArrayToLinkedListII();

        ListNode newHead = RemoveDuplicatesFromSortedListII.DeleteDuplicates(head);

        int[] newHeadArray = newHead.ToArray();

        int[] expected = [];

        Assert.Equal(expected, newHeadArray);
    }

    [Fact]
    public void Test03()
    {
        int[] headArray = [1, 1, 1, 2, 3];

        ListNode head = headArray.ConvertArrayToLinkedListII();

        ListNode newHead = RemoveDuplicatesFromSortedListII.DeleteDuplicates(head);

        int[] newHeadArray = newHead.ToArray();

        int[] expected = [2, 3];

        Assert.Equal(expected, newHeadArray);
    }
}
