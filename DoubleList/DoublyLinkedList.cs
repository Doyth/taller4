using System.Collections.Generic;
using System.Numerics;

namespace DoubleList;

public class DoublyLinkedList<T>
{
    private DoubleNode<T>? _head;
    private DoubleNode<T>? _tail;
    private bool _upward;

    public DoublyLinkedList()
    {
        _tail = null;
        _head = null;
        _upward = true;
    }

    public void InsertAtBeginning(T data)
    {
        var newNode = new DoubleNode<T>(data);
        if (_head == null) // Empty list
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }
    }

    public void InsertInOrder(T data)
    {
        var newNode = new DoubleNode<T>(data);
        if (_head == null) // Empty list
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            var current = _head;
            if (_upward)
            {   // search for a node where Current.data is less than data
                while (current != null && current.Data.ToString().CompareTo(data) < 0)
                {
                    current = current.Next;
                }

            }
            else
            {   // search for a node where Current.data is greater than data
                while (current != null && current.Data.ToString().CompareTo(data) > 0)
                {
                    current = current.Next;
                }

            }

            if (current == null)
            {
                // Insert at the end
                InsertAtEnd(data);
            }
            else if (current.Prev == null)
            {
                // Insert at the beginning
                InsertAtBeginning(data);
            }
            else
            {
                // Insert in the previous position
                current.Prev.Next= newNode;
                newNode.Prev = current.Prev;
                newNode.Next = current;
                current.Prev = newNode;

            }
        }

    }

    public void InsertAtEnd(T data)
    {
        var newNode = new DoubleNode<T>(data);
        if (_tail == null) // Empty list
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            newNode.Prev = _tail;
            _tail = newNode;
        }
    }

    public string GetForward()
    {
        var output = string.Empty;
        var current = _head;
        while (current != null)
        {
            output += $"{current.Data} <=> ";
            current = current.Next;
        }
        return output.Substring(0, output.Length-5);
    }

    public string GetBackward()
    {
        var output = string.Empty;
        var current = _tail;
        while (current != null)
        {
            output += $"{current.Data} <=> ";
            current = current.Prev;
        }
        return output.Substring(0, output.Length - 5);
    }

    public void Remove(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                if (current.Prev != null)
                {
                    current.Prev.Next = current.Next;
                }
                else
                {
                    _head = current.Next; // Remove head
                }

                if (current.Next != null)
                {
                    current.Next.Prev = current.Prev;
                }
                else
                {
                    _tail = current.Prev; // Remove tail
                }

                break;
            }
            current = current.Next;
        }
    }
    public void ReverseList()
    {
        (_tail, _head) = (_head, _tail);
        var current = _head;
        while (current != null)
        {
            (current.Next, current.Prev) = (current.Prev, current.Next);
            current = current.Next;
        }
        _upward = !_upward;
    }

    public string Graphic()
    {
        var current = _head;
        Dictionary<string, int> counter = new Dictionary<string, int>();

        while (current != null)
        {
            try {
                counter[current.Data.ToString()] += 1;
            
            }
            catch {
                counter.Add(current.Data.ToString(), 1);
            }
            current = current.Next;
        }
        var graph = "";

        foreach (KeyValuePair<string, int> kvp in counter)
        {
            var val = String.Empty;
            for (global::System.Int32 i = 0; i < kvp.Value; i++)
            {
                val += "*";
            }
            graph += "\n" + kvp.Key + val;

        }

        return graph;
    }

        public string Moda()
    {
        var current = _head;
        Dictionary<string, int> counter = new Dictionary<string, int>();

        while (current != null)
        {
            try {
                counter[current.Data.ToString()] += 1;
            
            }
            catch {
                counter.Add(current.Data.ToString(), 1);
            }
            current = current.Next;
        }
        var max = counter.Values.Max();
        string results = "";

        foreach (KeyValuePair<string, int> kvp in counter)
        {
            if (kvp.Value == max)
            {
                results += kvp.Key + "-";
            }
        }
        return results;
    }
    public bool Exists(T data)
    {
        var exists = false;
        var current = _head;
        while (current != null)
        {
            if (current.Data.Equals(data))
            {
                exists = true;
                break;
            }
            current = current.Next;
        }
        return exists;
    }


    public void RemoveAllOcurrences(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                if (current.Prev != null)
                {
                    current.Prev.Next = current.Next;
                }
                else
                {
                    _head = current.Next; // Remove head
                }

                if (current.Next != null)
                {
                    current.Next.Prev = current.Prev;
                }
                else
                {
                    _tail = current.Prev; // Remove tail
                }
            }
            current = current.Next;
        }
    }

}