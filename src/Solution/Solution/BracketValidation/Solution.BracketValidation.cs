using System;
using System.Collections.Generic;

namespace Solution.BracketValidation
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T>? Next { get; set; }
        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    public class Stack<T>
    {
        private Node<T>? top;

        public Stack()
        {
            top = null;
        }
        public void Push(T data)
        {
            Node<T> newNode = new Node<T>(data);
            newNode.Next = top;
            top = newNode;
        }
        public T? Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Empty");
            T data = top!.Data; 
            top = top.Next;
            return data;
        }

        public bool IsEmpty()
        {
            return top == null;
        }
    }

    public class BracketValidator
    {
        public bool ValidasiEkspresi(string ekspresi)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> pasangan = new Dictionary<char, char>
            {
                { ')', '(' },
                { '}', '{' },
                { ']', '[' }
            };
            foreach (char c in ekspresi)
            {
                if (pasangan.ContainsValue(c))
                    stack.Push(c);
                else if (pasangan.ContainsKey(c))
                {
                    if (stack.IsEmpty() || stack.Pop() != pasangan[c])
                        return false;
                }
            }
            return stack.IsEmpty();
        }
    }

}
