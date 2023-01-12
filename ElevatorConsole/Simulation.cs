using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ElevatorConsole
{
    internal class Simulation
    {
        public static void Tick(Group group)
        //Move time forward and Execute moves in the Elevator group
        {
            //Execute group
            group.Execute();

            //Add random Call
            Random rnd = new Random(DateTime.Now.Second + DateTime.Now.Millisecond);
            if (rnd.Next() % 5 == 0) group.Floors[rnd.Next() % group.Floors.Count].Button = true;

            //Draw new frame into Console
            NewFrame(group);
        }

        public static void NewFrame(Group group)
        {
            //Clear Console
            Console.Clear();

            //Draw NewFrame
            Draw(group);
        }

        private static void Draw(Group group)
        //Draws a NewFrame
        {
            //Draw the roof
            string roof = " +";
            for (int i = 0; i < group.Cabins.Count; i++)
            {
                roof += "-+";
            }
            roof += "-----";
            Console.WriteLine(roof);

            //Draw group
            string floor = "";
            for (int i = group.Floors.Count-1; i >= 0; i--)
            {
                //Buff the Floor
                floor = " |";
                for (int j = 0; j < group.Cabins.Count; j++)
                {
                    if (group.Cabins[j].Position == i)
                    {
                        if (group.Cabins[j].Heading > group.Cabins[j].Position) floor += "^";
                        else if (group.Cabins[j].Heading < group.Cabins[j].Position) floor += "v";
                        else floor += "-";
                    }
                    else floor += " ";
                    floor += "|";
                }

                //Buff Floor Button
                floor += i.ToString();
                if (group.Floors[i].Button == true) floor += " *";
                for (int j = 0; j < group.Cabins.Count; j++)
                {
                    if (group.Cabins[j].CabinOrders.Contains(i)) floor += " o";
                }

                //Draw the Floor
                Console.WriteLine(floor);



                //Buff the division
                floor = " +";
                for (int j = 0; j < group.Cabins.Count; j++)
                {
                    if (group.Cabins[j].Position == i || group.Cabins[j].Position + 1 == i)
                    {
                        floor += "-";
                    }
                    else floor += " ";
                    floor += "+";
                }
                //Buff the division flooring
                floor += "-----";

                //Draw the division
                Console.WriteLine(floor);
            }
            Console.WriteLine(
                " * = Call of the Cabin to the Floor\n" +
                " o = Order from a Passenger inside the Cabin\n\n" +
                " Chance of calling an elevator is set to 20% per Tick.\n" +
                " It might seem that there is a problem with the application,\n" +
                " but please press Enter a few more times before considering restarting the application.");
            Console.WriteLine("\nInsert \"q\" to quit, or press Enter to continue.");
        }
    }
}
