using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tech_Hub.Pages
{
    public class EditPageModel : PageModel
    {
        [BindProperty]
        public string fullname { get; set; }

        [BindProperty]
        public string EmailAddress { get; set; }

        [BindProperty]
        public string Phone { get; set; }

        [BindProperty]
        public string Street { get; set; }

        [BindProperty]
        public string City { get; set; }


		public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Console.WriteLine("onpost is working");
            return RedirectToPage("/UserAccount", new { F_name = fullname, Email = EmailAddress, P_number = Phone , Address=Street , city=City});
            
        }
    }
}
