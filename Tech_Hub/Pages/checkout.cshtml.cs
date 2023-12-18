using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tech_Hub.Pages
{
    public class checkoutModel : PageModel
    {
        public void OnGet()
        {
        }
		public IActionResult OnPost()
		{
			// Capture the current date and time
			DateTime Ordertime = DateTime.Now;

			// You can add more processing logic here, such as storing the order in a database, sending emails, etc.

			// Redirect to a thank you page or any other page you'd like
			return RedirectToPage("/ThankYou");
		}
	}
}
