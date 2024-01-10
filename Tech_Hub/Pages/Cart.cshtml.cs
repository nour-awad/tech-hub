using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tech_Hub.Pages;

public class Cart : PageModel
{
    public List<string> CartItems { get; set; }

    public Cart()
    {
        CartItems = new List<string>();
    }

    public void AddToCart(string product)
    {
        CartItems.Add(product);
    }

    public void RemoveFromCart(string product)
    {
        CartItems.Remove(product);
    }




    public void OnGet()
    {
        
    }
}
