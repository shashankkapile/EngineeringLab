public class Solution {
    // 26^place * num
    // A 26^0 * 1 = 1
    // B 26^0 * 2 = 2 
    // Z 26^0 * 26 = 26
    // AA  (26^1*1)+(26^0*1) = 26+1 = 27
    public int TitleToNumber(string columnTitle) {
        
        long num = 0;
        int place = 0;
        
        for(int i = columnTitle.Length-1; i>=0; i--){
            var digit = (columnTitle[i]-'A')+1;
            
            long sum = (int)Math.Pow(26, place) * digit;
            
            // Console.WriteLine(sum);
            place++;
            num += sum;
        }
        return (int)num;
    }
}