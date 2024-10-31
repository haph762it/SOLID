using System;

namespace Command.Structural
{
    /// <summary>
    /// Command Design Pattern
    /// </summary>

    public class Program
    {
        public static void Main(string[] args)
        {
            // Create receiver, command, and invoker

            Receiver receiver = new Receiver();
            Command command = new ConcreteCommand(receiver);
            Invoker invoker = new Invoker();

            // Set and execute command

            invoker.SetCommand(command);
            invoker.ExecuteCommand();

            // Wait for user

            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Command' abstract class
    /// </summary>
    //Lớp Command: Đây là một lớp trừu tượng đại diện cho một lệnh. Lớp này khai báo một tham chiếu đến đối tượng Receiver và triển khai phương thức trừu tượng Execute().
    public abstract class Command
    {
        protected Receiver receiver;

        // Constructor

        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public abstract void Execute();
    }

    /// <summary>
    /// The 'ConcreteCommand' class
    /// </summary>
    //Lớp ConcreteCommand: Đây là một lớp triển khai lớp Command. Lớp này triển khai phương thức Execute() bằng cách gọi phương thức Action() trên đối tượng Receiver
    public class ConcreteCommand : Command
    {
        // Constructor

        public ConcreteCommand(Receiver receiver) :
            base(receiver)
        {
        }

        public override void Execute()
        {
            receiver.Action();
        }
    }

    /// <summary>
    /// The 'Receiver' class
    /// </summary>
    /// //Lớp Receiver: Đây là lớp đại diện cho người nhận lệnh. Lớp này triển khai phương thức Action() để thực hiện hành động cụ thể

    public class Receiver
    {
        public void Action()
        {
            Console.WriteLine("Called Receiver.Action()");
        }
    }

    /// <summary>
    /// The 'Invoker' class
    /// </summary>
    //Lớp Invoker: Đây là lớp gọi lệnh, nơi lưu trữ một tham chiếu đến một đối tượng Command. Lớp này cung cấp các phương thức để thiết lập lệnh và thực thi lệnh
    public class Invoker
    {
        Command command;

        public void SetCommand(Command command)
        {
            this.command = command;
        }

        public void ExecuteCommand()
        {
            command.Execute();
        }
    }
}
