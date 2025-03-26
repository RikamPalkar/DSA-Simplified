//Time: O(n log n). Space O(n)

public class Solution {
    public int MinOperations(int[][] grid, int x) {

        //O(row*col)
        List<int> sortedGrid = [];
        for(int row = 0; row<grid.Length; row++)
            for(int col = 0; col<grid[row].Length; col++)
                sortedGrid.Add(grid[row][col]);
            
        int res = 0;
        sortedGrid.Sort(); //O(n log n)
        int mid = sortedGrid[sortedGrid.Count/2];

        foreach(int num in sortedGrid){ //O(n)
            //You cannot add an even number to an odd number and get an even result, and vice versa.
            if((num % x) != (mid % x)) return -1;
            res += Math.Abs(mid - num)/x; 
        }
        return res;
    }
}
