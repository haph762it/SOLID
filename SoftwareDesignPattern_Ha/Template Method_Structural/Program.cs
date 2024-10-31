using System;

namespace Template.Structural
{
    /// <summary>
    /// Template Design Pattern
    /// </summary>

    public class Program
    {
        public static void Main(string[] args)
        {
            AbstractClass aA = new ConcreteClassA();
            aA.TemplateMethod();

            AbstractClass aB = new ConcreteClassB();
            aB.TemplateMethod();

            // Wait for user
            //Mẫu thiết kế Template cho phép chúng ta xác định một cấu trúc mẫu chung và để các lớp con cụ thể triển khai các phương thức cụ thể bên trong cấu trúc đó.
            //Phương thức template TemplateMethod() trong lớp AbstractClass quyết định thứ tự và cách thức gọi các phương thức cụ thể.
            //Khi chúng ta tạo các đối tượng ConcreteClassA và ConcreteClassB và gọi phương thức TemplateMethod(),
            //các phương thức con cụ thể sẽ được thực hiện theo thứ tự đã xác định trong lớp trừu tượng, và kết quả được in ra màn hình

            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'AbstractClass' abstract class
    /// </summary>
    /// Lớp AbstractClass: Đây là lớp trừu tượng đại diện cho một lớp có cấu trúc mẫu. 
    /// Lớp này khai báo các phương thức trừu tượng PrimitiveOperation1() và PrimitiveOperation2() để định nghĩa các hành động cụ thể. 
    /// Lớp AbstractClass cũng triển khai phương thức TemplateMethod() để tổ chức và điều chỉnh thứ tự thực hiện các phương thức con

    public abstract class AbstractClass
    {
        public abstract void PrimitiveOperation1();
        public abstract void PrimitiveOperation2();

        // The "Template method"

        public void TemplateMethod()
        {
            PrimitiveOperation1();
            PrimitiveOperation2();
            Console.WriteLine("");
        }
    }

    /// <summary>
    /// A 'ConcreteClass' class
    /// </summary>
    /// Lớp ConcreteClassA và ConcreteClassB: Đây là các lớp triển khai của lớp AbstractClass. 
    /// Mỗi lớp đại diện cho một lớp cụ thể có các phương thức con cụ thể. 
    /// Cả hai lớp này triển khai phương thức PrimitiveOperation1() và PrimitiveOperation2() để định nghĩa các hành động cụ thể

    public class ConcreteClassA : AbstractClass
    {
        public override void PrimitiveOperation1()
        {
            Console.WriteLine("ConcreteClassA.PrimitiveOperation1()");
        }

        public override void PrimitiveOperation2()
        {
            Console.WriteLine("ConcreteClassA.PrimitiveOperation2()");
        }
    }

    /// <summary>
    /// A 'ConcreteClass' class
    /// </summary>

    public class ConcreteClassB : AbstractClass
    {
        public override void PrimitiveOperation1()
        {
            Console.WriteLine("ConcreteClassB.PrimitiveOperation1()");
        }

        public override void PrimitiveOperation2()
        {
            Console.WriteLine("ConcreteClassB.PrimitiveOperation2()");
        }
    }
}
