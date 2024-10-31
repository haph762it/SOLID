using System;
using System.Collections.Generic;

namespace Strategy.RealWorld
{
    /// <summary>
    /// Strategy Design Pattern
    /// </summary>

    public class Program
    {
        public static void Main(string[] args)
        {
            // Two contexts following different strategies

            SortedList studentRecords = new SortedList();

            studentRecords.Add("Samual");
            studentRecords.Add("Jimmy");
            studentRecords.Add("Sandra");
            studentRecords.Add("Vivek");
            studentRecords.Add("Anna");

            //studentRecords.SetSortStrategy(new QuickSort());
            //studentRecords.Sort();

            studentRecords.SetSortStrategy(new ShellSort());
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new MergeSort());
            studentRecords.Sort();

            // Wait for user

            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Strategy' abstract class
    /// </summary>
    /// Lớp này khai báo phương thức trừu tượng Sort() để định nghĩa cách thức sắp xếp danh sách

    public abstract class SortStrategy
    {
        public abstract void Sort(List<string> list);
    }

    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    /// Lớp QuickSort, ShellSort và MergeSort: Đây là các lớp triển khai của lớp SortStrategy. 
    /// Mỗi lớp đại diện cho một chiến lược sắp xếp cụ thể và triển khai phương thức Sort() để thực hiện sắp xếp danh sách theo cách tương ứng

    public class QuickSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            list.Sort();  // Default is Quicksort
            Console.WriteLine("QuickSorted list ");
        }
    }

    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>

    public class ShellSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            //list.ShellSort();  not-implemented
            Console.WriteLine("ShellSorted list ");
        }
    }

    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>

    public class MergeSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            //list.MergeSort(); not-implemented

            Console.WriteLine("MergeSorted list ");
        }
    }

    /// <summary>
    /// The 'Context' class
    /// </summary>
    /// Lớp SortedList: Đây là lớp chứa danh sách sinh viên và một đối tượng chiến lược sắp xếp. 
    /// Lớp này triển khai phương thức SetSortStrategy() để thiết lập chiến lược sắp xếp, 
    /// phương thức Add() để thêm sinh viên vào danh sách và phương thức Sort() để thực hiện sắp xếp danh sách bằng chiến lược hiện tại. 
    /// Khi sắp xếp xong, danh sách sinh viên được in ra màn hình

    public class SortedList
    {
        private List<string> list = new List<string>();
        private SortStrategy sortstrategy;

        public void SetSortStrategy(SortStrategy sortstrategy)
        {
            this.sortstrategy = sortstrategy;
        }

        public void Add(string name)
        {
            list.Add(name);
        }

        public void Sort()
        {
            sortstrategy.Sort(list);

            // Iterate over list and display results

            foreach (string name in list)
            {
                Console.WriteLine(" " + name);
            }
            Console.WriteLine();
        }
    }
}
