using System;

namespace Struct.HeapMinImpl
{
    //           parent = (index-2)/2
    //                  *
    //                /   \
    //           left       right
    //      index*2+1       index*2+2      
    public class MinIntHeap
    {
        private int capacity = 10;
        private int size = 0;

        int[] items;
        
        public MinIntHeap()
        {
            items = new int[capacity];
        }

        private int getLeftChildIndex(int parentindex) { return parentindex * 2 + 1; }
        private int getRightChildIndex(int parentindex) { return parentindex * 2 + 2; }
        private int getParentIndex(int childIndex) { return (childIndex - 1) / 2; }

        private bool hasLeftChild(int index) { return getLeftChildIndex(index) < size; }
        private bool hasRightChild(int index) { return getRightChildIndex(index) < size; }
        private bool hasParent(int index) { return getParentIndex(index) >= 0; }

        private int leftChild(int index) { return items[getLeftChildIndex(index)]; }
        private int rightChild(int index) { return items[getLeftChildIndex(index)]; }
        private int parent(int index) { return items[getParentIndex(index)]; }

        private void swap (int indexOne, int indexTwo)
        {
            int temp = items[indexOne];
            items[indexOne] = items[indexTwo];
            items[indexTwo] = temp;
        }

        private void ensureExtreCapacity()
        {
            if (size == capacity)
            {
                Array.Copy(items, items, capacity * 2);
                capacity *= 2;
            }
        }

        public int peek()
        {
            if (size == 0) throw new Exception("Heap doesn't contain elemants");  
            return items[0];       
        }

        public int poll()
        {
            if (size == 0) throw new Exception("Heap doesn't contain elemants");  
            int item = items[0];
            items[0] = items[size - 1];
            size--;
            heapifyDown();
            return item;
        }

        public void add(int item)
        {
            ensureExtreCapacity();
            items[size] = item;
            size++;
            heapifyUp();
        }

        private void heapifyUp()
        {
            int index = size - 1;

            while (hasParent(index) && parent(index) > items[index])
            {
                int pIndex = getParentIndex(index);
                swap(pIndex, index);
                index = pIndex;
            }
        }

        private void heapifyDown()
        {
            int index = 0;

            while (hasLeftChild(index))
            {
                int smallerIndex = getLeftChildIndex(index);

                if (hasRightChild(index) && leftChild(index) > rightChild(index))
                {
                    smallerIndex = getRightChildIndex(index);
                }

                if (items[index] < items[smallerIndex])
                {
                    break;
                }

                swap(index, smallerIndex);
                index = smallerIndex;
            }
        }
    }
}
