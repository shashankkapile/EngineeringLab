// https://leetcode.com/problems/add-two-numbers/
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {

        //1 Iterative
        return Iterative(l1, l2);

        //2 Recursive
        // ListNode newHead = new ListNode();
        // ListNode current = newHead;

        // Recursive(l1, l2, current, 0);
        // return newHead.next;
    }

    private ListNode Iterative(ListNode l1, ListNode l2){
        int carry = 0;
        ListNode newHead = new ListNode();
        ListNode current = newHead;
        while(l1!=null || l2!=null){

            int sum = carry;
            if(l1!=null){
                sum += l1.val;
                l1= l1.next;
            }

            if(l2!=null){
                sum += l2.val;
                l2= l2.next;
            }

            if(sum>9){
                current.next = new ListNode(sum%10);
                current = current.next;
                carry = 1;
            }
            else{
                current.next = new ListNode(sum);
                current = current.next;
                carry = 0;
            }
        }

        if(carry==1){
            current.next = new ListNode(1);
            return newHead.next;
        }

        return newHead.next;
    }

    private void Recursive(ListNode l1, ListNode l2, ListNode current, int carry){

        // Console.WriteLine(current.val);
        if(l1==null && l2==null){
            if(carry==1){
                current.next = new ListNode(1);
            }
            return;
        }
        
        int sum = carry;
        sum+= l1!=null? l1.val: 0;
        sum+= l2!=null? l2.val: 0;

        if(sum>9){
            current.next = new ListNode(sum%10);
            carry = 1;
        }
        else{
            current.next = new ListNode(sum);
            carry = 0;
        }
        Recursive( (l1!=null?l1.next:null), (l2!=null?l2.next:null), current.next, carry);
    }
}