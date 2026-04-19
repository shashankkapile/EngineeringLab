// https://leetcode.com/explore/interview/card/top-interview-questions-medium/108/trees-and-graphs/787/
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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        // #1. Iterative 
        // return IterativeBfs(root);

        // #2. Recursive
        var result = new List<IList<int>>();
        RecursiveBfs(root, 0, result);
        for(int i=0; i<result.Count; i++){
            if(i%2==0) continue;
            result[i] = result[i].Reverse().ToArray();
        }
        return result;
    }

    private void RecursiveBfs(TreeNode node, int level, List<IList<int>> result){
        if(node==null) return;

        //init first time
        if(level==result.Count){
            var row = new List<int>();
            result.Add(row);
        }

        result[level].Add(node.val);
        RecursiveBfs(node.left, level+1, result);
        RecursiveBfs(node.right, level+1, result);
    }

    private IList<IList<int>> IterativeBfs(TreeNode root){
        var q = new Queue<TreeNode>();
        var result = new List<IList<int>>();
        if(root!=null) q.Enqueue(root);
        int levelNo = 0;
        while(q.Count>0){
            var levelNodes = new List<int>();
            int levelCount = q.Count;
            for(int i=0; i<levelCount; i++){
                var node = q.Dequeue();
                levelNodes.Add(node.val);
                if(node.left!=null) q.Enqueue(node.left);
                if(node.right!=null) q.Enqueue(node.right);
            }
            if(levelNo%2!=0) levelNodes.Reverse();
            result.Add(levelNodes);
            levelNo++;
        }
        return result;
    }
}