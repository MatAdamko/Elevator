using System.Diagnostics;
using System.Drawing;

namespace ElevatorConsole
{
    public class Group
    {
        public List<Floor> Floors = new List<Floor>();
        public List<Cabin> Cabins = new List<Cabin>();
        public List<int> FloorOrders = new List<int>();

        public Group(int floorCount, int cabinCount)
        {
            for (int i = 0; i < floorCount; i++)
            {
                Floors.Add(new Floor());
            }
            for (int i = 0; i < cabinCount; i++)
            {
                Cabins.Add(new Cabin());
            }
        }



        public void Execute()
        {
            //Update FloorOrders
            CheckForStop();
            UpdateOrders();

            //Give Order to closest Cabin without CabinOrders
            if (FloorOrders.Count > 0) GiveOrder(FloorOrders[0]);

            //Execute all Cabins Orders
            ExecuteCabins();
        }


        private void CheckForStop()
        {
            if (FloorOrders.Count > 0)
            {
                for (int i = 0; i < Cabins.Count; i++)
                {
                    if (FloorOrders.Contains(Cabins[i].Position)) Cabins[i].Stop(this);
                }
            }
        }
        private void ExecuteCabins()
        //Execute all Cabins Orders
        {
            for (int i = 0; i < Cabins.Count; i++)
            {
                if (FloorOrders.Contains(Cabins[i].Position)) Cabins[i].Stop();
                Cabins[i].Execute(this);
            }
        }



        private void GiveOrder(int floor)
        //Give Order to ClosestCabin without CabinOrders and without Heading
        {
            //Designate Cabins without Orders and without Heading
            List<Cabin> cabins = new List<Cabin>();
            for (int i = 0; i < Cabins.Count; i++)
            {
                if (Cabins[i].CabinOrders.Count == 0 && Cabins[i].Heading == Cabins[i].Position)
                {
                    cabins.Add(Cabins[i]);
                }
            }

            //Find available Cabin
            if (!CheckCabinPath(floor)) ClosestCabin(floor).Heading = floor;
        }

        private bool CheckCabinPath(int floor)
        {
            for (int i = 0; i < Cabins.Count; i++)
            {
                if (Cabins[i].Heading > Cabins[i].Position && Cabins[i].Heading >= floor && Cabins[i].Position < floor)
                {
                    return true;
                }

                if (Cabins[i].Heading < Cabins[i].Position && Cabins[i].Heading <= floor && Cabins[i].Position > floor)
                {
                    return true;
                }
            }
            return false;
        }

        private Cabin ClosestCabin(int floor)
        //Return closest Cabin to the next Order
        {
            for (int i = 0; i < Cabins.Count; i++)
            {
                //Check moving Cabin
                if (Cabins[i].Heading != Cabins[i].Position)
                {
                    //Check if Cabin has order along its path towards Heading
                    if (Cabins[i].Heading > Cabins[i].Position && Cabins[i].Heading > floor && Cabins[i].Position < floor)
                    {
                        return Cabins[i];
                    }

                    if (Cabins[i].Heading < Cabins[i].Position && Cabins[i].Heading < floor && Cabins[i].Position > floor)
                    {
                        return Cabins[i];
                    }
                }

                //Check free Cabin
                if (Cabins[i].Position == Cabins[i].Heading)
                {
                    return Cabins[i];
                }
            }
            return Cabins[0];
        }



        private void UpdateOrders()
        //Check Call Buttons on every Floor and Adds new Order to FloorOrders
        {
            for (int i = 0; i < Floors.Count; i++)
            {
                if (Floors[i].Button == true) SaveOrder(i);
            }
        }

        private void SaveOrder(int floor)
        //Add Order to FloorOrders List if doesnt contain new Order
        {
            if (!FloorOrders.Contains(floor)) FloorOrders.Add(floor);
        }
    }
}