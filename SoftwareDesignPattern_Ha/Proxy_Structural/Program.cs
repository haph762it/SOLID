using System;

namespace Proxy.Structural
{
    /// <summary>
    /// Proxy Design Pattern
    /// </summary>

    public class Program
    {
        public static void Main(string[] args)
        {
            // Create proxy and request a service

            RealSubject proxy = new RealSubject();
            proxy.Request();

            // Wait for user

            //Lớp Subject: Đây là một lớp trừu tượng đại diện cho chủ thể.Lớp này khai báo phương thức trừu tượng Request().

            //Lớp RealSubject: Đây là một lớp thực thể, triển khai lớp Subject.Lớp này triển khai phương thức Request() để thực hiện các công việc thực tế.

            //Lớp Proxy: Đây là lớp proxy, triển khai lớp Subject.Lớp này giữ một tham chiếu đến đối tượng RealSubject và triển khai phương thức Request().
            //Trong phương thức Request(), lớp Proxy sử dụng "lazy initialization"(khởi tạo lười) để chỉ khởi tạo đối tượng RealSubject khi cần thiết.
            //Sau đó, nó chuyển tiếp yêu cầu cho đối tượng RealSubject để thực hiện công việc thực tế.

            //Lớp Proxy này có thể thêm các dk kiểm tra trước khi thực hiện RealSubject

            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Subject' abstract class
    /// </summary>

    public abstract class Subject
    {
        public abstract void Request();
    }

    /// <summary>
    /// The 'RealSubject' class
    /// </summary>

    public class RealSubject : Subject
    {
        public override void Request()
        {
            Console.WriteLine("Called RealSubject.Request()");
        }
    }

    /// <summary>
    /// The 'Proxy' class
    /// </summary>

    public class Proxy : Subject
    {
        private RealSubject realSubject;

        public override void Request()
        {
            // Use 'lazy initialization'

            if (realSubject == null)
            {
                realSubject = new RealSubject();
            }

            realSubject.Request();
        }
    }
}

