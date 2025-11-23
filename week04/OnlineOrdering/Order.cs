
using System.Text;

public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalPrice()
    {
        double subtotal = 0;

        foreach (var product in _products)
        {
            subtotal += product.GetTotalCost();
        }

        double shipping = _customer.LivesInUSA() ? 5 : 35;

        return subtotal + shipping;
    }

    public string GetPackingLabel()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Packing Label:");

        foreach (var product in _products)
        {
            sb.AppendLine(product.GetPackingLine());
        }

        return sb.ToString();
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}
