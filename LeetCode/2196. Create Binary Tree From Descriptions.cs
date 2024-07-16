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
public class Solution {
    public TreeNode CreateBinaryTree(int[][] descriptions) {
    Dictionary<int, TreeNode> dict = [];
    HashSet<int> children = new();

    foreach (int[] description in descriptions) {
        int parent = description[0];
        int child = description[1];
        bool isLeft = description[2] == 1;

        if (!dict.ContainsKey(parent)) 
            dict[parent] = new TreeNode(parent);
        
        if (!dict.ContainsKey(child)) 
            dict[child] = new TreeNode(child);
        
        if (isLeft) 
            dict[parent].left = dict[child];
        else 
            dict[parent].right = dict[child];

        children.Add(child);
    }

    foreach (int parent in dict.Keys) {
        if (!children.Contains(parent)) {
            return dict[parent];
        }
    }

    return null;
    }
}

/**
Algorithm

    Initialization:
        dict: To store the nodes of the tree.
        children: To keep track of all nodes that are children.

    Loop:
        For each entry [parent, child, isLeft]:
            If parent node does not exists, create new entry in dict, else parent will already be present in dict so we can directly access while assigning child to it.
            If child node does not exists, create new entry in dict, else child will already be present in dict so we can directly access to be assigned to parent.
            Set the child as either the left or right child of the parent based on isLeft.
            Update the tracking of child.

    Identify the Root:
        Find the node that is not marked as a child. This node is the root.

Example:

Input: descriptions = [[20,15,1],[20,17,0],[50,20,1],[50,80,0],[80,19,1]]

Output: [50,20,80,15,17,19]

    Processing Descriptions:

        Description [20, 15, 1]:
            Create new dict entry with 20.
            Create new dict entry with 15.
            Set 15 as the left child of 20.
            Add 15 as a child node.
            dict = {20: TreeNode(20), 15: TreeNode(15)}
            children = {15}

        Description [20, 17, 0]:
            20 exist in dict so we will update that entry.
            Create new dict entry with 17.
            Set 17 as the right child of 20.
            Add 17 as a child node.
            dict = {20: TreeNode(20), 15: TreeNode(15), 17: TreeNode(17)}
            children = {15, 17}

        Description [50, 20, 1]:
            Create new dict entry with 50.
            50 exist in dict so we will update that entry.
            Set 20 as the left child of 50.
            Add 20 as a child node.
            dict = {20: TreeNode(20), 15: TreeNode(15), 17: TreeNode(17), 50: TreeNode(50)}
            children = {15, 17, 20}

        Description [50, 80, 0]:
            50 exist in dict so we will update that entry.
            Create new dict entry with 80.
            Set 80 as the right child of 50.
            Add 80 as a child node.
            dict = {20: TreeNode(20), 15: TreeNode(15), 17: TreeNode(17), 50: TreeNode(50), 80: TreeNode(80)}
            children = {15, 17, 20, 80}

        Description [80, 19, 1]:
            80 exist in dict so we will update that entry.
            Create new dict entry with 19.
            Set 19 as the left child of 80.
            Add 19 as a child node.
            dict = {20: TreeNode(20), 15: TreeNode(15), 17: TreeNode(17), 50: TreeNode(50), 80: TreeNode(80), 19: TreeNode(19)}
            children = {15, 17, 19, 20, 80}

    Identify the Root:
        The root node is the one that is not in the children set.
        In this case, it is 50.
        dict[50] is the root node.

Final Tree Structure:

    Root: 50
        Left Child: 20
            Left Child: 15
            Right Child: 17
        Right Child: 80
            Left Child: 19

Complexity

    Time complexity: O(n)

    Space complexity: O(n)

**/
