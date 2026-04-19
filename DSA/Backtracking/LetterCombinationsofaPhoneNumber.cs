// https://leetcode.com/explore/interview/card/top-interview-questions-medium/109/backtracking/793


   public class Solution {
    Dictionary<int, string> keypad = new Dictionary<int, string>()
    {   
        {1, ""},
        {2, "abc"},
        {3, "def"},
        {4, "ghi"},
        {5, "jkl"},
        {6, "mno"},
        {7, "pqrs"},
        {8, "tuv"},
        {9, "wxyz"},
    };
    
    public IList<string> LetterCombinations(string digits) {
    
        var result = new List<string>();
        // if(digits.Length>0)
        //     GenerateBrute(digits, 0, keypad, new List<char>(), result);
        
        // GenerateBetter(0, "", digits, keypad, result);

        GenerateOptimal(0, digits, keypad, new List<char>(), result);
        return result;
    }

       private void GenerateOptimal(int index, string digits, Dictionary<int, string> keypad, IList<char> combo, IList<string> result){

        if(index==digits.Length){
            result.Add(new string(combo.ToArray()));
            return;
        }

        var currentDigit = digits[index]-'0';
        foreach(var letter in keypad[currentDigit]){
            combo.Add(letter);
            GenerateOptimal(index+1, digits, keypad, combo, result);
            combo.RemoveAt(combo.Count-1);
        }
    }

        private void GenerateBetter(int index, string combo, string digits, Dictionary<int, string> keypad, List<string> result)
    {
        if (index == digits.Length)
        {
            result.Add(combo);
            return;
        }

        var digit = digits[index]-'0';
        foreach(var letter in keypad[digit])
        {
            GenerateBetter(index+1, combo+letter, digits, keypad, result);
        }
    }
    
    private void GenerateBrute(string digits, int digitIndex, Dictionary<int, string> keypad, IList<char> combo, IList<string> result){

        if(digitIndex>=digits.Length){
            // Console.WriteLine(combo.Count);
            if(combo.Count==digits.Length){
                var str = string.Join("",combo);
                result.Add(str);
            }
            return;
        }

        for(int i = digitIndex; i<digits.Length; i++){
            var digit = digits[digitIndex]-'0';
            var letters = keypad[digit];
            for(int j = 0; j<letters.Length; j++){

                combo.Add(letters[j]);
                GenerateBrute(digits, i+1, keypad, combo, result);
                combo.RemoveAt(combo.Count-1);
            }
        }
    }
}