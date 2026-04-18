/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {

        // #1 set
        // #2 skip uncommon nodes i.e remove difference and start from common point

        var currentA = headA;
        var currentB = headB;

        while(currentA != null || currentB != null)
        {
            if(currentA==currentB) return currentA;
            
            if (currentA == null)
            {
                currentA = headB;
                continue;
            }
            
            if (currentB == null)
            {
                currentB = headA;
                continue;
            }

            currentA = currentA.next;
            currentB = currentB.next;
        }

        return null;
    }
}