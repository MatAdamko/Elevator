using System.Data;

namespace ElevatorConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            int cabins = 1;
            int floors = 4;

            //Take number of Cabins
            Console.Write(
                "Welcome to the Elevator Simulation Application!\n" +
                "Enter the number of Cabins you would like to see running up and down.\n" +
                "Please, select between 1 and 10.\n" +
                "-> ");

            cabins = Int32.Parse(Console.ReadLine());
            while (cabins < 1 || cabins > 10)
            {
                Console.Write("\r");
                Console.Write("-> ");
                cabins = Int32.Parse(Console.ReadLine());
            }

            //Take number of Floors
            Console.Write(
                "And now enter the number of floors that these cabins will have to deal with.\n" +
                "Please, select between 4 and 20.\n" +
                "-> ");

            floors = Int32.Parse(Console.ReadLine());
            while (floors < 4 || floors > 20)
            {
                Console.Write("\r");
                Console.Write("-> ");
                floors = Int32.Parse(Console.ReadLine());
            }

            Group group1 = new Group(floors, cabins);

            Console.WriteLine("Press Enter to Begin.");

            while (Console.ReadLine() != "q")
            {
                Simulation.Tick(group1);
            }

        }
    }
}