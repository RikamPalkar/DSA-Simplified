/**
Time: O(n log L)
Traversal of the tree: BFS : O(n)
PriorityQueue operations: O(log L) L is number of level

Space: O(n)
Queue for BFS traversal: O(n)
PriorityQueue storage: O(L)

 */
public class Solution {
    public long KthLargestLevelSum(TreeNode root, int k) 
    {
        PriorityQueue<long, long> sums = new(Comparer<long>.Create((x, y) => y.CompareTo(x)));
        Queue<TreeNode> que = [];
        que.Enqueue(root);

        while(que.Count > 0)
        {  
            long levelSum = 0;
            int size = que.Count;
            for(int i = 0; i < size; i++)
            {
                TreeNode curr = que.Dequeue();
                levelSum += curr.val;
                if(curr.left != null) que.Enqueue(curr.left);
                if(curr.right != null) que.Enqueue(curr.right);
            }
            sums.Enqueue(levelSum, levelSum);
        }

        if (sums.Count < k) return -1;

        long result = -1;
        while(k > 0)
        {
            k--;
            result = sums.Dequeue();
        }
        return result;
    }
}
