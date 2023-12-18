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
			DateTime Ordertime = DateTime.Now;


			
			return RedirectToPage("/TrachOrder");
		}
	}
}
