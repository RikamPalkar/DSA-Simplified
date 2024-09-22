public class Solution {
    public IList<int> LexicalOrder(int n) {

       List<int> lexicalNumbers = [];
       for(int i=1; i<=9; i++)
       {
            DFS(i, n, lexicalNumbers);
       } 
       return lexicalNumbers;
    }
    
    private void DFS(int curr, int n, List<int> lexicalNumbers)
    {
        if(curr >  n) return;
        lexicalNumbers.Add(curr);

        int nextTenDigits = curr*10;

        for(int i=0; i<=9; i++)
        {
            DFS(i+nextTenDigits, n, lexicalNumbers);
        } 
    }
}
