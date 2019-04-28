using System;
using System.Collections;

namespace Struct.ArrayList
{
    /// <summary>
    /// My attempt to implement ArrayList
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MysCustomArrayList<T>
    {
        private T[] elementData;

        public int Size { get; private set; }

        public int Capacity { get; private set; } = 10;

        public T this[int index]
        {
            get { return elementData[index];  }
            set { elementData[index] = value; }
        }

        public MysCustomArrayList()
        {
            elementData = new T[Capacity];
        }

        public MysCustomArrayList(int capacity)
        {
            Capacity = capacity;
            elementData = new T[capacity];
        }

        // O(1)
        public void Add(T value)
        {
            ensureCapacity();
            elementData[Size] = value;
            Size++;
        }

        // O(n)
        public void InsertAt(T value, int index)
        {
            ensureCapacity();
            Array.Copy(elementData, index, elementData, index + 1, Size - index);
            elementData[index] = value;
        }

        // O(n)
        public void Remove(int index)
        {
            Array.Copy(elementData, index + 1, elementData, index, Size - index);
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
            if ((Size + 1) >= Capacity)
            {
                Capacity *= 2;
                T[] tmpArray = new T[Capacity];
                Array.Copy(elementData, tmpArray, elementData.Length);
                elementData = tmpArray;
            }
        }
    }
}
