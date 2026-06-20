public class Solution
{
    public void ReorderList(ListNode head)
    {
        var second = Reverse(GetHalf(head));

        var current = head;
        while (current != null && second != null)
        {
            var nextFirst = current.next;
            var nextSecond = second.next;

            current.next = second;
            second.next = nextFirst;

            current = nextFirst;
            second = nextSecond;
        }
    }

    public ListNode GetHalf(ListNode head)
    {
        var slow = head;
        var fast = head;

        while (fast.next != null && fast.next.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        var second = slow.next;
        slow.next = null;

        return second;
    }

    public ListNode Reverse(ListNode head)
    {
        ListNode previous = null;
        var current = head;

        while (current != null)
        {
            var nextNode = current.next;
            current.next = previous;
            previous = current;
            current = nextNode;
        }

        return previous;
    }
}
