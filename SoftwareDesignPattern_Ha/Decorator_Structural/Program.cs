using System;

namespace Decorator.Structural
{
    /// <summary>
    /// Decorator Design Pattern
    /// </summary>

    public class Program
    {
        public static void Main(string[] args)
        {
            // Create ConcreteComponent and two Decorators

            ConcreteComponent c = new ConcreteComponent();
            ConcreteDecoratorA d1 = new ConcreteDecoratorA();
            ConcreteDecoratorB d2 = new ConcreteDecoratorB();

            // Link decorators

            d1.SetComponent(c);
            d2.SetComponent(d1);

            d1.Operation();
            //d2.Operation();
            //c.Operation();

            //Nếu d1.Operation(); thì chỉ hiên thị ra các ConcreteDecoratorA của A
            //d2.Operation() sẽ hiện thị thêm ConcreteDecoratorB => kết quả sẽ gồm: c, d1, d2

            // Wait for user

            //Lớp Component: Đây là lớp trừu tượng đại diện cho thành phần gốc hoặc thành phần cần được trang trí. Lớp này định nghĩa một phương thức trừu tượng Operation().

            //Lớp ConcreteComponent: Đây là lớp con của Component và đại diện cho thành phần gốc.Lớp này triển khai phương thức Operation() để thực hiện hành động của thành phần gốc.

            //Lớp Decorator: Đây là lớp trừu tượng đại diện cho trang trí.
            //Lớp này chứa một tham chiếu đến một đối tượng Component và triển khai phương thức Operation() bằng cách gọi phương thức Operation() của đối tượng Component.
            //Lớp này cho phép các lớp con cụ thể thêm hành vi bổ sung trước và sau khi gọi phương thức Operation().

            //Lớp ConcreteDecoratorA: Đây là lớp con của Decorator và đại diện cho trang trí cụ thể.
            //Lớp này triển khai phương thức Operation() bằng cách gọi phương thức Operation() của lớp cơ sở và sau đó thêm hành vi bổ sung.

            //Lớp ConcreteDecoratorB: Đây là lớp con của Decorator và đại diện cho trang trí cụ thể khác.
            //Lớp này triển khai phương thức Operation() bằng cách gọi phương thức Operation() của lớp cơ sở, thêm hành vi bổ sung và sau đó thực hiện hành động riêng của nó

            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Component' abstract class
    /// </summary>

    public abstract class Component
    {
        public abstract void Operation();
    }

    /// <summary>
    /// The 'ConcreteComponent' class
    /// </summary>

    public class ConcreteComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteComponent.Operation()");
        }
    }

    /// <summary>
    /// The 'Decorator' abstract class
    /// </summary>

    public abstract class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }

        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    /// <summary>
    /// The 'ConcreteDecoratorA' class
    /// </summary>

    public class ConcreteDecoratorA : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("ConcreteDecoratorA.Operation()");
        }
    }

    /// <summary>
    /// The 'ConcreteDecoratorB' class
    /// </summary>

    public class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
            Console.WriteLine("ConcreteDecoratorB.Operation()");
        }

        void AddedBehavior()
        {
        }
    }
}
