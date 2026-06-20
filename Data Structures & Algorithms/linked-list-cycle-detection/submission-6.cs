public class Solution
{
    public bool HasCycle(ListNode head)
    {
        var slow = head;
        var fast = head;

        while (fast != null)
        {
            fast = fast?.next?.next;
            if (fast == slow) return true;
            slow = slow?.next;
        }

        return false;
    }
}
