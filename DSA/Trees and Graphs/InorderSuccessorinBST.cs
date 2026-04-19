// https://www.geeksforgeeks.org/problems/inorder-successor-in-bst/1

// https://www.lintcode.com/problem/915/description

class Solution {
    // returns the inorder successor of the Node x in BST (rooted at 'root')
    public int inorderSuccessor(Node root, Node x) {
        Node current = root;
        Node parent = null;
        while (current != null)
        {
            if (current == x)
            {
                if(current.right==null){
                    return parent==null? -1: parent.data;    
                } 

                Node successor = current.right;
                while(successor!=null && successor.left != null)
                {
                    successor = successor.left;
                }
                return successor.data;
            }
            else if (x.data < current.data)
            {
                //explore left subtree
                parent = current;
                current = current.left;
            }
            else
            {
                //explor right subtree
                current = current.right;
            }
        }
        return -1;
    }
}