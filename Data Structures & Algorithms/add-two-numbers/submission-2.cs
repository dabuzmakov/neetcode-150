public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var dummy = new ListNode();
        var current = dummy;
        var carry = 0;

        while (l1 != null || l2 != null || carry != 0)
        {
            var first = l1?.val ?? 0;
            var second = l2?.val ?? 0;
            var sum = first + second + carry;

            carry = sum / 10; 
            current.next = new ListNode(sum % 10);
            current = current.next;

            l1 = l1?.next;
            l2 = l2?.next;
        }

        return dummy.next;
    }
}
