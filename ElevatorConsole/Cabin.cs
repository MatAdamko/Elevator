namespace ElevatorConsole
{
    public class Cabin
    {
        public List<int> CabinOrders = new List<int>();
        public int Position;
        public int Heading;
        //FloorButtons -> List of pressed Floor Buttons

        public Cabin()
        //floorCount -> to initialize Floor Buttons in the Cabin
        {
            Position = 0;
            Heading = 0;
        }



        public void Execute(Group group)
        {
            //Update Cabin Heading to the farthest Cabin Order in the curent cabins Heading
            UpdateHeading();

            //Make a Stop and Remove Order, if among Cabin Orders || Move()
            if (CabinOrders.Contains(Position)) Stop();
            else if (group.FloorOrders.Contains(Position)) Stop(group);
            else Move();

            //Update Orders
        }



        private void Move()
        //Move one floor towards Heading
        {
            if (Heading > Position) Position++;
            else if (Heading < Position) Position--;
        }


        
        public void Stop()
        //Remove Order drom CabinOrders List
        {
            for (int i = 0; i < CabinOrders.Count; i++)
            {
                if (CabinOrders[i] == Position) CabinOrders.RemoveAt(i);
            }
        }
        public void Stop(Group group)
        //Remove Order drom FloorOrders List
        {
            for (int i = 0; i < group.FloorOrders.Count; i++)
            {
                if (group.FloorOrders[i] == Position)
                {
                    group.FloorOrders.RemoveAt(i);
                    group.Floors[Position].Button = false;
                    AddRandomOrder(group);
                }
            }
        }



        private void UpdateHeading()
        //Change heading to the farthest Cabin Order in that heading
        //If Cabin is heading Up, change Heading to the Highest Cabin Order
        //If Cabin heading Down, change Heading to the Lowest Cabin Order
        //Prioritazes CabinOrders before FloorOrders
        {
            //Heading Up
            if (CabinOrders.Count > 0)
            {
                Heading = CabinOrders[0];
            }
            else if (Heading > Position && CabinOrders.Count > 0) Heading = CabinOrders.Max();
            //Heading Down
            else if (Heading < Position && CabinOrders.Count > 0) Heading = CabinOrders.Min();
        }

        private void AddRandomOrder(Group group)
        { 
            Random rnd = new Random(DateTime.Now.Second + DateTime.Now.Millisecond);
            CabinOrders.Add(rnd.Next() % group.Floors.Count);
        }
    }
}