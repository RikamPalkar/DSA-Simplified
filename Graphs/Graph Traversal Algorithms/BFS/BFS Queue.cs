
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
        Queue<Node> bfs = new Queue<Node>();
        bfs.Enqueue(this);
        while (bfs.Count != 0)
        {
            Node currentNode = bfs.Dequeue();
            array.Add(currentNode.name);
            foreach (Node currentChild in currentNode.children)
            {
                bfs.Enqueue(currentChild);
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

