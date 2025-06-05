/*
Time: O(k + m) //k = length of the strings s1 and s2 // m = length of baseStr
Space: O(m) (ignoring fixed DSU size)
*/

public class Solution {
        public string SmallestEquivalentString(string s1, string s2, string baseStr) {
            UnionFind uf = new(26);
            for(int i=0; i<s1.Length; i++){
                uf.Union(s1[i] - 'a', s2[i] - 'a');
            }

            StringBuilder sb = new();
            for(int i=0; i<baseStr.Length; i++){
                int ch = baseStr[i] - 'a';
                sb.Append((char)(uf.Find(ch) + 'a')); 
            }
            return sb.ToString();
        }
    }
    public class UnionFind{
        int[] parent;

        public UnionFind(int n){
            parent = new int[n];
            for(int i=0; i<n; i++)
                parent[i] = i;     
        }

        public int Find(int x){
            if(parent[x] == x) return parent[x];
            return parent[x] = Find(parent[x]);
        }

        public void Union(int x, int y){
            int parentX = Find(x);
            int parentY = Find(y);
            if(parentX != parentY){
                // Always link to the smallest lexicographical parent
                if(parentX < parentY)parent[parentY] = parentX;
                else parent[parentX] = parentY;
            }
        }
    }


    

    //p a r k e r
    //m o   r i
    //      s
