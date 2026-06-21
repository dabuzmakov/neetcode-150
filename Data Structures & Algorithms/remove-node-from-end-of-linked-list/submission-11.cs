public class Solution
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        var dummy = new ListNode(0, head);
        var left = dummy;
        var right = head;

        for (var i = 0; i < n; i++)
            right = right.next;

        while (right != null)
        {
            left = left.next;
            right = right.next;
        }

        left.next = left.next.next;
        return dummy.next;
    }
}
