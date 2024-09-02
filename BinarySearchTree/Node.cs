// See https://aka.ms/new-console-template for more information
public class Node<T>
    where T : IComparableNode
{
    public T Data { get; set; }
    public Node<T>? Left { get; set; }
    public Node<T>? Right { get; set; }

    public Node(T data)
    {
        Data = data;
        Left = null;
        Right = null;
    }
}
