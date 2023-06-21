using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Приоритеты
{
    public class PriorityQueue<T>
    {
        private List<T> heap;
        private IComparer<T> comparer;

        public int Count { get { return heap.Count; } }

        public PriorityQueue()
        {
            heap = new List<T>();
            comparer = Comparer<T>.Default;
        }

        public PriorityQueue(IComparer<T> comparer)
        {
            heap = new List<T>();
            this.comparer = comparer;
        }

        public void Enqueue(T item)
        {
            heap.Add(item);
            int currentIndex = heap.Count - 1;
            while (currentIndex > 0)
            {
                int parentIndex = (currentIndex - 1) / 2;
                if (comparer.Compare(heap[currentIndex], heap[parentIndex]) >= 0)
                    break;
                Swap(currentIndex, parentIndex);
                currentIndex = parentIndex;
            }
        }

        public T Dequeue()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Queue is empty.");

            int lastIndex = heap.Count - 1;
            T frontItem = heap[0];
            heap[0] = heap[lastIndex];
            heap.RemoveAt(lastIndex);
            lastIndex--;

            int currentIndex = 0;
            while (true)
            {
                int leftChildIndex = 2 * currentIndex + 1;
                int rightChildIndex = 2 * currentIndex + 2;

                if (leftChildIndex > lastIndex)
                    break;

                int minChildIndex = leftChildIndex;
                if (rightChildIndex <= lastIndex && comparer.Compare(heap[rightChildIndex], heap[leftChildIndex]) < 0)
                    minChildIndex = rightChildIndex;

                if (comparer.Compare(heap[currentIndex], heap[minChildIndex]) <= 0)
                    break;

                Swap(currentIndex, minChildIndex);
                currentIndex = minChildIndex;
            }

            return frontItem;
        }

        public T Peek()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Queue is empty.");

            return heap[0];
        }

        private void Swap(int i, int j)
        {
            T temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
    }
}