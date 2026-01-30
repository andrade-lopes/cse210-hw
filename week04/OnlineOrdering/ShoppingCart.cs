using System.Collections.Generic;

public class ShoppingCart
{
    private List<Product> _products = new List<Product>();

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetSubtotal()
    {
        double total = 0;

        foreach (Product product in _products)
        {
            total += product.GetPrice();
        }

        return total;
    }

    public List<Product> GetProducts()
    {
        return _products;
    }
}