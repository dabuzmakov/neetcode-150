public class Solution
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        var length = GetLength(head);
        var current = head;

        if (length - n == 0) 
            return head.next;

        for (var i = 0; i < length - n - 1; i++)
            current = current.next;

        var node = current.next.next;
        current.next.next = null;
        current.next = node;

        return head;
    }

    public int GetLength(ListNode head)
    {
        var current = head;
        var count = 0;

        while (current != null)
        {
            count++;
            current = current.next;
        }

        return count;
    }
}
