/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {

    // Encodes a tree to a single string.

//     private void serializeRecur(TreeNode root, List<string> result){
//         if(root==null) return;

//         result.Add(root.val.ToString());
//         if(root.left==null) result.Add("n");
//         else serializeRecur(root.left, result);
        
//         if(root.right==null) result.Add("n");
//         else serializeRecur(root.right, result);
//     }

    private string serializeIter(TreeNode root)
    {
        if(root==null) return "";

        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        var serialized = new StringBuilder();
        serialized.Append(root.val);

        while (q.Count > 0)
        {
            var count = q.Count;
            for(int i = 1; i<=count; i++)
            {
                var node = q.Dequeue();

                serialized.Append(",");
                if (node.left == null)
                {
                    serialized.Append("null");
                }
                else
                {
                    serialized.Append(node.left.val);
                    q.Enqueue(node.left);  
                }

                serialized.Append(",");
                if (node.right == null)
                {
                    serialized.Append("null");
                }
                else
                {
                    serialized.Append(node.right.val);
                    q.Enqueue(node.right);  
                }
            }
        }

        return serialized.ToString();
    }

    public string serialize(TreeNode root) {
        // #1. Iterative
        return serializeIter(root);

        // #2. Recursive
        // var result = new List<string>();
        // serializeRecur(root, result);
        // return string.Join(",", result);    
    }

    // Decodes your encoded data to tree.
    private TreeNode deserializeIter(string[] data)
    {
        if(data.Length==0 || data[0]=="null") return null;

        var root = new TreeNode(int.Parse(data[0])); 
        var q = new Queue<TreeNode>();
        q.Enqueue(root);

        int i = 1;
        while(i<data.Length)
        {
            var current = q.Dequeue();
            TreeNode left  = null; TreeNode right = null;

            if (data[i] != "null")
            {
                left = new TreeNode(int.Parse(data[i]));
                q.Enqueue(left);
            }
            current.left = left;
            i++;

            if(i<data.Length && data[i] != "null")
            {
                right = new TreeNode(int.Parse(data[i]));
                q.Enqueue(right);
            }
            current.right = right;
            i++;
        }

        return root;  
    }
    
    public TreeNode deserialize(string data) {
        if(data.Length==0) return null;
        var tree = data.Split(",");

        // #1. Iterative
        return deserializeIter(tree);

        // #2 Recursive
        // int rootIndex = 0;
        // return deserializeRecur(tree, ref rootIndex);
    }

    private TreeNode deserializeRecur(string[] tree, ref int rootIndex){
        if(rootIndex>=tree.Length || tree[rootIndex]=="n") return null;

        var node = new TreeNode(int.Parse(tree[rootIndex]));
        rootIndex++;
        node.left = deserializeRecur(tree, ref rootIndex);
        rootIndex++;
        node.right = deserializeRecur(tree, ref rootIndex);
        return node;
    }

//     private TreeNode desrializeIter(string[] tree){

//         var nodes = new List<TreeNode>();
//         foreach(var t in tree){
//             if(t=="null"){
//                 nodes.Add(null);
//             }
//             else{
//                 var node = new TreeNode(int.Parse(t));
//                 nodes.Add(node);
//             }
//         }

//         int index = 0;
//         foreach(var node in nodes){
//             if(node==null) continue;

//             int left = 2*index+1;
//             if(left<nodes.Count)
//                 node.left = nodes[left];
            
//             int right = 2*index+2;
//             if(right<nodes.Count)
//                 node.right = nodes[right];
            
//             index++;
//         }
//         return nodes[0];
//     }
}

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));