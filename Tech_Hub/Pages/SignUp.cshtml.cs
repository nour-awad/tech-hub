using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;

namespace Tech_Hub.Pages
{
    public class SignUpModel : PageModel
    {
        DatabaseOperations Operation = new DatabaseOperations();

        [BindProperty]
        [Required]
        public string first_Name { get; set; }
        [BindProperty]
        [Required]
        public string secound_Name { get; set; }
        [BindProperty]
        [Required]
        public string user_Email { get; set; }
        [BindProperty]
        [Required]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "The password must be at least 8 characters long.")]
        public string user_Password { get; set; }
        [BindProperty]
        [Required]
        [Compare(nameof(user_Password), ErrorMessage = "The password and confirmation password do not match.")]
        public string user_RePassword { get; set; }
        [BindProperty]
        public string? user_PhoneNumber { get; set; }

        




        public void OnGet()
        {
            
        }


        public IActionResult OnPostSignUp() 
        {
            bool is_user = DatabaseOperations.SearchData("Data Source=kimo;Initial Catalog=\"TechHub Database\";Integrated Security=True", "Customer", "Email", user_Email);
            if (is_user)
            {
                return RedirectToPage();
            }
            else
            {
                DatabaseOperations.InsertCustomerData("Data Source=kimo;Initial Catalog=\"TechHub Database\";Integrated Security=True", first_Name, secound_Name, "--- st", "--- shipping", user_PhoneNumber, user_Email);
                return RedirectToPage("/SignIn", new { f_name = first_Name, l_name = secound_Name, email = user_Email, Phone_number = user_PhoneNumber });
            }
            
        }
    }

}
