using System;

namespace FlightReservationSystem
{
    public class Booking
    {
        // Unique ID for the booking, auto-assigned by the system
        public int BookingNumber { get; private set; }

        // This is Date and time the booking was created
        public DateTime BookingDate { get; private set; }

        // Reference to the Customer associated with the booking
        public Customer Customer { get; private set; }

        // Reference to the Flight associated with the booking
        public Flight AssociatedFlight { get; private set; }

        // Constructor initializes the Booking object with required details
        public Booking(int bookingId, Customer customer, Flight flight)
        {
            if (customer == null)
            throw new ArgumentNullException(nameof(customer), "Customer cannot be null.");
            if (flight == null)
            throw new ArgumentNullException(nameof(flight), "Flight cannot be null.");

            BookingNumber = bookingId; // Assign booking ID
            BookingDate = DateTime.Now; 
            Customer = customer;
            AssociatedFlight = flight;
        }

        // Overriding of the ToString() method to provide a readable representation of a Booking object
        public override string ToString()
        {
            // Include booking details, customer name, and flight number
            return $"Booking {BookingNumber}:\n" +
                   $"- Date: {BookingDate}\n" +
                   $"- Customer: {Customer.FirstName} {Customer.LastName}\n" +
                   $"- Flight: {AssociatedFlight.FlightNumber} ({AssociatedFlight.Origin} -> {AssociatedFlight.Destination})";
        }
    }
}