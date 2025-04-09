using System;
using System.Collections.Generic;

namespace FlightReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            AirlineCoordinator coordinator = new AirlineCoordinator();
            MenuHandler menuHandler = new MenuHandler(coordinator);

            menuHandler.DisplayMainMenu();
        }
    }
}
