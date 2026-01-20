using ListNode = DataStructures.SinglyLinkedListNodeII;
using DataStructures.Extensions;

namespace CodingChallenges.LinkedLists.Test;

public class ReverseLinkedListIntervalTest
{
    [Fact]
    public void Test01()
    {
        int[] headArray = [1, 2, 3, 4, 5];

        ListNode head = headArray.ConvertArrayToLinkedListII();

        ListNode newHead = ReverseLinkedListInterval.ReverseBetween(head, 2, 4);

        int[] newHeadArray = newHead.ToArray();

        int[] expected = [1, 4, 3, 2, 5];

        Assert.Equal(expected, newHeadArray);
    }
}
