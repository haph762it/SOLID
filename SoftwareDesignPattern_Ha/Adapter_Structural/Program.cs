using System;

namespace Adapter.Structural
{
    /// <summary>
    /// Adapter Design Pattern
    /// </summary>

    public class Program
    {
        public static void Main(string[] args)
        {
            // Create adapter and place a request

            Target target = new Adapter();
            target.Request();

            // Wait for user

            Console.ReadKey();

            //Lớp Target: Đây là lớp mục tiêu, đại diện cho giao diện mà Client mong muốn sử dụng.Lớp này có một phương thức Request() mô phỏng một yêu cầu từ Client.

            //Lớp Adapter: Đây là lớp chuyển đổi, kế thừa từ lớp Target và chứa một đối tượng Adaptee.Lớp này ghi đè phương thức Request() của lớp Target và gọi phương thức SpecificRequest() của Adaptee. Bằng cách này, Adapter chuyển đổi yêu cầu từ Target sang Adaptee.

            //Lớp Adaptee: Đây là lớp cần được chuyển đổi hoặc sửa đổi để phù hợp với giao diện của Target. Lớp này có một phương thức SpecificRequest() đại diện cho hành động cụ thể của Adaptee.
        }

    }
    /// <summary>
    /// The 'Target' class
    /// </summary>

    public class Target
    {
        public virtual void Request()
        {
            Console.WriteLine("Called Target Request()");
        }
    }

    /// <summary>
    /// The 'Adapter' class
    /// </summary>

    public class Adapter : Target
    {
        private Adaptee adaptee = new Adaptee();

        public override void Request()
        {
            // Possibly do some other work
            // and then call SpecificRequest

            adaptee.SpecificRequest();
        }
    }

    /// <summary>
    /// The 'Adaptee' class
    /// </summary>

    public class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Called SpecificRequest()");
        }
    }
}
