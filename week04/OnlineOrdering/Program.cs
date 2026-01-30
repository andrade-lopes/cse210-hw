// OrderSystem
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");

        Customer customer = new Customer("Jose Lopes", "jose@email.com");

        Product product1 = new Product("Laptop Bag", 35.00);
        Product product2 = new Product("Wireless Mouse", 20.00);

        ShoppingCart cart = new ShoppingCart();
        cart.AddProduct(product1);
        cart.AddProduct(product2);

        Order order = new Order(customer, cart.GetProducts());
        order.DisplaySummary();
    }
}