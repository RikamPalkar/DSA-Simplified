
     int SnakesAndLadders(int[][] board) {
        int len = board.Length;
        int steps = 0;
        Queue<int> q = [];
        q.Enqueue(1);

        bool[] visited = new bool[len*len+1];
        visited[1] = true;

        while(q.Count > 0){
            int level = q.Count;
            for(int i=0; i<level; i++){
                int curr = q.Dequeue();
                if(curr == len*len) return steps;

                for(int j=1; j<=6; j++){
                    int next = curr+j;

                    if(next > len*len) continue;
                    if(visited[next]) continue;

                    visited[next] = true;
                    int[] cell = GetRowCol(next, len);
                    int row = cell[0];
                    int col = cell[1];

                    if(board[row][col] != -1) 
                        next = board[row][col];

                    q.Enqueue(next);
                }
            }
            steps++;
        }
        return -1;

    int[] GetRowCol(int value, int len) {

        int bottomRow = (value -1)/len;
        int leftCol = (value -1)%len;
        int row = len - 1 - bottomRow;
        int col;
        
        //Even: left to right
        if(bottomRow %2 == 0){
            col = leftCol;
        }else{
            col = len - 1 - leftCol;
        }

        return [row, col];
    }
}
