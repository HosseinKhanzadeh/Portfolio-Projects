using System;
using System.Collections.Generic;

namespace FlightReservationSystem
{
    public class AirlineCoordinator
    {
        // Collection of flights managed by the system
        private List<Flight> availableflights = new List<Flight>();

        // Collection of customers managed by the system
        private List<Customer> customers = new List<Customer>();

        // Collection of bookings managed by the system
        private List<Booking> bookings = new List<Booking>();


        private int nextCustomerId = 1;
        private int nextBookingId = 1;

        public bool AddFlight(int flightNumber, string origin, string destination, int maxSeats)
        {
            // Check if the flight number already exists
            if (availableflights.Exists(f => f.FlightNumber == flightNumber))
                return false;

            // Add the new flight to the collection
            availableflights.Add(new Flight(flightNumber, origin, destination, maxSeats));
            return true;
        }

        public bool AddCustomer(string firstName, string lastName, string phone)
        {
            // Duplicate customer check
            if (customers.Exists(c => c.FirstName == firstName && c.LastName == lastName && c.PhoneNumber == phone))
                return false;

            // Add the new customer with a unique ID to the collection
            customers.Add(new Customer(nextCustomerId++, firstName, lastName, phone));
            return true;
        }

        // Creates a booking for an existing customer and flight
        public bool MakeBooking(int customerId, int flightNumber)
        {
            var customer = customers.Find(c => c.CustomerID == customerId);
            var flight = availableflights.Find(f => f.FlightNumber == flightNumber);

            // Validate that the customer and flight exist, and the flight has available seats
            if (customer == null || flight == null || flight.IsFull())
                return false;

            // Here, we create the booking and update associated objects
            bookings.Add(new Booking(nextBookingId++, customer, flight));
            flight.AddPassenger();
            customer.AddBooking();
            return true;
        }

        // Retrieving the list of all flights, customers, and bookings
        public List<Flight> GetFlights()
        {
            return availableflights;
        }

        public List<Customer> GetCustomers()
        {
            return customers;
        }

        public List<Booking> GetBookings()
        {
            return bookings;
        }

        // Deletes a customer if they have no bookings
        public bool DeleteCustomer(int customerId)
        {
            var customer = customers.Find(c => c.CustomerID == customerId);

            if (customer == null || customer.BookingCount > 0)
                return false;

            // Remove the customer from the collection
            customers.Remove(customer);
            return true;
        }

        // Deletes a flight if no customers are booked on it
        public bool DeleteFlight(int flightNumber)
        {
            var flight = availableflights.Find(f => f.FlightNumber == flightNumber);

            // To ensure the flight exists and has no passengers booked
            if (flight == null || flight.PassengerCount > 0)
                return false;

            availableflights.Remove(flight);
            return true;
        }
    }
}
