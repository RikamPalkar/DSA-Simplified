/*
Time | Space : O(row * col)
Algorithm:
Start Moving Right: Begin at the starting point and move right.
Move and Check: After moving a certain number of steps, switch direction to down.
Expand Spiral: When moving left, increase the number of steps, then move left and up.
Repeat Pattern: After moving up, increase the number of steps again and move right and down.
Continue: Repeat this pattern, expanding the spiral outward until all cells are covered.
*/

    public int[][] SpiralMatrixIII(int rows, int cols, int rStart, int cStart) {

    List<int[]> result = [];

    int[][] directions = [
        [0, 1], // right [0 0] [0 1]
        [1, 0], // down [1 0] [1 1]
        [0, -1], // left [2 0] [2 1]
        [-1, 0] // up [3 0] [3 1]
    ];

    int nextDirection = 0; // Start with direction "right"
    int row = rStart, col = cStart;
    int steps = 0;
    int newWidth = 1; // Number of steps to take in each direction

    while (result.Count < rows * cols) 
    {
        // Check if the cell is within bounds
        if (row >= 0 && row < rows && col >= 0 && col < cols) {
            result.Add([row, col]);
        }

        // Move to the next cell in the current direction
        row += directions[nextDirection][0];
        col += directions[nextDirection][1];

        // Check if we need to change direction
        steps++;

        //  Walk to right then down then increase width by 1 and walk from left to top then again increase width by 1 and walk to right and so on
        if (steps == newWidth) 
        {
            steps = 0;
            nextDirection = (nextDirection + 1) % 4; 
            
            // When you go to right you increase the width by 1, same for left
            if (nextDirection % 2 == 0) 
                newWidth++;
        }
    }

        return [..result];
    }
