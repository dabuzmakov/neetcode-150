public class Solution
{
    public void ReorderList(ListNode head)
    {
        var mainLength = (int)Math.Ceiling(Count(head) / 2.0);
        var second = head;

        for (var i = 0; i < mainLength; i++)
        {
            if (mainLength - i == 1)
            {
                var node = second.next;
                second.next = null;
                second = node;
                break;
            }

            second = second.next;
        }
        
        second = Reverse(second);

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

        if (current != null)
            current.next = null;
    }

    public int Count(ListNode head)
    {
        var count = 0;
        var current = head;

        while (current != null)
        {
            count++;
            current = current.next;
        }

        return count;
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
