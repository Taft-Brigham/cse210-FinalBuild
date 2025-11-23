using System;

class Program
{
    static void Main(string[] args)
    {
        // ---------- CUSTOMER 1 (USA) ----------
        Address address1 = new Address("123 Apple St", "Provo", "UT", "USA");
        Customer customer1 = new Customer("Brigham Essien", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "LP100", 800, 1));
        order1.AddProduct(new Product("Mouse", "MS200", 25, 2));

        // ---------- CUSTOMER 2 (International) ----------
        Address address2 = new Address("45 Oxford Road", "Accra", "Greater Accra", "Ghana");
        Customer customer2 = new Customer("Kwame Mensah", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Phone Case", "PC101", 10, 3));
        order2.AddProduct(new Product("Screen Protector", "SP150", 5, 4));

        // ---------- DISPLAY RESULTS ----------
        Console.WriteLine("========= ORDER 1 =========");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice()}\n");

        Console.WriteLine("========= ORDER 2 =========");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice()}");
    }
}
