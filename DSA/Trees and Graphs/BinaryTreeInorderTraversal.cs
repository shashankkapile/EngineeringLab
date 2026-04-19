// https://leetcode.com/explore/interview/card/top-interview-questions-medium/108/trees-and-graphs/786/
public class Solution {
    public IList<int> InorderTraversal(TreeNode root)
    {
        return Iterative(root);
    }

    
    private IList<int> Iterative(TreeNode root)
    {
        var current = root;
        var result = new List<int>();
        var stack = new Stack<TreeNode>();
        while(current!=null || stack.Count > 0)
        {
            while (current != null)
            {
                stack.Push(current);
                current = current.left;
            }

            current = stack.Pop();
            result.Add(current.val);
            current = current.right;
        }

        return result;    
    }

    private IList<int> MorrisTraversalIterative(TreeNode root)
    {
        var result = new List<int>();
        var current = root;

        while (current != null)
        {
            if (current.left == null)
            {
                result.Add(current.val);
                current = current.right;
            }
            else
            {
                var rightMost = current.left;
                while(rightMost!=null && rightMost.right!=null && rightMost.right != current)
                {
                    rightMost = rightMost.right;
                }

                if (rightMost.right == null)
                {
                    //attach it to current standing node and move to left
                    rightMost.right = current;
                    current = current.left;
                }
                else
                {
                    //break as left substree is processed, store root and move to right subtree
                    rightMost.right = null;
                    result.Add(current.val);
                    current = current.right;
                }
            }            
        }

        return result;
    }
}