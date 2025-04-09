using System;

namespace FlightReservationSystem
{
    public class MenuHandler
    {
        // This object acts as the core logic manager for flights, customers, and bookings
        private AirlineCoordinator airlineCoordinator;

        // Constructor initializes the MenuHandler
        public MenuHandler(AirlineCoordinator coordinator)
        {
            airlineCoordinator = coordinator; // Assigning the passed coordinator to this instance
        }

        // Displays the main menu to the user and handles user interaction in a loop
        public void DisplayMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Welcome to our Flight Reservation System ===");
                Console.WriteLine("1. Add a Flight");
                Console.WriteLine("2. Add a Customer");
                Console.WriteLine("3. Make a Booking");
                Console.WriteLine("4. View added Flights");
                Console.WriteLine("5. View exisiting Customers");
                Console.WriteLine("6. View current Bookings");
                Console.WriteLine("0. Exit Program");
                Console.Write("Enter your choice (integer only): ");

                // Read the user's input and pass it to the menu handler
                string menuChoice = Console.ReadLine();
                HandleMainMenuChoice(menuChoice);
            }
        }

        
        private void HandleMainMenuChoice(string choice)
        {
            // Match the user's choice and invoke the corresponding method
            switch (choice)
            {
                case "1":
                    AddFlight();
                    break;
                case "2":
                    AddCustomer();
                    break;
                case "3":
                    MakeBooking();
                    break;
                case "4":
                    ViewFlights();
                    break;
                case "5":
                    ViewCustomers();
                    break;
                case "6":
                    ViewBookings();
                    break;
                case "0":
                    Console.WriteLine("Exiting program...");
                    Environment.Exit(0); // Shutdown the program
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again!");
                    break;
            }

            // Pausing the screen to allow the user to read messages before returning to the menu
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }

        // Prompts the user to add a new flightt with respective details
        private void AddFlight()
        {
            Console.Write("Enter the Flight Number: ");
            int selectedFlightNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter City of Origin: ");
            string originCity = Console.ReadLine();
            Console.Write("Enter your Destination: ");
            string flightDestination = Console.ReadLine();
            Console.Write("Enter Max Seats on this flight: ");
            int maxSeats = int.Parse(Console.ReadLine());
            
            if (airlineCoordinator.AddFlight(selectedFlightNumber, originCity, flightDestination, maxSeats))
                Console.WriteLine("Flight added successfully!");
            else
                Console.WriteLine("Flight number already exists.");
        }

        private void AddCustomer()
        {
            Console.Write("Enter customer's First Name: ");
            string customerFirstName = Console.ReadLine();
            Console.Write("Enter customer's Last Name: ");
            string customerLastName = Console.ReadLine();
            Console.Write("Enter the Phone Number: ");
            string phone = Console.ReadLine();

            // To add the customer and provide user feedback
            if (airlineCoordinator.AddCustomer(customerFirstName, customerLastName, phone))
                Console.WriteLine("Customer added successfully!");
            else
                Console.WriteLine("Customer already exists.");
        }

        private void MakeBooking()
        {
            Console.Write("Enter the Customer ID: ");
            int customerId = int.Parse(Console.ReadLine()); // Read customer ID
            Console.Write("Enter the Flight Number: ");
            int flightNumber = int.Parse(Console.ReadLine()); // Read flight number

            // Attempt to make the booking and provide feedback
            if (airlineCoordinator.MakeBooking(customerId, flightNumber))
                Console.WriteLine("Your booking was made successfully!");
            else
                Console.WriteLine("Booking failed! Check flight availability or customer ID...");
        }

        // Displays all flights stored in the system
        private void ViewFlights()
        {
            foreach (var flight in airlineCoordinator.GetFlights()) // Iterate through flights
                Console.WriteLine(flight);
        }

        // Displays all customers stored in the system
        private void ViewCustomers()
        {
            Console.WriteLine("=== Registered Customers ===");
            foreach (var customer in airlineCoordinator.GetCustomers())
                Console.WriteLine($"ID: {customer.CustomerID}, Name: {customer.FirstName} {customer.LastName}, Phone: {customer.PhoneNumber}, Bookings: {customer.BookingCount}");
        }

        private void ViewBookings()
        {
            foreach (var booking in airlineCoordinator.GetBookings())
                Console.WriteLine(booking);
        }
    }
}
