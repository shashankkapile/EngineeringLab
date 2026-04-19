//  https://leetcode.com/explore/interview/card/top-interview-questions-medium/108/trees-and-graphs/790/
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
    public int KthSmallest(TreeNode root, int k) {
        
        // #1. Recursion
        // int ans = -1;
        // Recur(root, ref k, ref ans);
        // return ans;

        // #2. Iterative
        return Iter(root, k);
    }


    private int Iter(TreeNode root, int k){
        var stack = new Stack<TreeNode>();
        var current = root;
        while(current!=null || stack.Count>0){
            
            while(current!=null){
                stack.Push(current);
                current = current.left;
            }

            current = stack.Pop();
            k--;
            if(k==0) return current.val;
            current = current.right;
        }
        return -1;
    }

    private void Recur(TreeNode root, ref int k, ref int ans){
        if(root==null) return;

        Recur(root.left, ref k, ref ans);
        k--;
        if(k==0){
            ans = root.val;
            return;
        }
        Recur(root.right, ref k, ref ans);
    }

}