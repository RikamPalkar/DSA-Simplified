    public ListNode ModifiedList(int[] nums, ListNode head) 
    {
        HashSet<int> set = new(nums);
        ListNode dummy = new(0, head);
        ListNode prev = dummy;
        ListNode curr = dummy.next;

        while(curr != null)
        {
            if(set.Contains(curr.val))
            {
                prev.next = curr.next;
            }
            else
            {
                prev = curr;
            }
            curr = curr.next;
        }
        return dummy.next;
    }
