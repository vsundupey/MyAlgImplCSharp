using System;

namespace LinkedList.SinglyImpl
{
    /// <summary>
    /// Singly linked list simple implementation (not thread safe)
    /// </summary>
    /// <typeparam name="T">Value object</typeparam>
    public class SinglyLinkedList<T>
    {
        private Node<T> _head;
        private Node<T> _current;
        private Node<T> _tail;

        private int _count = 0;
        private int _currentIndex = 0;

        public T First => _head.Data;
        public T Current => _current.Data;
        public T Last => _tail.Data;

        public int Count => _count;
        public int CurrentIndex => _currentIndex;

        /// <summary>
        /// Add new node to end of list, Time O(1)
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            if (_head == null)
                InternalAddFirst(item);
            else
                InternalAppend(item);
        }

        /// <summary>
        /// Add new node as first, Time O(1)
        /// </summary>
        /// <param name="item"></param>
        public void AddFront(T item)
        {
            if (_head == null)
                InternalAddFirst(item);
            else
            {
                var tmp = new Node<T>(item, null) {Next = _head};
                _head = tmp;
                _count++;
            }
        }

        /// <summary>
        /// In linkedlist insert operation is O(1)
        /// but in current case we have 2 step - search and insert - O(n)
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void Insert(int index, T item)
        {
            if (index < 0 || index > _count - 1) throw new IndexOutOfRangeException();

            SetCurrent(index);

            var tmp = new Node<T>(item, null) {Next = _current};
            _current = tmp;
            _count++;
        }
        
        // Time O(n)
        public void Remove()
        {
            if(_tail == null) 
                return;
            
            RemoveAt(_count - 1);              
        }

        // Time O(n)
        public void RemoveAt(int index)
        {
            if (index < 0 || index > _count) throw new IndexOutOfRangeException();

            _count--;
            
            if (index == 0)
            {
                _head = _head.Next;
                return;
            }

            SetCurrent(index - 1);
            _current.Next = _current.Next.Next;
        }

        // Time O(n)
        public void SetCurrent(int index)
        {
            if(index == _currentIndex) return;
            
            int i = index;

            if (index < _currentIndex)
            {
                _current = _head;
                i = 0;
            }

            if (index == 0) return;

            if (index == Count)
            {
                _current = _tail;
                return;
            }

            while (i != index)
            {
                _current = _current.Next;
                i++;
            }
        }

        /// <summary>
        /// Add first node to empty list
        /// </summary>
        /// <param name="item"></param>
        private void InternalAddFirst(T item)
        {
            _head = new Node<T>(item, null);
            _tail = _head;
            _current = _tail;
            _count++;
        }

        /// <summary>
        /// Add new node to end of list
        /// </summary>
        /// <param name="item"></param>
        private void InternalAppend(T item)
        {
            _tail.Next = new Node<T>(item, null);
            _tail = _tail.Next;
            _count++;
        }

        public void PrintList()
        {
            if (_head == null) return;

            var tmp = _head;

            do
            {
                tmp.Print();
                tmp = tmp.Next;
            } while (tmp != null);
        }

        private class Node<T2>
        {
            public T2 Data;
            public Node<T2> Next;

            public Node()
            {
            }

            public Node(T2 data, Node<T2> next)
            {
                Data = data;
                Next = next;
            }

            public void Print()
            {
                Console.WriteLine(Data);
            }
        }
    }
}