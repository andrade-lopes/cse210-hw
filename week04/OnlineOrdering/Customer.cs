public class Customer
{
    private string _customerName;
    private string _email;

    public Customer(string name, string email)
    {
        _customerName = name;
        _email = email;
    }

    public string GetCustomerName()
    {
        return _customerName;
    }

    public string GetEmail()
    {
        return _email;
    }
}