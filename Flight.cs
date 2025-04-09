namespace FlightReservationSystem
{
    public class Flight
    {
        public int FlightNumber { get; private set; }

        public string Origin { get; private set; }

        public string Destination { get; private set; }

        public int MaxSeats { get; private set; }

        public int PassengerCount { get; private set; }

        // Constructor initializes a Flight object with the necessary details
        public Flight(int flightNumber, string origin, string destination, int maxSeats)
        {
            // Validate input to ensure valid flight creation
            if (string.IsNullOrWhiteSpace(origin))
                throw new ArgumentException("Origin cannot be empty or null.", nameof(origin));
            
            if (string.IsNullOrWhiteSpace(destination))
                throw new ArgumentException("Destination cannot be empty or null.", nameof(destination));
            
            if (maxSeats <= 0)
                throw new ArgumentException("Max seats must be greater than zero.", nameof(maxSeats));

            FlightNumber = flightNumber;
            Origin = origin;
            Destination = destination;
            MaxSeats = maxSeats;
                PassengerCount = 0; // Initialize with no passengers
            }

        // Adds a passenger to the flight
        public bool AddPassenger()
        {
            if (PassengerCount < MaxSeats) // Check if seats are available
            {
                PassengerCount++; // Increment the passenger count
                return true; // Passenger was added
            }
            return false; // Flight is fully booked
        }

        // Removes a passenger from the flight
        public bool RemovePassenger()
        {
            if (PassengerCount > 0) // Ensure there are passengers to remove
            {
                PassengerCount--; // Decrement the passenger count
                return true; // Successfully removed a passenger
            }
            return false; // No passengers to remove
        }

        // Checks if the flight is fully booked
        public bool IsFull()
        {
            return PassengerCount >= MaxSeats;
        }

        // Override of the ToString() method to provide a readable summary of the flight
        public override string ToString()
        {
            return $"Flight {FlightNumber}:\n" +
                   $"- Route: {Origin} -> {Destination}\n" +
                   $"- Seats: {PassengerCount}/{MaxSeats}";
        }
    }
}
