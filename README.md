# Elevator
Elevator algorithm

# Author
Matúš Adamko

# Description of my solution
I've decided to create an algorithm that takes multiple Elevator Cabins in consideration.
Application takes various numbers of Elevator Cabins and Floors and simulates Cabin movements in accordance to Elevator Orders.
Elevator Orders are put into queue and delt with one by one or if any Cabin has a path through the Ordered Floor.
The time passes throu world ticks. Every tick may randomly call an Elevator Cabin in addition to drawing the elevator shaft and moving the Cabins.

# Used technologies
Visual Studio, 
Console application, 
C#

# Description of Elevator algorithm
When the Elevator takes a Call Order a Cabin is ordered to move to that Floor. On arrival it deactivates the Call Button (which is a boolian). Additionally it stops at every Call along the way to the initial Call.
Elevator should prioritize Orders from inside the Cabin instead of the Calls from the Floors to bring passengers inside the Cabin to their destination before taking in the new ones. I've NOT implemented Cabin Capacity or Cabin Passenger Count.

Elevator takes a Call Order to a Floor, which is randomly selected. After reaching any Called Floor the Cabin gets an Order to move to a random Floor to simulate a passenger wanting to get to his floor.

# Steps for Compilation and Debugging
The Elevator Application is compiled and run in IDE.
Follow the instructions in the console application when you run it.
Just to be safe, enter only integers into the application initialization phase (number of Cabins and number of Floors).

