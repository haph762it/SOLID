using System;

namespace State.Structural
{
    /// <summary>
    /// State Design Pattern
    /// </summary>

    public class Program
    {
        public static void Main(string[] args)
        {
            // Setup context in a state

            var context = new Context(new ConcreteStateA());

            // Issue requests, which toggles state

            context.Request();
            context.Request();
            context.Request();
            context.Request();

            // Wait for user

            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'State' abstract class
    /// </summary>
    /// Lớp State: Đây là lớp trừu tượng đại diện cho trạng thái. Lớp này chứa phương thức trừu tượng Handle(), mà các lớp con sẽ triển khai để xử lý yêu cầu trong trạng thái tương ứng

    public abstract class State
    {
        public abstract void Handle(Context context);
    }

    /// <summary>
    /// A 'ConcreteState' class
    /// </summary>

    public class ConcreteStateA : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreteStateB();
        }
    }

    /// <summary>
    /// A 'ConcreteState' class
    /// </summary>
    /// Lớp ConcreteStateA và ConcreteStateB: Đây là các lớp triển khai của lớp State. 
    /// Mỗi lớp đại diện cho một trạng thái cụ thể và triển khai phương thức Handle() để xác định hành động tương ứng khi xử lý yêu cầu. 
    /// Trong ví dụ này, khi xử lý yêu cầu, ConcreteStateA chuyển đổi trạng thái sang ConcreteStateB và ConcreteStateB chuyển đổi trạng thái sang ConcreteStateA

    public class ConcreteStateB : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreteStateA();
        }
    }

    /// <summary>
    /// The 'Context' class
    /// </summary>
    /// Lớp Context: Đây là lớp chứa thông tin liên quan đến trạng thái và triển khai phương thức Request() để gửi yêu cầu. 
    /// Lớp này có một thuộc tính State để lưu trữ trạng thái hiện tại và triển khai phương thức Handle() để chuyển đổi trạng thái và hiển thị trạng thái mới

    public class Context
    {
        State state;

        // Constructor

        public Context(State state)
        {
            this.State = state;
        }

        // Gets or sets the state

        public State State
        {
            get { return state; }
            set
            {
                state = value;
                Console.WriteLine("State: " + state.GetType().Name);
            }
        }

        public void Request()
        {
            state.Handle(this);
        }
    }
}
