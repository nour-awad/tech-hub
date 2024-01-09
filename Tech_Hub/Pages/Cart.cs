public class Cart
{
	public List<string> cartItems = new List<string>();
	public List<Product> CartItems { get; set; } = new List<Product>();

	public string Email { get; set; }

	public int size { get; set; }

	public DateTime addTime = DateTime.Now;

}

public class Product
{
	public string Name { get; set; }

}