
using System;

class HeapSort
{
    public static void Heapify(int[] arr, int n, int i)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && arr[left] > arr[largest])
            largest = left;

        if (right < n && arr[right] > arr[largest])
            largest = right;

        if (largest != i)
        {
            int swap = arr[i];
            arr[i] = arr[largest];
            arr[largest] = swap;

            Heapify(arr, n, largest);
        }
    }

    public static void HeapSortFunc(int[] arr)
    {
        int n = arr.Length;

        // Построение max-heap
        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(arr, n, i);

        // Извлечение элементов из кучи (пирамиды) по одному
        for (int i = n - 1; i >= 0; i--)
        {
            // Перемещаем текущий корень в конец массива
            int temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;

            // Вызываем процедуру Heapify на уменьшенной куче
            Heapify(arr, i, 0);
        }
    }

    public static void Main(string[] args)
    {
        int[] arr = { 12, 11, 13, 5, 6, 7 };

        Console.WriteLine("Исходный массив:");
        PrintArray(arr);

        HeapSortFunc(arr);

        Console.WriteLine("Отсортированный массив:");
        PrintArray(arr);
    }

    public static void PrintArray(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n; ++i)
            Console.Write(arr[i] + " ");
        Console.WriteLine();
    }
}