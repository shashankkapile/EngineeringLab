public class Solution {
    public int EvalRPN(string[] tokens) {
        
        var stack = new Stack<int>();
        
        foreach(var token in tokens){
            
            switch(token){
                
                case "+": 
                    stack.Push(stack.Pop()+stack.Pop());
                    break;
                case "-": 
                    var num2 = stack.Pop();
                    var num1 = stack.Pop();
                    stack.Push(num1-num2);
                    break;
                case "*": 
                    stack.Push(stack.Pop()*stack.Pop());
                    break;
                case "/": 
                    var num22 = stack.Pop();
                    var num11= stack.Pop();
                    stack.Push(num11/num22);
                    break;
                default:
                    stack.Push(int.Parse(token));
                    break;
            }
        }
        
        return stack.Peek();
    }
}