/*Solution 1

    Store Frequency in HashMap:
        Use a dictionary to count the frequency of each character.

    Sort the HashMap in Descending Order:
        Sorting ensures the most frequent characters are processed first, which allows to assign the minimum key presses to the most frequent characters.

    Loop Through HashMap and Calculate Pushes:
        Multiplying the frequency of each character by its respective key press count based on its position in the sorted list.

Time complexity: O(n log n)
Space complexity: O(n)
*/
public int MinimumPushes(string word) {
    Dictionary<char, int> dict = [];

    foreach(char ch in word)
    {
       dict[ch] = dict.GetValueOrDefault(ch)+1; 
    }

    var freq = dict.Values.OrderByDescending(x=> x).ToList(); 

    int numberOfKeyPress  = 0;
    for(int i=0; i<freq.Count; i++)
    {
        if(i<8)
            numberOfKeyPress += (1 * freq[i]);
        
        else if(i<16)
            numberOfKeyPress += (2 * freq[i]);
        
        else if(i<24)
            numberOfKeyPress += (3 * freq[i]);

        else 
            numberOfKeyPress  += (4 * freq[i]);
    }

    return numberOfKeyPress;
}
/*
Solution 2

    Count Frequencies:
        Create an int[] of size 26 to store the frequency of each character in the input string. Each index of the array corresponds to a letter from 'a' to 'z', where freq[0] is for 'a', freq[1] is for 'b', and so on.
        Loop through the characters of the string and update the freq array by incrementing the count for each character.

    Sort Frequencies:
        Sort the freq array in descending order. This ensures that the characters with the highest frequency are processed first, which allows you to minimize the number of key presses by assigning them to keys with fewer presses.

    Calculate Total key press:
        Initialize numberOfKeyPress to sum the total number of key presses needed.
        Use the variable key to track the current number of presses required for a key (starting from 1). For every 8 characters, the key press count should be incremented.

    Loop Through Sorted Frequencies:
        For each frequency in the sorted array, calculate the total number of key presses required and add it to numberOfKeyPress.
        Increment key appropriately after every 8 characters.

    Return the total number of key presses required.

    Note: if (i > 0 && (i % 8) == 0) key++; here i > 0 because (0 % 8) == 0 will result in 0 which will incorrectly trigger increment of key.

Time complexity: O(n log n)
Space complexity: O(n)
*/

public int MinimumPushes(string word) 
{
    int[] freq = new int [26];

    for(int i=0; i<word.Length; i++)
        freq[word[i]-97]++;

    Array.Sort(freq, (a,b) => b.CompareTo(a)); 
    
    int numberOfKeyPress = 0;
    int key = 1;
    
    for (int i = 0; i < 26; i++)
    {
        if (freq[i] == 0) break;
        if (i > 0 && (i % 8) == 0) key++;

        numberOfKeyPress += freq[i] * key;        
    }
    
    return numberOfKeyPress;
}
