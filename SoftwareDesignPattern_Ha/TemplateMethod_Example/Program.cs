using System;
using System.Collections.Generic;

namespace Template.RealWorld
{
    /// <summary>
    /// Template Design Pattern
    /// </summary>

    public class Program
    {
        public static void Main(string[] args)
        {
            DataAccessor categories = new Categories();
            categories.Run(5);

            DataAccessor products = new Products();
            products.Run(3);

            // Wait for user
            //Mẫu thiết kế Template cho phép chúng ta xác định một cấu trúc mẫu chung và để các lớp con cụ thể triển khai các phương thức cụ thể bên trong cấu trúc đó.
            //Phương thức template Run() trong lớp DataAccessor quyết định thứ tự và cách thức gọi các phương thức liên quan đến truy xuất dữ liệu.
            //Khi chúng ta tạo các đối tượng Categories và Products và gọi phương thức Run(),
            //các phương thức con cụ thể sẽ được thực hiện theo thứ tự đã xác định trong lớp trừu tượng, và kết quả được in ra màn hình

            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'AbstractClass' abstract class
    /// </summary>

    public abstract class DataAccessor
    {
        public abstract void Connect();
        public abstract void Select();
        public abstract void Process(int top);
        public abstract void Disconnect();

        // The 'Template Method' 

        public void Run(int top)
        {
            Connect();
            Select();
            Process(top);
            Disconnect();
        }
    }

    /// <summary>
    /// A 'ConcreteClass' class
    /// </summary>
    /// <remarks>
    /// Lớp Categories và Products: Đây là các lớp triển khai của lớp DataAccessor. 
    /// Mỗi lớp đại diện cho một nguồn dữ liệu cụ thể (danh mục và sản phẩm) và triển khai các phương thức con cụ thể để truy xuất dữ liệu từ nguồn đó. 
    /// Các phương thức Connect(), Select(), Process() và Disconnect() được triển khai để thực hiện các hành động cụ thể liên quan đến truy xuất dữ liệu từ mỗi nguồn
    /// </remarks>

    public class Categories : DataAccessor
    {
        private List<string> categories;

        public override void Connect()
        {
            categories = new List<string>();
        }

        public override void Select()
        {
            categories.Add("Red");
            categories.Add("Green");
            categories.Add("Blue");
            categories.Add("Yellow");
            categories.Add("Purple");
            categories.Add("White");
            categories.Add("Black");
        }

        public override void Process(int top)
        {
            Console.WriteLine("Categories ---- ");

            for (int i = 0; i < top; i++)
            {
                Console.WriteLine(categories[i]);
            }

            Console.WriteLine();
        }

        public override void Disconnect()
        {
            categories.Clear();
        }
    }

    /// <summary>
    /// A 'ConcreteClass' class
    /// </summary>

    public class Products : DataAccessor
    {
        private List<string> products;

        public override void Connect()
        {
            products = new List<string>();
        }

        public override void Select()
        {
            products.Add("Car");
            products.Add("Bike");
            products.Add("Boat");
            products.Add("Truck");
            products.Add("Moped");
            products.Add("Rollerskate");
            products.Add("Stroller");
        }

        public override void Process(int top)
        {
            Console.WriteLine("Products ---- ");

            for (int i = 0; i < top; i++)
            {
                Console.WriteLine(products[i]);
            }

            Console.WriteLine();
        }

        public override void Disconnect()
        {
            products.Clear();
        }
    }
}
