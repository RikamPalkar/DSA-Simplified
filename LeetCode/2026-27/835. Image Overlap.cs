public class Solution {

    // Time: O(N^2 + K^2) = K = number of 1s
    // Space: O(K^2)
    public int LargestOverlap(int[][] img1, int[][] img2) {

        List<(int row, int col)> img1_Ones = [];
        List<(int row, int col)> img2_Ones = [];
        Dictionary<(int row, int col), int> shiftCount = [];

        for(int i=0; i<img1.Length; i++){
            for(int j=0; j<img1[0].Length; j++){
                if(img1[i][j] == 1) img1_Ones.Add((i, j));
                if(img2[i][j] == 1) img2_Ones.Add((i, j));
            }
        }

        foreach(var img1rc in img1_Ones){
            foreach(var img2rc in img2_Ones){
                int diffR = img2rc.row - img1rc.row;
                int diffC = img2rc.col - img1rc.col;
                shiftCount[(diffR, diffC)] = shiftCount.GetValueOrDefault((diffR, diffC)) + 1;
            }
        }

        return shiftCount.Count == 0 ? 0 : shiftCount.Values.Max();
    }
}
/*
1 1 = 1
2 1 = 1
2 2 = 1

1 0 = 1
1 1 = 1
2 1 = 1

0 0 = 1
0 1 = 1
1 1 = 1

1 0 = 1
1 -1 = 1
0 1 = 1
*/

/*
Intuition
Instead of actually shifting the images, consider the relative shift between every pair of 1s.

Store the (row, col) position of every 1 in both images.

Pick one 1 from img1 and one 1 from img2.

Calculate their shift:

diffR = row2 - row1
diffC = col2 - col1
If multiple pairs produce the same shift, those pixels can overlap when the image is moved by that shift.

Use a dictionary to count how many times each shift occurs.

The shift with the highest count gives the maximum overlap.

Approach
Store all 1 coordinates from both images.
Compare every 1 from img1 with every 1 from img2.
Calculate (diffR, diffC) for each pair.
Store the frequency of each shift in a dictionary.
Return the highest frequency.
Complexity
Time complexity: O(N² + K²)
Space complexity: O(K²)
Where:

N = matrix dimension
K = number of 1s in the images.
*/