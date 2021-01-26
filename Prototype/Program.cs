using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer() {Name = "faruk", LastName = "kardaş", Budget = 350, Id = 1};
         

            Customer customer2 = (Customer)customer.Clone();
            customer2.Name = "Fatih";
            customer2.LastName = "Kardaşş";
            customer2.Budget = 500;
            customer2.Id = 2;

            Console.WriteLine(customer.Name);
            Console.WriteLine(customer2.Name);

        }
    }

    public abstract class Person
    {
        public abstract Person Clone();
        public int Id { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

    }

    public class Customer : Person
    {
        public int Budget { get; set; }
        public override Person Clone()
        {
            return (Person) MemberwiseClone();
        }
    }
    public class Employee : Person
    {
        
        public int Salary { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }


}
