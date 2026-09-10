/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution
{
    private int res = 0;

    public int AverageOfSubtree(TreeNode root)
    {
        Helper(root);
        return res;
    }

    // Bottom-up traversal:
    // Calculate the sum and count of the subtree using
    // the already calculated results from the left and right subtrees.
    private (int sum, int count) Helper(TreeNode node)
    {
        if (node == null)
            return (0, 0);

        var left = Helper(node.left);
        var right = Helper(node.right);

        int sum = node.val + left.sum + right.sum;
        int count = 1 + left.count + right.count;

        // Check whether the average of the subtree
        // is equal to the current node's value.
        if (sum / count == node.val)
            res++;

        return (sum, count);
    }
}

/*
 * Time Complexity: O(n)
 * Each node is processed exactly once.
 *
 * Space Complexity: O(h)
 * Due to the recursion stack, where h is the height of the tree.
 */


 /**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution
{
    private int res = 0;

    public int AverageOfSubtree(TreeNode root)
    {
        HelperRecursion(root);
        return res;
    }

    // Top-down traversal:
    // For every node, calculate its entire subtree again.
    private void HelperRecursion(TreeNode root)
    {
        if (root == null)
            return;

        var (sum, count) = Helper(root);

        if (sum / count == root.val)
            res++;

        HelperRecursion(root.left);
        HelperRecursion(root.right);
    }

    // Calculates the sum and count of the entire subtree.
    private (int sum, int count) Helper(TreeNode node)
    {
        if (node == null)
            return (0, 0);

        return (
            node.val + Helper(node.left).sum + Helper(node.right).sum,
            1 + Helper(node.left).count + Helper(node.right).count
        );
    }
}

/*
 * Time Complexity: O(n²) in the worst case.
 * Subtree information is recalculated for every node.
 *
 * Space Complexity: O(h)
 * Due to the recursion stack, where h is the height of the tree.
 */