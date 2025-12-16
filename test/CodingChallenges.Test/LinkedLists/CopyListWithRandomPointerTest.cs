using Node = DataStructures.NodeWithRandom;

namespace CodingChallenges.LinkedLists.Test;

public class CopyListWithRandomPointerTest
{
    [Fact]
    public void Test01_ValoresUnicos()
    {
        Node[] nodes = [new Node(7), new Node(13), new Node(11), new Node(10), new Node(1)];

        nodes[0].next = nodes[1];
        nodes[1].next = nodes[2];
        nodes[2].next = nodes[3];
        nodes[3].next = nodes[4];

        nodes[1].random = nodes[0];
        nodes[2].random = nodes[4];
        nodes[3].random = nodes[0];
        nodes[4].random = nodes[2];

        Node outputHead = CopyListWithRandomPointer.CopyRandomList_Iterative(nodes[0]);
        CheckListClone(nodes[0], outputHead);

        outputHead = CopyListWithRandomPointer.CopyRandomList_Recursive(nodes[0]);
        CheckListClone(nodes[0], outputHead);

        outputHead = CopyListWithRandomPointer.CopyRandomList_Iterative_leetcode2(nodes[0]);
        CheckListClone(nodes[0], outputHead);

        CopyListWithRandomPointer copyListWithRandomPointer = new();

        outputHead = copyListWithRandomPointer.CopyRandomList_Recursive_leetcode(nodes[0]);
        CheckListClone(nodes[0], outputHead);

        outputHead = copyListWithRandomPointer.CopyRandomList_Iterative_leetcode1(nodes[0]);
        CheckListClone(nodes[0], outputHead);

        //Node currNode = outputHead;
        //for (int i = 0; i < nodes.Length; i++)
        //{
        //    Assert.Equal(nodes[i].val, currNode?.val);
        //    Assert.NotEqual(nodes[i], currNode);

        //    if (currNode?.random != null)
        //    {
        //        Assert.Equal(nodes[i].random?.val, currNode.random.val);
        //        Assert.NotEqual(nodes[i].random, currNode.random);
        //    }

        //    currNode = currNode.next;
        //}
    }

    [Fact]
    public void Test02_ValoresRepetidos()
    {
        Node[] nodes = [new Node(7), new Node(13), new Node(7), new Node(10), new Node(1)];

        nodes[0].next = nodes[1];
        nodes[1].next = nodes[2];
        nodes[2].next = nodes[3];
        nodes[3].next = nodes[4];

        nodes[1].random = nodes[0];
        nodes[2].random = nodes[4];
        nodes[3].random = nodes[0];
        nodes[4].random = nodes[2];

        Node outputHead = CopyListWithRandomPointer.CopyRandomList_Iterative(nodes[0]);
        CheckListClone(nodes[0], outputHead);

        outputHead = CopyListWithRandomPointer.CopyRandomList_Recursive(nodes[0]);
        CheckListClone(nodes[0], outputHead);

        outputHead = CopyListWithRandomPointer.CopyRandomList_Iterative_leetcode2(nodes[0]);
        CheckListClone(nodes[0], outputHead);

        CopyListWithRandomPointer copyListWithRandomPointer = new();

        outputHead = copyListWithRandomPointer.CopyRandomList_Recursive_leetcode(nodes[0]);
        CheckListClone(nodes[0], outputHead);

        outputHead = copyListWithRandomPointer.CopyRandomList_Iterative_leetcode1(nodes[0]);
        CheckListClone(nodes[0], outputHead);
    }

    private void CheckListClone(Node original, Node cloned)
    {
        Node currClonedNode = cloned;
        Node currOriginalNode = original;

        while (currOriginalNode != null)
        {
            Assert.Equal(currOriginalNode.val, currClonedNode?.val);
            Assert.NotEqual(currOriginalNode, currClonedNode);

            if (currClonedNode?.random != null)
            {
                Assert.Equal(currOriginalNode.random?.val, currClonedNode.random.val);
                Assert.NotEqual(currOriginalNode.random, currClonedNode.random);
            }

            currOriginalNode = currOriginalNode.next;
            currClonedNode = currClonedNode.next;
        }
    }
}
