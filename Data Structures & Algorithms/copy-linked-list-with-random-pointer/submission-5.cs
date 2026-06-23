public class Solution
{
    public Node copyRandomList(Node head)
    {
        var current = head;
        var newHead = current == null ? null : new Node(current.val);
        var newCurrent = newHead;

        var originalCopyDict = new Dictionary<Node, Node?>();

        while (current != null)
        {
            var newNext = current.next == null
                ? null
                : new Node(current.next.val);

            originalCopyDict[current] = newCurrent;
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
                : originalCopyDict[current.random];
            current = current.next;
            newCurrent = newCurrent.next;
        }

        return newHead;
    }
}
