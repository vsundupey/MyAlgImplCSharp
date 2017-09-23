using System;

namespace LinkedList.SinglyImpl
{
    /// <summary>
    /// Singly linked list simple implementation
    /// 
    /// 
    /// 
    /// 
    /// 
    /// </summary>
    /// <typeparam name="T">Value object</typeparam>
    public class SinglyLinkedList<T>
    {
        private Node<T> _head;
        private Node<T> _current;
        private Node<T> _last;

        private int _count = 0;
        private int _currentIndex = 0;

        public int Count => _count;
        public int CurrentIndex => _currentIndex;

        /// <summary>
        /// Add new node to end of list
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
        /// Add new node as first
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

        public void Insert(int index, T item)
        {
            if (index < 0 || index > _count) throw new IndexOutOfRangeException();

            SetCurrent(index);

            var tmp = new Node<T>(item, null) {Next = _current};
            _current = tmp;
            _count++;
        }

        public void Remove(int index)
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

        private void SetCurrent(int index)
        {
            _current = _head;

            if (index == 0) return;

            if (index == Count)
            {
                _current = _last;
                return;
            }

            int i = 0;

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
            _last = _head;
            _count++;
        }

        /// <summary>
        /// Add new node to end of list
        /// </summary>
        /// <param name="item"></param>
        private void InternalAppend(T item)
        {
            _last.Next = new Node<T>(item, null);
            _last = _last.Next;
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

        public class Node<T2>
        {
            private T2 _data;
            public Node<T2> Next;

            public Node()
            {
            }

            public Node(T2 data, Node<T2> next)
            {
                _data = data;
                Next = next;
            }

            public void Print()
            {
                Console.WriteLine(_data);
            }
        }
    }
}