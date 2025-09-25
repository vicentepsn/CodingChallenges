using DataStructures;

namespace CodingChallenges.LinkedLists.Test
{
    public class ReverseSinglyLinkedListTest
    {
        [Fact]
        public void Test01()
        {
            SinglyLinkedListNode head = new SinglyLinkedListNode(1,
                new SinglyLinkedListNode(2,
                    new SinglyLinkedListNode(3,
                        new SinglyLinkedListNode(4,
                            new SinglyLinkedListNode(5)))));

            var result = ReverseSinglyLinkedList.Reverse(head);

            Assert.Equal(5, result.data);
        }
    }
}
