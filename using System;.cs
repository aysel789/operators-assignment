using System;

namespace EmployeeComparison
{
    public class Employee
    {
        // Properties for the Employee class
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Overloading the "==" operator
        // It must take two Employee objects as parameters
        public static bool operator ==(Employee emp1, Employee emp2)
        {
            // Check if both objects are null, or if they are the same instance
            if (ReferenceEquals(emp1, emp2)) return true;

            // If one is null but not both, they are not equal
            if (ReferenceEquals(emp1, null) || ReferenceEquals(emp2, null)) return false;

            // Compare the Id properties to determine equality
            return emp1.Id == emp2.Id;
        }

        // Comparison operators must be overloaded in pairs (== and !=)
        public static bool operator !=(Employee emp1, Employee emp2)
        {
            // Return the opposite of the == operator
            return !(emp1 == emp2);
        }

        // Best practice: When overloading ==, you should also override Equals() and GetHashCode()
        public override bool Equals(object obj)
        {
            var emp = obj as Employee;
            if (emp == null) return false;
            return this.Id == emp.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}

using System;

namespace EmployeeComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the first Employee object and assign properties
            Employee employee1 = new Employee { Id = 101, FirstName = "Alice", LastName = "Smith" };

            // Instantiate the second Employee object with the same ID but different name to test logic
            Employee employee2 = new Employee { Id = 101, FirstName = "Bob", LastName = "Jones" };

            // Instantiate a third Employee with a unique ID
            Employee employee3 = new Employee { Id = 102, FirstName = "Charlie", LastName = "Brown" };

            // Compare employee1 and employee2 using the overloaded '==' operator
            // Since their IDs are both 101, this should evaluate to true
            Console.WriteLine("Comparing Employee 1 and Employee 2 (Same IDs):");
            if (employee1 == employee2)
            {
                Console.WriteLine("Result: These employees are considered equal based on ID.");
            }
            else
            {
                Console.WriteLine("Result: These employees are not equal.");
            }

            Console.WriteLine(); // Add a line break for readability

            // Compare employee1 and employee3
            // Since IDs are 101 and 102, this should evaluate to false
            Console.WriteLine("Comparing Employee 1 and Employee 3 (Different IDs):");
            if (employee1 == employee3)
            {
                Console.WriteLine("Result: These employees are equal.");
            }
            else
            {
                Console.WriteLine("Result: These employees are not equal based on ID.");
            }

            // Keep the console window open
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}

