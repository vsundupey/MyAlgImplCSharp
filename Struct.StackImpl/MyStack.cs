using System;

namespace Struct.StackImpl
{
    public class MyStack<T>
    {
        private class StackNode<T2>
        {
            public T2 Data { get; }
            public StackNode<T2> Next { get; set; }

            public StackNode(T2 data)
            {
                Data = data;
            }
        }

        private StackNode<T> _top;

        /// <summary>
        /// Check for empty
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return _top == null;
        }

        /// <summary>
        /// Returns top element data
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NullReferenceException">If stack is empty</exception>
        public T Peek()
        {
            if(_top == null) 
                throw new NullReferenceException("Stack is empty");
            
            return _top.Data;
        }
        
        public void Push(T data)
        {
            var node = new StackNode<T>(data);

            if (_top == null)
            {
                _top = node; return;
            }

            node.Next = _top;
            _top = node;
        }

        public T Pop()
        {
            var data = Peek();
            _top = _top.Next;            
            return data;
        }
    }
}