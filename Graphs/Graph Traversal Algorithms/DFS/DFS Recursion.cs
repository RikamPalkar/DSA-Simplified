
public class Node
{
    public string name;
    public List<Node> children = new List<Node>();

    public Node(string name)
    {
        this.name = name;
    }

    //time: O(v + e), space: O(v)
    public List<string> DepthFirstSearch(List<string> array)
    {
        array.Add(this.name);
        foreach (Node node in children)
        {
            node.DepthFirstSearch(array);
        }
        return array;
    }

    public Node AddChild(string name)
    {
        Node child = new Node(name);
        children.Add(child);
        return this;
    }
}