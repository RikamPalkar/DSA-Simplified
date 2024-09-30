public class CustomStack {

    int[] stack;
    int top = 0;
    int size = 0;

    public CustomStack(int maxSize) {
        stack = new int[maxSize];
        size = maxSize;
    }
    
    public void Push(int x) {
        if(top < size)
        {      
            stack[top] = x;  
            top++;   
        }
    }
    
    public int Pop() { 
        if(top == 0) return -1;

        top--;
        return stack[top];        
    }
    
    public void Increment(int k, int val) {
        int limit = Math.Min(k, top);
        for (int i = 0; i < limit; i++)
        {
            stack[i] += val;
        }
    }
}

/**
 * Your CustomStack object will be instantiated and called as such:
 * CustomStack obj = new CustomStack(maxSize);
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * obj.Increment(k,val);
 */
