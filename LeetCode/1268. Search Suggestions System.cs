public class Solution {
    TrieNode root;
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord) {
        Array.Sort(products); // lexicographic order
        root = new();
        foreach(string product in products){
            Insert(product);
        }
        return Find(searchWord);
    }

    // Build Trie
    private void Insert(string product){
        TrieNode current = root;
        foreach(char ch in product){
            int index = ch - 'a';
            if(current.Children[index] == null)
            {
                current.Children[index] = new();
            }
            current = current.Children[index];
        }
        current.IsEnd = true;
    }

    private IList<IList<string>> Find(string product){
        TrieNode current = root;
        StringBuilder prefix = new();
        IList<IList<string>> res = [];

        foreach(char ch in product){
            prefix.Append(ch);

            int index =  ch - 'a';

            if(current.Children[index] != null){
                current = current.Children[index];
            }
            else
            {
                // No further prefix match, fill remaining with empty lists
                while(res.Count < product.Length){
                    res.Add(new List<string>());
                }
                break;
            }

            List<string> suggestions = [];
            DFS(current, prefix, suggestions);
            res.Add(suggestions);
        }
        return res;
    }

    private void DFS(TrieNode root, StringBuilder prefix, List<string> suggestions)
    {
        if(suggestions.Count == 3) return; // Only need top 3 suggestions
        if(root.IsEnd) suggestions.Add(prefix.ToString());

        int i = 0;
        foreach(var curr in root.Children){
            if(curr != null){
                char nextChar = (char)(i + 'a'); // Add next character
                prefix.Append(nextChar);
                DFS(curr,prefix, suggestions);
                prefix.Length--; // Backtrack
            }
            i++;
        }
    }
}

public class TrieNode{
    public TrieNode[] Children = new TrieNode[26];
    public bool IsEnd =  false;
}

/*
| Component          | Time Complexity              | Space Complexity  |
| ------------------ | ---------------------------- | ----------------- |
| Sorting            | O(n log n * m)               | —                 |
| Trie Construction  | O(n * m)                     | O(n * m)          |
| Search Suggestions | O(s * m)                     | O(s) + O(m stack) |
| Overall            | O(n log n * m + s * m)       | O(n * m)          |
 m is the maximum length of any product string in the products array
 products = ["mobile", "mouse", "moneypot", "monitor", "mousepad"]
s is the length of the searchWord.
*/
