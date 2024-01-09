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

        public string Street { get; set; }
        public string City { get; set; }


		public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/UserAccount", new { F_name = fullname, Email = EmailAddress, P_number = Phone });
        }
    }
}
