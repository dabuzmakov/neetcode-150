public class Solution
{
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        if (list1 == null) return list2;
        if (list2 == null) return list1;
        
        var mainList = list1.val < list2.val ? list1 : list2;
        var secondList = list1.val >= list2.val ? list1 : list2;

        var current = mainList;
        var second = secondList;

        while (current.next != null)
        {
            if (current.next.val > second.val)
            {
                var tail = current.next;
                current.next = second;
                second = tail;
            }
            
            current = current.next;
        }

        current.next = second;
        return mainList;
    }
}