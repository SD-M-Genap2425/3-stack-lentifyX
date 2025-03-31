using System;
using System.Collections.Generic;

namespace Solution.Palindrome
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
        public T? Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Empty");
            return top!.Data; 
        }
        public bool IsEmpty()
        {
            return top == null;
        }
    }

    public static class PalindromeChecker
    {
        public static bool CekPalindrom(string input)
        {
            string normalized = new string(input.ToLower().Where(char.IsLetterOrDigit).ToArray());
            Stack<char> stack = new Stack<char>();

            foreach (char c in normalized)
                stack.Push(c);
            foreach (char c in normalized)
            {
                if (c != stack.Pop())
                    return false;
            }
            return true;
        }
    }
}
