using System;
using System.Collections;

namespace Struct.ArrayList
{
    /// <summary>
    /// My attempt to implement ArrayList
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MysCustomArrayList<T> where T : IList
    {
        private T[] elementData = new T[10];

        public int Size { get; private set; }

        public int Capacity
        {
            get { return elementData.Length; }
        }

        public T this[int index]
        {
            get { return elementData[index];  }
            set { elementData[index] = value; }
        }

        public MysCustomArrayList()
        {

        }

        public MysCustomArrayList(int capacity)
        {
            T[] elementData = new T[capacity];
        }

        // O(1)
        public void Add(T value)
        {
            ensureCapacity();
            elementData[Size++] = value;
        }

        // O(n)
        public void InsertAt(T value, int index)
        {
            ensureCapacity();
            Array.Copy(elementData, index, elementData, index + 1, elementData.Length - index);
            elementData[index] = value;
        }

        // O(n)
        public void Remove(int index)
        {
            Array.Copy(elementData, index + 1, elementData, index, elementData.Length - index);
            Size--;
        }

        // O(n)
        public void Remove(T value)
        {
            for (int i = 0; i < elementData.Length; i++)
            {
                if (elementData[i].Equals(value))
                {
                    Remove(i);
                    break;
                }
            }
        }

        // O(n)
        private void ensureCapacity()
        {
            if ((Size++) > elementData.Length)
            {
                T[] tmpArray = new T[elementData.Length * 2];
                Array.Copy(elementData, tmpArray, elementData.Length);
            }
        }
    }
}
