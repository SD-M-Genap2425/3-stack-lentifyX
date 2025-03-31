using System;
using System.Collections.Generic;

namespace Solution.BrowserHistory
{
    public class Halaman
    {
        public string URL { get; }
        public Halaman(string url)
        {
            URL = url;
        }
    }

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

    public class HistoryManager
    {
        private Stack<Halaman> history;

        public HistoryManager()
        {
            history = new Stack<Halaman>();
        }
        public void KunjungiHalaman(string url)
        {
            history.Push(new Halaman(url));
        }
        public string Kembali()
        {
        if (history.IsEmpty())
            return "Tidak ada halaman sebelumnya.";
        history.Pop();
        return history.IsEmpty() ? "Tidak ada halaman sebelumnya." : history.Peek()?.URL ?? "Tidak ada halaman sebelumnya.";
        }
        public string LihatHalamanSaatIni()
        {
            return history.IsEmpty() ? "Empty" : history.Peek()?.URL ?? "Empty";
        }
        public void TampilkanHistory()
        {
            Stack<Halaman> tempStack = new Stack<Halaman>();

            while (!history.IsEmpty())
            {
                Halaman? halaman = history.Pop();
                if (halaman != null)
                {
                    tempStack.Push(halaman);
                }
            }

            while (!tempStack.IsEmpty())
            {
                Halaman? halaman = tempStack.Pop();
                if (halaman != null)
                {
                    Console.WriteLine(halaman.URL);
                    history.Push(halaman);
                }
            }
        }
    }
}
