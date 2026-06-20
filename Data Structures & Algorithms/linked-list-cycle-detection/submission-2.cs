public class Solution
{
    public bool HasCycle(ListNode head)
    {
        var hash = new HashSet<ListNode>();
        var current = head;

        while (current != null)
        {
            if (hash.Contains(current))
                return true;

            hash.Add(current);
            current = current.next;
        }

        return false;
    }
}
