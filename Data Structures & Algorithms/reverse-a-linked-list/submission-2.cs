public class Solution
{
    public ListNode ReverseList(ListNode head)
    {
        ListNode previous = null;
        var currentNode = head;

        while (currentNode != null)
        {
            var nextNode = currentNode.next;
            currentNode.next = previous;
            previous = currentNode;
            currentNode = nextNode;
        }

        return previous;
    }
}