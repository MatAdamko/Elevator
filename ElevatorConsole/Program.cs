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
                "There is no limit in this version, so be careful! (works best with 1 anyway, for now)\n" +
                "-> ");
            cabins = Int32.Parse(Console.ReadLine());

            //Take number of Floors
            Console.Write(
                "And now enter the number of floors that these cabins will have to deal with.\n" +
                "There is no limit in this version, so be careful!\n" +
                "-> ");

            floors = Int32.Parse(Console.ReadLine());

            Group group1 = new Group(floors, cabins);

            Console.WriteLine("Press Enter to Begin.");

            while (Console.ReadLine() != "q")
            {
                Simulation.Tick(group1);
            }

        }
    }
}