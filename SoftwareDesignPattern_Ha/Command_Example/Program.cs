using System;
using System.Collections.Generic;

namespace Command.RealWorld
{
    /// <summary>
    /// Command Design Pattern
    /// </summary>

    public class Program
    {
        public static void Main(string[] args)
        {
            // Create user and let her compute

            User user = new User();

            // User presses calculator buttons

            user.Compute('+', 100);
            user.Compute('-', 50);
            user.Compute('*', 10);
            user.Compute('/', 2);

            // Undo 4 commands

            user.Undo(15);

            // Redo 3 commands

            user.Redo(3);

            // Wait for user

            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Command' abstract class
    /// </summary>
    //Lớp Command: Đây là một lớp trừu tượng đại diện cho một lệnh. Lớp này khai báo các phương thức trừu tượng Execute() và UnExecute() để thực hiện lệnh và hoàn tác lệnh
    public abstract class Command
    {
        public abstract void Execute();
        public abstract void UnExecute();
    }

    /// <summary>
    /// The 'ConcreteCommand' class
    /// </summary>
    //Lớp CalculatorCommand: Đây là một lớp triển khai lớp Command. Lớp này chứa thông tin về toán tử (@operator) và toán hạng (operand) của một phép tính.
    //Lớp này triển khai phương thức Execute() để thực hiện phép tính bằng cách gọi phương thức Operation() trên đối tượng Calculator.
    //Lớp cũng triển khai phương thức UnExecute() để hoàn tác phép tính bằng cách gọi lại phương thức Operation() với toán tử đảo ngược
    public class CalculatorCommand : Command
    {
        char @operator;
        int operand;
        Calculator calculator;

        // Constructor

        public CalculatorCommand(Calculator calculator,
            char @operator, int operand)
        {
            this.calculator = calculator;
            this.@operator = @operator;
            this.operand = operand;
        }

        // Gets operator

        public char Operator
        {
            set { @operator = value; }
        }

        // Get operand

        public int Operand
        {
            set { operand = value; }
        }

        // Execute new command

        public override void Execute()
        {
            calculator.Operation(@operator, operand);
        }

        // Unexecute last command

        public override void UnExecute()
        {
            calculator.Operation(Undo(@operator), operand);
        }

        // Returns opposite operator for given operator

        private char Undo(char @operator)
        {
            switch (@operator)
            {
                case '+': return '-';
                case '-': return '+';
                case '*': return '/';
                case '/': return '*';
                default:
                    throw new
             ArgumentException("@operator");
            }
        }
    }

    /// <summary>
    /// The 'Receiver' class
    /// </summary>
    /// Lớp Calculator: Đây là lớp đại diện cho máy tính. 
    /// Lớp này có một biến curr để lưu trữ giá trị hiện tại. Lớp triển khai phương thức Operation() để thực hiện phép tính dựa trên toán tử và toán hạng được cung cấp

    public class Calculator
    {
        int curr = 0;

        public void Operation(char @operator, int operand)
        {
            switch (@operator)
            {
                case '+': curr += operand; break;
                case '-': curr -= operand; break;
                case '*': curr *= operand; break;
                case '/': curr /= operand; break;
            }
            Console.WriteLine(
                "Current value = {0,3} (following {1} {2})",
                curr, @operator, operand);
        }
    }
    
    /// <summary>
    /// The 'Invoker' class
    /// </summary>
    /// Lớp User: Đây là lớp gọi lệnh, nơi người dùng tương tác với máy tính. 
    /// Lớp này chứa một đối tượng Calculator, một danh sách các lệnh (commands), và một biến current để theo dõi vị trí hiện tại trong danh sách lệnh. 
    /// Lớp cung cấp các phương thức để thực hiện phép tính (Compute), hoàn tác (Undo), và làm lại (Redo)

    public class User
    {
        // Initializers

        Calculator calculator = new Calculator();
        List<Command> commands = new List<Command>();
        int current = 0;

        public void Redo(int levels)
        {
            Console.WriteLine("\n---- Redo {0} levels ", levels);
            // Perform redo operations
            for (int i = 0; i < levels; i++)
            {
                if (current < commands.Count - 1)
                {
                    Command command = commands[current++];
                    command.Execute();
                }
            }
        }

        public void Undo(int levels)
        {
            Console.WriteLine("\n---- Undo {0} levels ", levels);

            // Perform undo operations

            for (int i = 0; i < levels; i++)
            {
                if (current > 0)
                {
                    Command command = commands[--current] as Command;
                    command.UnExecute();
                }
            }
        }

        public void Compute(char @operator, int operand)
        {
            // Create command operation and execute it

            Command command = new CalculatorCommand(calculator, @operator, operand);
            command.Execute();

            // Add command to undo list

            commands.Add(command);
            current++;
        }
    }
}
