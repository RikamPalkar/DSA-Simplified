public class Program
{ 
    public static void Main(string[] args)
    {
        SuffixTrie suff = new SuffixTrie("GOOGLE");
    }
}


public class TrieNode
{
    public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
}

public class SuffixTrie
{
    public TrieNode root = new();
    public char endSymbol = '*';

    public SuffixTrie(string str)
    {
        PopulateSuffixTrieFrom(str);
    }

    //Time: O(n^2), Space: O(n^2)
    public void PopulateSuffixTrieFrom(string str)
    {
        for (int i = 0; i < str.Length; i++)
        {
            TrieNode parent = root;
            for (int j = i; j < str.Length; j++)
            {
                if (!parent.Children.ContainsKey(str[j]))
                {
                    parent.Children.Add(str[j], new TrieNode());
                }
                parent = parent.Children[str[j]];
            }
            parent.Children[endSymbol] = null;
        }
    }

    //Time: O(n), Space: O(1)
    public bool Contains(string str)
    {
        TrieNode parent = root;
        for (int i = 0; i < str.Length; i++)
        {
            if (!parent.Children.ContainsKey(str[i]))
            {
                return false;
            }
            parent = parent.Children[str[i]];
        }
        return parent.Children.ContainsKey(endSymbol);
    }
}