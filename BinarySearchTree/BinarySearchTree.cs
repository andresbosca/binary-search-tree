// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

public class BinarySearchTree<T>
    where T : IComparableNode
{
    public Node<T>? Root { get; private set; }

    public BinarySearchTree()
    {
        Root = null;
    }

    // Método para inserir uma nova música na árvore
    public void Insert(T data)
    {
        Root = InsertRecursively(Root, data);
    }

    public T Search(int id)
    {
        return SearchRecursively(Root, id);
    }

    private T SearchRecursively(Node<T>? node, int id)
    {
        if (node == null)
        {
            throw new KeyNotFoundException("Música não encontrada");
        }

        if (id == node.Data.Id)
        {
            return node.Data;
        }

        if (id < node.Data.Id)
        {
            return SearchRecursively(node.Left, id);
        }

        return SearchRecursively(node.Right, id);
    }

    private Node<T> InsertRecursively(Node<T>? node, T data)
    {
        if (node == null)
        {
            node = new Node<T>(data);
            return node;
        }

        if (data.Id < node.Data.Id)
        {
            node.Left = InsertRecursively(node.Left, data);
        }
        else if (data.Id > node.Data.Id)
        {
            node.Right = InsertRecursively(node.Right, data);
        }

        return node;
    }

    // Método para buscar músicas similares
    public List<T> SearchSimilar(T musica, int maxResults)
    {
        List<T> similares = [];
        SearchSimilarRecursively(Root, musica, similares, maxResults);
        return similares;
    }

    private void SearchSimilarRecursively(Node<T>? node, T data, List<T> similares, int maxResults)
    {
        if (node == null || similares.Count >= maxResults)
        {
            return;
        }

        int similaridade = data.CalcularSimilaridade(node.Data);
        if (similaridade > 0)
        {
            similares.Add(node.Data);
        }

        SearchSimilarRecursively(node.Left, data, similares, maxResults);
        SearchSimilarRecursively(node.Right, data, similares, maxResults);
    }

    // Método para exibir a árvore (visualização simples em texto)
    public void Display()
    {
        DisplayRecursively(Root, 0);
    }

    private void DisplayRecursively(Node<T>? node, int indent)
    {
        if (node == null)
        {
            return;
        }

        DisplayRecursively(node.Right, indent + 4);
        Console.WriteLine(new string(' ', indent) + node.Data.ToString());
        DisplayRecursively(node.Left, indent + 4);
    }

    class NodeInfo
    {
        public Node<T>? Node;
        public string? Text;
        public int StartPos;
        public int Size
        {
            get { return Text.Length; }
        }
        public int EndPos
        {
            get { return StartPos + Size; }
            set { StartPos = value - Size; }
        }
        public NodeInfo? Parent,
            Left,
            Right;
    }

    public void Print(int spacing = 1, int topMargin = 2, int leftMargin = 2)
    {
        var root = Root;
        if (root == null)
            return;

        int rootTop = Console.CursorTop + topMargin;
        var last = new List<NodeInfo>();
        var next = root;
        for (int level = 0; next != null; level++)
        {
            var item = new NodeInfo { Node = next, Text = next.Data?.ToString() };
            if (level < last.Count)
            {
                item.StartPos = last[level].EndPos + spacing;
                last[level] = item;
            }
            else
            {
                item.StartPos = leftMargin;
                last.Add(item);
            }
            if (level > 0)
            {
                item.Parent = last[level - 1];
                if (next == item.Parent.Node.Left)
                {
                    item.Parent.Left = item;
                    item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos - 1);
                }
                else
                {
                    item.Parent.Right = item;
                    item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos + 1);
                }
            }
            next = next.Left ?? next.Right;
            for (; next == null; item = item.Parent)
            {
                int top = rootTop + 2 * level;
                Print(item.Text, top, item.StartPos);
                if (item.Left != null)
                {
                    Print("/", top + 1, item.Left.EndPos);
                    Print("_", top, item.Left.EndPos + 1, item.StartPos);
                }
                if (item.Right != null)
                {
                    Print("_", top, item.EndPos, item.Right.StartPos - 1);
                    Print("\\", top + 1, item.Right.StartPos - 1);
                }
                if (--level < 0)
                    break;
                if (item == item.Parent.Left)
                {
                    item.Parent.StartPos = item.EndPos + 1;
                    next = item.Parent.Node.Right;
                }
                else
                {
                    if (item.Parent.Left == null)
                        item.Parent.EndPos = item.StartPos - 1;
                    else
                        item.Parent.StartPos += (item.StartPos - 1 - item.Parent.EndPos) / 2;
                }
            }
        }
        Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
    }

    private static void Print(string s, int top, int left, int right = -1)
    {
        Console.SetCursorPosition(left, top);
        if (right < 0)
            right = left + s.Length;
        while (Console.CursorLeft < right)
            Console.Write(s);
    }
}
