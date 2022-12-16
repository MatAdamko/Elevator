using System.Data;

namespace ElevatorConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            Group group1 = new Group(10, 1);

            Console.WriteLine("Press Enter to Begin.");

            while (Console.ReadLine() != "q")
            {
                Simulation.Tick(group1);
            }

        }
    }
}