public class Solution
{
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        var dummy = new ListNode();
        var current = dummy;
        current.next = head;

        while (current != null && current.next != null)
        {
            var newCurrent = current.next;
            if (!IsKthExist(current, k)) break;      
            current.next = Reverse(current.next, k, out var nextNode);
            current = newCurrent;
            current.next = nextNode;
        }

        return dummy.next;
    }

    public ListNode Reverse(ListNode list, int k, out ListNode nextNode)
    {
        ListNode previous = null;
        var current = list;
        var count = 0;

        while (count++ < k)
        {
            var node = current.next;
            current.next = previous;
            previous = current;
            current = node;
        }

        nextNode = current;
        return previous;
    }

    public bool IsKthExist(ListNode head, int k)
    {
        var current = head;

        for (var i = 0; i < k; i++)
            current = current?.next;
        
        return current != null;
    }
}
