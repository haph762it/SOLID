﻿using System;
using System.Collections.Generic;

namespace Iterator.RealWorld
{
    /// <summary>
    /// Iterator Design Pattern
    /// </summary>

    public class Program
    {
        public static void Main(string[] args)
        {
            // Build a collection

            Collection collection = new Collection();
            collection[0] = new Item("Item 0");
            collection[1] = new Item("Item 1");
            collection[2] = new Item("Item 2");
            collection[3] = new Item("Item 3");
            collection[4] = new Item("Item 4");
            collection[5] = new Item("Item 5");
            collection[6] = new Item("Item 6");
            collection[7] = new Item("Item 7");
            collection[8] = new Item("Item 8");

            // Create iterator

            Iterator iterator = collection.CreateIterator();

            // Skip every other item

            iterator.Step = 3;

            Console.WriteLine("Iterating over collection:");

            for (Item item = iterator.First();
                !iterator.IsDone; item = iterator.Next())
            {
                Console.WriteLine(item.Name);
            }

            // Wait for user

            Console.ReadKey();
        }
    }
    /// <summary>
    /// A collection item
    /// </summary>
    /// Lớp Item: Đây là một lớp đại diện cho một phần tử trong tập hợp. Lớp này có một thuộc tính Name để lấy tên của phần tử.

    public class Item
    {
        string name;

        // Constructor

        public Item(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }
    }

    /// <summary>
    /// The 'Aggregate' interface
    /// </summary>
    /// Giao diện IAbstractCollection: Đây là giao diện đại diện cho một tập hợp. 
    /// Giao diện này khai báo phương thức CreateIterator() để tạo ra một đối tượng Iterator phục vụ cho việc lặp qua các phần tử trong tập hợp

    public interface IAbstractCollection
    {
        Iterator CreateIterator();
    }

    /// <summary>
    /// The 'ConcreteAggregate' class
    /// </summary>
    /// Lớp Collection: Đây là một lớp triển khai giao diện IAbstractCollection. 
    /// Lớp này bao gồm một danh sách các đối tượng Item. Lớp triển khai phương thức CreateIterator() để tạo một đối tượng Iterator với chính đối tượng Collection hiện tại. 
    /// Lớp cũng cung cấp thuộc tính Count để lấy số lượng phần tử trong danh sách và triển khai chỉ mục (this[int index]) để truy xuất và thêm các phần tử vào danh sách

    public class Collection : IAbstractCollection
    {
        List<Item> items = new List<Item>();

        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }

        // Gets item count

        public int Count
        {
            get { return items.Count; }
        }

        // Indexer

        public Item this[int index]
        {
            get { return items[index]; }
            set { items.Add(value); }
        }
    }

    /// <summary>
    /// The 'Iterator' interface
    /// </summary>
    /// Giao diện IAbstractIterator: Đây là giao diện đại diện cho một đối tượng lặp qua các phần tử trong tập hợp. 
    /// Giao diện này khai báo các phương thức First(), Next(), thuộc tính IsDone và CurrentItem để thực hiện các hoạt động lặp qua các phần tử

    public interface IAbstractIterator
    {
        Item First();
        Item Next();
        bool IsDone { get; }
        Item CurrentItem { get; }
    }

    /// <summary>
    /// The 'ConcreteIterator' class
    /// </summary>
    /// Lớp Iterator: Đây là một lớp triển khai giao diện IAbstractIterator. 
    /// Lớp này chứa một đối tượng Collection, một biến current để theo dõi vị trí hiện tại trong danh sách, và một biến step để xác định số bước nhảy trong quá trình lặp. 
    /// Lớp triển khai phương thức First() để lấy phần tử đầu tiên trong danh sách, Next() để lấy phần tử tiếp theo trong danh sách, 
    /// CurrentItem để lấy phần tử hiện tại, và IsDone để kiểm tra xem việc lặp qua các phần tử đã hoàn thành hay chưa. 
    /// Lớp cũng cung cấp thuộc tính Step để lấy hoặc thiết lập bước nhảy của iterator

    public class Iterator : IAbstractIterator
    {
        Collection collection;
        int current = 0;
        int step = 1;

        // Constructor

        public Iterator(Collection collection)
        {
            this.collection = collection;
        }

        // Gets first item

        public Item First()
        {
            current = 0;
            return collection[current] as Item;
        }

        // Gets next item

        public Item Next()
        {
            current += step;
            if (!IsDone)
                return collection[current] as Item;
            else
                return null;
        }

        // Gets or sets stepsize

        public int Step
        {
            get { return step; }
            set { step = value; }
        }

        // Gets current iterator item

        public Item CurrentItem
        {
            get { return collection[current] as Item; }
        }

        // Gets whether iteration is complete

        public bool IsDone
        {
            get { return current >= collection.Count; }
        }
    }
}
