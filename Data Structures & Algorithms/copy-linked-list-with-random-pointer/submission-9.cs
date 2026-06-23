public class Solution
{
    public Node copyRandomList(Node head)
    {
        var current = head;
        var dict = new Dictionary<Node, Node>();

        while (current != null)
        {
            dict[current] = new Node(current.val);
            current = current.next;
        }

        current = head;
        while (current != null)
        {
            dict[current].next = current.next == null ? null : dict[current.next];
            dict[current].random = current.random == null ? null : dict[current.random];
            current = current.next;
        }

        return head == null ? null : dict[head];
    }
}
