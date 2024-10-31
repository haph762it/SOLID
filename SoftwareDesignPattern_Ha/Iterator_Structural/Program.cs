using System;
using System.Collections.Generic;

namespace Iterator.Structural
{
    /// <summary>
    /// Iterator Design Pattern
    /// </summary>

    public class Program
    {
        public static void Main(string[] args)
        {
            ConcreteAggregate a = new ConcreteAggregate();
            a[0] = "Item A";
            a[1] = "Item B";
            a[2] = "Item C";
            a[3] = "Item D";
            Console.WriteLine(a[3]);


            // Create Iterator and provide aggregate

            Iterator i = a.CreateIterator();

            Console.WriteLine("Iterating over collection:");

            object item = i.First();

            while (item != null)
            {
                Console.WriteLine(item);
                item = i.Next();
                Console.WriteLine(i.CurrentItem());
            }

            // Wait for user

            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Aggregate' abstract class
    /// </summary>
    /// Lớp Aggregate: Đây là một lớp trừu tượng đại diện cho một tập hợp các đối tượng.
    /// Lớp này khai báo phương thức trừu tượng CreateIterator() để tạo ra một đối tượng Iterator phục vụ cho việc lặp qua các phần tử trong tập hợp.

    public abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
    }

    /// <summary>
    /// The 'ConcreteAggregate' class
    /// </summary>
    /// Lớp ConcreteAggregate: Đây là một lớp triển khai lớp Aggregate. Lớp này bao gồm một danh sách các đối tượng (items). 
    /// Lớp triển khai phương thức CreateIterator() để tạo một đối tượng ConcreteIterator với chính đối tượng ConcreteAggregate hiện tại. 
    /// Lớp cũng cung cấp thuộc tính Count để lấy số lượng phần tử trong danh sách và triển khai chỉ mục (this[int index]) để truy xuất và thay đổi các phần tử trong danh sách

    public class ConcreteAggregate : Aggregate
    {
        List<object> items = new List<object>();

        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        // Get item count

        public int Count
        {
            get { return items.Count; }
        }

        // Indexer

        public object this[int index]
        {
            get { return items[index]; }
            set { items.Insert(index, value); }
        }
    }

    /// <summary>
    /// The 'Iterator' abstract class
    /// </summary>
    /// Lớp Iterator: Đây là một lớp trừu tượng đại diện cho một đối tượng lặp qua các phần tử trong tập hợp. 
    /// Lớp này khai báo các phương thức trừu tượng First(), Next(), IsDone(), và CurrentItem() để thực hiện các hoạt động lặp qua các phần tử

    public abstract class Iterator
    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object CurrentItem();
    }

    /// <summary>
    /// The 'ConcreteIterator' class
    /// </summary>
    /// Lớp ConcreteIterator: Đây là một lớp triển khai lớp Iterator. 
    /// Lớp này chứa một đối tượng ConcreteAggregate và một biến current để theo dõi vị trí hiện tại trong danh sách. 
    /// Lớp triển khai phương thức First() để lấy phần tử đầu tiên trong danh sách, 
    /// Next() để lấy phần tử tiếp theo trong danh sách, CurrentItem() để lấy phần tử hiện tại, và IsDone() để kiểm tra xem việc lặp qua các phần tử đã hoàn thành hay chưa

    public class ConcreteIterator : Iterator
    {
        ConcreteAggregate aggregate;
        int current = 0;

        // Constructor

        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            this.aggregate = aggregate;
        }

        // Gets first iteration item

        public override object First()
        {
            return aggregate[0];
        }

        // Gets next iteration item

        public override object Next()
        {
            object ret = null;
            if (current < aggregate.Count - 1)
            {
                ret = aggregate[++current];
            }

            return ret;
        }

        // Gets current iteration item

        public override object CurrentItem()
        {
            return aggregate[current];
        }

        // Gets whether iterations are complete

        public override bool IsDone()
        {
            return current >= aggregate.Count;
        }
    }
}
