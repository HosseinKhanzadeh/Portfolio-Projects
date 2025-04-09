namespace FlightReservationSystem
{
    public class Customer
    {
        // Unique ID for the customer
        public int CustomerID { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string PhoneNumber { get; private set; }

        public int BookingCount { get; private set; }

        // Constructor initializes a Customer object with required details
        public Customer(int customerId, string firstName, string lastName, string phone)
        {
            // Validate the input to ensure no invalid data is assigned
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name cannot be empty or null.", nameof(firstName));
            
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name cannot be empty or null.", nameof(lastName));
            
            if (string.IsNullOrWhiteSpace(phone))
                throw new ArgumentException("Phone number cannot be empty or null.", nameof(phone));

            CustomerID = customerId; // Assign the unique customer ID
            FirstName = firstName; // Assign the customer's first name
            LastName = lastName; // Assign the customer's last name
            PhoneNumber = phone; // Assign the customer's phone number
            BookingCount = 0; // Initialize with no bookings
        }

        // Increment the number of bookings for this customer
        public void AddBooking()
        {
            BookingCount++;
        }

        // Decrement the number of bookings for this customer
        public void RemoveBooking()
        {
            if (BookingCount > 0) // Ensure there are bookings to remove
            {
                BookingCount--;
            }
        }

        // Override of the ToString() method to provide a readable summary of the customer
        public override string ToString()
        {
            return $"Customer {CustomerID}:\n" +
                   $"- Name: {FirstName} {LastName}\n" +
                   $"- Phone: {PhoneNumber}\n" +
                   $"- Bookings: {BookingCount}";
        }
    }
}