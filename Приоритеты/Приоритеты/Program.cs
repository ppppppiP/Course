using System;
using System.Collections.Generic;
using Приоритеты;

class Program
{
    static void Main(string[] args)
    {
        // Создание очереди с приоритетами
        {
            // Создание очереди с приоритетами для целых чисел в порядке убывания
            PriorityQueue<int> queue = new PriorityQueue<int>(Comparer<int>.Default);

            // Добавление элементов в очередь
            queue.Enqueue(5);
            queue.Enqueue(2);
            queue.Enqueue(7);
            queue.Enqueue(1);

            // Извлечение элементов из очереди
            while (queue.Count > 0)
            {
                int item = queue.Dequeue();
                Console.WriteLine(item);
            }
        }
    }
}

