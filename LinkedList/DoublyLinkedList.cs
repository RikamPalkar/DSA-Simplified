DoublyLinkedList linkedList = new();
linkedList.SetHead(new Node(1));
linkedList.SetTail(new Node(5));
linkedList.PrintLinkedList();
Console.WriteLine();

Console.WriteLine("New Head: 0");
linkedList.SetHead(new Node(0));
linkedList.PrintLinkedList();
Console.WriteLine();

Console.WriteLine("Add 3, Before : 5");
Node node5 = linkedList.GetNodeWithValue(5);
linkedList.InsertBefore(node5, new Node(3));
linkedList.PrintLinkedList();
Console.WriteLine();

Console.WriteLine("Add 4, After : 3");
Node node3 = linkedList.GetNodeWithValue(3);
linkedList.InsertAfter(node3, new Node(4));
linkedList.PrintLinkedList();
Console.WriteLine();

Console.WriteLine("Insert 2 at position 3");
linkedList.InsertAtPosition(3, new Node(2));
linkedList.PrintLinkedList();
Console.WriteLine();

Console.WriteLine("Contains 4?: " + linkedList.ContainsNodeWithValue(4));
Console.WriteLine();

Console.WriteLine("Removing node with value: 4");
linkedList.RemoveNodesWithValue(4);
linkedList.PrintLinkedList();
Console.WriteLine();

Console.WriteLine("Removing head! 0");
linkedList.Remove(linkedList.Head);
linkedList.PrintLinkedList();
Console.WriteLine();
public class DoublyLinkedList
{
    public Node Head;
    public Node Tail;

    //Time: O(1), Space: O(1)
    public void SetHead(Node node)
    {
        if (this.Head == null)
        {
            this.Head = node;
            this.Tail = node;
        }
        else
        {
            InsertBefore(Head, node);
        }
    }

    //Time: O(1), Space: O(1)
    public void SetTail(Node node)
    {
        //if list is empty.
        if (this.Tail == null)
        {
            //Since head creates a node which is both head and tail.
            SetHead(node);
        }
        else
        {
            InsertAfter(Tail, node);
        }
    }

    //Time: O(1), Space: O(1)
    public void InsertBefore(Node node, Node nodeToInsert)
    {
        //Check if there is only one node in list
        if (nodeToInsert == Head && nodeToInsert == Tail)
        {
            return;
        }
        Remove(nodeToInsert);

        // Insert before 40, 30: 10 <-> 20 <-> 40
        // First make sure new Node is in place
        nodeToInsert.Next = node; // 30 -> 40 //If node was first node then newNode will point to null
        nodeToInsert.Prev = node.Prev; // 20 <- 30

        //If node was first node then newNode will point to null but we have make it Head
        if (node.Prev == null)
        {
            this.Head = nodeToInsert;
        }
        else
        {
            //if it is not a first node then node's previous's next will point to newNode
            node.Prev.Next = nodeToInsert; // 20 -> 30
        }
        node.Prev = nodeToInsert; //30 <- 40 
    }

    //Time: O(1), Space: O(1)
    public void InsertAfter(Node node, Node nodeToInsert)
    {
        //Check if there is only one node in list
        if (nodeToInsert == Head && nodeToInsert == Tail)
        {
            return;
        }
        Remove(nodeToInsert);

        //Insert after 20, 30: 10 <-> 20 <-> 40
        //First make sure new Node is in place
        nodeToInsert.Next = node.Next; // 30 -> 40 //If node was last node then newNode will point to null
        nodeToInsert.Prev = node; // 20 <- 30

        //If node was last node then newNode will point to null but we have make it Tail
        if (node.Next == null)
        {
            this.Tail = nodeToInsert;
        }
        else
        {
            //if it is not a last node then node's next's previous will point to newNode
            node.Next.Prev = nodeToInsert; // 30 <- 40
        }
        node.Next = nodeToInsert; //20 -> 30 
    }

    //Time: O(position), Space: O(1)
    public void InsertAtPosition(int position, Node nodeToInsert)
    {
        if (position == 1)
        {
            SetHead(nodeToInsert);
        }
        else
        {
            // Insert at 3, 30: 10 <-> 20 <-> 40
            int currentPosition = 1;
            Node currentNode = this.Head;
            while (currentNode != null && position != currentPosition)
            {
                currentPosition++;
                currentNode = currentNode.Next;
            }
            if (currentNode != null)
            {
                InsertBefore(currentNode, nodeToInsert);
            }
            else
            {
                //Reached last element// position : 4
                SetTail(nodeToInsert);
            }
        }
    }

    //Time: O(1), Space: O(1)
    public void Remove(Node node)
    {
        // Remove Head 10 <-> 20 <-> 30 <-> 40
        if (node == this.Head)
        {
            this.Head = this.Head.Next; //20 <-> 30 <-> 40
        }
        // Remove Tail 40 <-> 20 <-> 30 <-> 40
        if (node == this.Tail)
        {
            this.Tail = this.Tail.Prev; //10 <-> 20 <-> 30           
        }
        RemoveNodeFromBetween(node);
    }

    //Time: O(n), Space: O(1)
    public void RemoveNodesWithValue(int value)
    {
        // Remove 30: 10 <-> 20 <-> 30 <-> 40
        //Traverse the list
        Node currentNode = this.Head;
        while (currentNode != null)
        {
            Node nodeToRemove = currentNode;
            currentNode = currentNode.Next;
            if (nodeToRemove.Value == value)
            {
                Remove(nodeToRemove);
            }
        }
    }

    //Time: O(n), Space: O(1)
    private void RemoveNodeFromBetween(Node node)
    {
        // Remove 20: 10 <-> 20 <-> 30 <-> 40
        if (node.Prev != null)
        {
            node.Prev.Next = node.Next; // 10 -> 30
        }
        if (node.Next != null)
        {
            node.Next.Prev = node.Prev; // 10 <- 30 
        }
        //Removing references
        node.Prev = null;
        node.Next = null;
    }

    //Time: O(n), Space: O(1)
    public bool ContainsNodeWithValue(int value)
    {
        // 30: 10 <-> 20 <-> 30 <-> 40

        //Traverse the list
        Node currentNode = this.Head;
        while (currentNode != null && currentNode.Value != value)
        {
            currentNode = currentNode.Next;
        }
        return currentNode != null;
    }

    //Time: O(n), Space: O(1)
    public Node GetNodeWithValue(int value)
    {
        // 30: 10 <-> 20 <-> 30 <-> 40

        //Traverse the list
        Node currentNode = this.Head;
        while (currentNode != null && currentNode.Value != value)
        {
            currentNode = currentNode.Next;
        }
        return currentNode;
    }

    //Time: O(n), Space: O(1)
    public void PrintLinkedList()
    {
        Node head = this.Head;
        while (head != null)
        {
            Console.Write(head.Value + " <-> ");
            head = head.Next;
        }
        Console.WriteLine("Null");
    }
}

public class Node
{
    public int Value;
    public Node Prev;
    public Node Next;

    public Node(int value) => this.Value = value;
}

