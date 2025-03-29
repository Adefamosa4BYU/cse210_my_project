using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");

         // Creating addresses
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Address address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");

        // Creating customers
        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Alice Smith", address2);

        // Creating orders
        Order order1 = new Order(customer1);
        Order order2 = new Order(customer2);

        // Adding products to orders
        order1.AddProduct(new Product("Laptop", "P123", 1200, 1));
        order1.AddProduct(new Product("Mouse", "P456", 25, 2));

        order2.AddProduct(new Product("Smartphone", "P789", 800, 1));
        order2.AddProduct(new Product("Charger", "P101", 30, 1));

        // Displaying order details
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalCost()}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalCost()}");
    }
}