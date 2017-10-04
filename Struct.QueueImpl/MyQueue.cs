using System;

namespace Struct.QueueImpl
{
    /// <summary>
    /// Simple generic queue implementation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyQueue<T>
    {
        private class QueueNode<T2>
        {
            public T2 Data { get; }
            public QueueNode<T2> Next { get; set; }
            
            public QueueNode(T2 data)
            {
                Data = data;
            }
        }

        private QueueNode<T> _head;
        private QueueNode<T> _tail;

        public bool IsEmpty()
        {
            return _head == null;
        }

        public T Peek()
        {
            if(_head == null) throw new NullReferenceException("Queue is empty");
            return _head.Data;
        }

        public void Add(T data)
        {
            var newNode = new QueueNode<T>(data);
            
            if (_head == null)
            {
                _head = newNode;
                _tail = _head;
                return;
            }

            _tail.Next = newNode;
            _tail = _tail.Next;
        }

        public T Remove()
        {
            var value = Peek();
            _head = _head.Next;
            
            if (_head == null)
                _tail = null;
            
            return value;
        }


    }
}