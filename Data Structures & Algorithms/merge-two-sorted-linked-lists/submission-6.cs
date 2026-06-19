public class Solution
{
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        if (list1 == null) return list2;
        if (list2 == null) return list1;

        if (list1.val > list2.val)
            return MergeTwoLists(list2, list1);

        var current = list1;

        while (current.next != null)
        {
            if (current.next.val > list2.val)
            {
                var tail = current.next;
                current.next = list2;
                list2 = tail;
            }
            
            current = current.next;
        }

        current.next = list2;
        return list1;
    }
}