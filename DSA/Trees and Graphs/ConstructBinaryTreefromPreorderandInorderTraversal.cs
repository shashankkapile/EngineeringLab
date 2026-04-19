// https://leetcode.com/explore/interview/card/top-interview-questions-medium/108/trees-and-graphs/788/
// Input: preorder = [3,9,20,15,7], inorder = [9,3,15,20,7]
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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        
        // #1. Better
        // return ConstructRecurBetter(inorder, 0, inorder.Length-1, preorder, 0, preorder.Length-1);

        // #2. Optimal
        int rootIndex = 0;
        var indexMap = new Dictionary<int, int>();
        for(int i=0; i<inorder.Length; i++){
            
            indexMap[inorder[i]] = i;
        }
        return ConstructRecurOptimal(inorder, 0, inorder.Length-1, preorder, indexMap, ref rootIndex);

        // #3. Itartive
        // return ConstructIter(inorder, preorder, indexMap);
    }
    
    private TreeNode ConstructRecurOptimal(int[] inorder, int start, int end, int[] preorder, Dictionary<int, int> indexMap, ref int rootIndex){

        if(start>end) return null;

        var root = new TreeNode(preorder[rootIndex]);
        rootIndex++;

        int mid = indexMap[root.val];
        
        root.left = ConstructRecurOptimal(inorder, start, mid-1, preorder, indexMap, ref rootIndex); 
        root.right = ConstructRecurOptimal(inorder, mid+1, end, preorder, indexMap, ref rootIndex);
        return root; 
    }
}
