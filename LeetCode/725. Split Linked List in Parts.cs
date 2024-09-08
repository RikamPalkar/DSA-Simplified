 public ListNode[] SplitListToParts(ListNode head, int k) 
    {
        int len = 0;
        ListNode curr = head;
        while(curr != null)
        {
            len++;
            curr = curr.next;
        }

        int size = len/k;
        int extra = len%k;
 
        ListNode[] result = new ListNode[k];
        curr = head; 
        for(int i=0; i<k; i++)
        {
            if (curr == null) 
            {
                result[i] = null;  // No more nodes left to assign
                continue;
            }

            // Determine the size of the current part
            int currentSize = size + (extra > 0 ? 1 : 0);
            extra--;  // Use one extra node, if available

            // Assign the current node as the start of this part
            result[i] = curr;

            // Move to the end of the current part
            for (int j = 1; j < currentSize; j++)
                curr = curr.next;

            // Save curr.next which will be head of next linkedlist
            ListNode next = curr.next;
            curr.next = null;  // Terminate the current part
            curr = next;  // Move to the next node
        }
        return result;
    }
