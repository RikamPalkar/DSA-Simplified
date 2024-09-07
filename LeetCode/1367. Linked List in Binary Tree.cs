public class Solution {
    public bool IsSubPath(ListNode head, TreeNode root) 
    {
        if (root == null || head == null) 
            return false;

        if(DFS(head, root)) return true;
        return IsSubPath(head, root.left) || 
               IsSubPath(head, root.right);
    }

    private bool DFS(ListNode head, TreeNode node)
    {
        if (head == null) return true;
        if (node == null)  return false; 
        if (node.val != head.val) return false; 
        return DFS(head.next, node.left) || 
                DFS(head.next, node.right);
    }
}
