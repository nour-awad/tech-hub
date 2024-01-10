using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Tech_Hub.Pages;

public class SignIn : PageModel
{
    [Required]
    [BindProperty]
    public string? user_Email { get; set; }
    [Required]
    [BindProperty]
	public string user_Password { get; set; }




	[BindProperty(SupportsGet = true)]
	public string f_name { get; set; }

	[BindProperty(SupportsGet = true)]
	public string l_name { get; set; }

	[BindProperty(SupportsGet = true)]
	public string email { get; set; }

	[BindProperty(SupportsGet = true)]
	public string Phone_number { get; set; }


	public void OnGet()
    {
        
    }

    public IActionResult OnPost()
    {

        bool is_user = DatabaseOperations.SearchData("Data Source=kimo;Initial Catalog=\"TechHub Database\";Integrated Security=True", "Customer", "Email", user_Email);
        if (is_user)
        {
            Console.WriteLine("user found");
            return RedirectToPage("/UserAccount", new { Email = user_Email , F_name=f_name, L_name =l_name , P_number = Phone_number});
        }
        else
        {
            Console.WriteLine("cant find user");
            return RedirectToPage();
        }
    }

    
}
