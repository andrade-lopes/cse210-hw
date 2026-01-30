using System;
using System.Collections.Generic;

public class Order
{
    private Customer _customer;
    private List<Product> _products;
    private double _taxRate = 0.10; // 10% tax

    public Order(Customer customer, List<Product> products)
    {
        _customer = customer;
        _products = products;
    }

    public double CalculateTotal()
    {
        double subtotal = 0;

        foreach (Product product in _products)
        {
            subtotal += product.GetPrice();
        }

        double tax = subtotal * _taxRate;
        return subtotal + tax;
    }

    public void DisplaySummary()
    {
        Console.WriteLine($"Customer: {_customer.GetCustomerName()}");
        Console.WriteLine("Products:");

        foreach (Product product in _products)
        {
            Console.WriteLine($"- {product.GetName()} : ${product.GetPrice()}");
        }

        Console.WriteLine($"Total (with tax): ${CalculateTotal()}");
    }
}