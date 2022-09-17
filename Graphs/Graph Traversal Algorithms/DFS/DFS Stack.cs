
public class Node
{
    public string name;
    public List<Node> children = new List<Node>();

    public Node(string name)
    {
        this.name = name;
    }

    public List<string> DepthFirstSearch(List<string> array)
    {
        Stack<Node> dfsStack = new Stack<Node>();
        dfsStack.Push(this);
        while (dfsStack.Count != 0)
        {
            Node currentPoppedNode = dfsStack.Pop();
            array.Add(currentPoppedNode.name);
            for (int i = currentPoppedNode.children.Count - 1; i >= 0; i--)
            {
                dfsStack.Push(currentPoppedNode.children[i]);
            }
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

