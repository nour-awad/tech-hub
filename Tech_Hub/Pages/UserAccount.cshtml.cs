using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tech_Hub.Pages;

public class UserAccount : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string F_name { get; set; }

	[BindProperty(SupportsGet = true)]
	public string L_name { get; set; }

	[BindProperty(SupportsGet = true)]
	public string Email { get; set; }

	[BindProperty(SupportsGet = true)]
	public string P_number { get; set; }


    public void OnGet()
    {
       
        
       

    }

}