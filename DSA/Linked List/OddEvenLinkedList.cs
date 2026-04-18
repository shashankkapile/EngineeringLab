/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }"
 */
public class Solution {
    public ListNode OddEvenList(ListNode head) {
        
        if(head==null || head.next == null) return head;

        ListNode current = head;
        ListNode evenHead = new ListNode(); //dummy head 
        ListNode evenCurrent = evenHead; 
        
        ListNode oddHead = new ListNode(); //dummy head
        ListNode oddCurrent = oddHead; 
        
        int index = 0;
        while(current!=null){

            ListNode nextNode = current.next;
            current.next = null;
            
            if(index%2==0){
                evenCurrent.next = current;
                evenCurrent = evenCurrent.next;
            }
            else{
                oddCurrent.next = current;
                oddCurrent = oddCurrent.next;    
            }

            index++;
            current = nextNode;
        }
    
        //merge both list
        evenCurrent.next = oddHead.next;

        return evenHead.next;
    }
}