public class Solution
{
    public Node copyRandomList(Node head)
    {
        var current = head;
        var newHead = current == null ? null : new Node(current.val);
        var newCurrent = newHead;

        var nodeIndexDict = new Dictionary<Node, int>();
        var indexNodeDict = new Dictionary<int, Node?>();
        var currentIndex = 0;

        while (current != null)
        {
            var newNext = current.next == null
                ? null
                : new Node(current.next.val);

            nodeIndexDict[current] = currentIndex;
            indexNodeDict[currentIndex++] = newCurrent;

            newCurrent.next = newNext;
            newCurrent = newCurrent.next;
            current = current.next;
        }

        current = head;
        newCurrent = newHead;
        while (current != null)
        {
            newCurrent.random = current.random == null 
                ? null 
                : indexNodeDict[nodeIndexDict[current.random]];
            current = current.next;
            newCurrent = newCurrent.next;
        }

        return newHead;
    }
}
