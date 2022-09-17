
public class Node
{
    public string name;
    public List<Node> children = new List<Node>();

    public Node(string name)
    {
        this.name = name;
    }

    public List<string> BreadthFirstSearch(List<string> array)
    {
        array.Add(this.name);
        foreach (Node currentChild in children)
        {
            BreadthFirstSearch(array);
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

