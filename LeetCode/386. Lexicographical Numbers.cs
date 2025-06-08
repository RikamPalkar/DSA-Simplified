public class Solution {

    public IList<int> LexicalOrder(int n) {
        IList<int> res = [];

        for(int i=1; i<=9; i++)
            DFS(i, res, n);

        return res;
    }

    private void DFS(int index, IList<int> res, int n){
        if(index > n) return;

        res.Add(index);
        index = index*10;

        if(index > n) return;//No point of going further

        for(int i = index; i <= index+9; i++){
            DFS(i, res, n);
        }
    }
}
