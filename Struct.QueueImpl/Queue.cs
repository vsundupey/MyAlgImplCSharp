using System;

namespace Struct.QueueImpl
{
    /// <summary>
    /// Simple generic queue implementation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Queue<T>
    {
        private class Node<T2>
        {
            public T2 Data { get; }
            public Node<T2> Next { get; set; }
            
            public Node(T2 data)
            {
                Data = data;
            }
        }

        private Node<T> _head;
        private Node<T> _tail;

        public bool IsEmpty()
        {
            return _head == null;
        }

        public T Peek()
        {
            return _head.Data;
        }

        public void Add(T data)
        {
            var newNode = new Node<T>(data);
            
            if (_head == null)
            {
                _head = newNode;
                _tail = _head;
                return;
            }

            _tail.Next = newNode;
            _tail = _tail.Next;
        }

        public void Remove()
        {
            _head = _head.Next;
        }

        public T Dequeue()
        {
            var value = Peek();
            Remove();
            return value;
        }
    }
}