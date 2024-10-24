
public class Solution {
    public bool FlipEquiv(TreeNode root1, TreeNode root2) {
        return DFS(root1, root2);
    }

    private bool DFS(TreeNode root1, TreeNode root2)
    {
        // If both nodes are null, they are equivalent.
        if (root1 == null && root2 == null) return true;

        // If one is null and the other is not, they are not equivalent.
        if (root1 == null || root2 == null) return false;
        
        // If values of the nodes are different, they are not equivalent.
        if (root1.val != root2.val) return false;

        // Check both scenarios:
        // 1. No flip needed (left with left, right with right).
        // 2. Flip needed (left with right, right with left).
        bool noFlip = DFS(root1.left, root2.left) && DFS(root1.right, root2.right);
        bool flip = DFS(root1.left, root2.right) && DFS(root1.right, root2.left);

        return noFlip || flip;
    }
}

