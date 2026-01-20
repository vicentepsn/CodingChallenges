using DataStructures;
using ListNode = DataStructures.SinglyLinkedListNodeII;

namespace CodingChallenges.LinkedLists.Test
{
    public class ReverseSinglyLinkedListTest
    {
        [Fact]
        public void Test01()
        {
            ListNode head = new(1,
                new ListNode(2,
                    new ListNode(3,
                        new ListNode(4,
                            new ListNode(5)))));

            var result = ReverseSinglyLinkedList.Reverse(head);

            Assert.Equal(5, result.val);
        }
    }
}
