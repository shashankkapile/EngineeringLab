// https://www.geeksforgeeks.org/problems/attend-all-meetings-ii/1
class Solution {
    public int minMeetingRooms(int[] start, int[] end) {
        
        Array.Sort(start);
        Array.Sort(end);
    
        int i = 1;
        int j = 0;
        
        int rooms = 1;
        int maxRooms = 1;
        while(i<start.Length){
            if(start[i]<end[j]){
                //prev meeting is not ended, need new room
                rooms++;
                i++;
            }
            else{
                
                //prev meeting is over so destory one room
                rooms = Math.Max(rooms-1, 0);
                j++;
            }
            maxRooms = Math.Max(maxRooms, rooms);
            // Console.Write(rooms+" ");
        }
        
        return maxRooms;
    }
}