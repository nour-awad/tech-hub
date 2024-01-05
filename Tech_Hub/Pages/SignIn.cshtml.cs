using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
namespace Tech_Hub.Pages;

public class SignIn : PageModel
{

    [BindProperty]
    public string user_Email { get; set; }
    [BindProperty]
    public string user_Password { get; set; }

    public void OnGet()
    {
        
    }

    public IActionResult OnPost(string user_Email)
    {
        bool is_user = DatabaseOperations.SearchData("Data Source=kimo;Initial Catalog=\"TechHub Database\";Integrated Security=True", "Customer", "Email", user_Email);
        if (is_user)
        {
            Console.WriteLine("user found");
            return RedirectToPage("/Cart",new { userEmail = user_Email });
        }
        else 
        {
            Console.WriteLine("cant find user");
            return RedirectToPage();
        }
    }
}
