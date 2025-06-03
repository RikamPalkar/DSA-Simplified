public class Solution {
    public int MaxCandies(int[] status, int[] candies, int[][] keys, int[][] containedBoxes, int[] initialBoxes) {
        
        int len = status.Length;
        bool[] boxes = new bool[len]; // Do we have this box
        bool[] isOpened = new bool[len]; // Was it opened?
        int totalCandies = 0;
        Queue<int> q = []; //Process boxes in the order you discover them.
        
        foreach(int box in initialBoxes){
            q.Enqueue(box);
            boxes[box] = true;// We have this box
        }

        while(q.Count > 0){
            int currBox = q.Dequeue();

            //!isOpened[currBox] Because the same box can end up in the queue multiple times!
            if(status[currBox] == 1 && !isOpened[currBox]) 
            {
                isOpened[currBox] = true;
                totalCandies += candies[currBox];

                foreach(int key in keys[currBox]){
                    status[key] = 1; // Now I can open this box
                    //If you have the box and now you got key then add it to queue, 
                    //why not directly sum+candy because this box might be in a different location
                    if(boxes[key]) q.Enqueue(key);
                }

                foreach(int nextBox in containedBoxes[currBox]){
                    q.Enqueue(nextBox);
                    boxes[nextBox] = true;
                }
            }
        }
        return totalCandies;
    }
}





