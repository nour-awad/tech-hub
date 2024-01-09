using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tech_Hub.Pages
{
    public class EditPageModel : PageModel
    {
        public string fullname { get; set; }

        public void OnGet()
        {
        }

        public IActionResult Onpost()
        {
            return RedirectToPage("/UserAccount", new {F_name = fullname });
        }
    }
}
