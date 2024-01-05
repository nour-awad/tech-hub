using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tech_Hub.Pages
{
    public class SignUpModel : PageModel
    {
        DatabaseOperations Operation = new DatabaseOperations();

        [BindProperty]
        public string first_Name { get; set; }
        [BindProperty]
        public string secound_Name { get; set; }
        [BindProperty]
        public string user_Email { get; set; }
        [BindProperty]
        public string user_Password { get; set; }
        [BindProperty]
        public string user_RePassword { get; set; }
        [BindProperty]
        public string user_PhoneNumber { get; set; }

        




        public void OnGet(string first_Name, string secound_Name, string user_Email, string user_PhoneNumber)
        {
            DatabaseOperations.InsertCustomerData("Data Source=kimo;Initial Catalog=\"TechHub Database\";Integrated Security=True", first_Name, secound_Name, "--- st", "--- shipping", user_PhoneNumber, user_Email);
        }


        public IActionResult OnPostSignUp() 
        {
            bool is_user = DatabaseOperations.SearchData("Data Source=kimo;Initial Catalog=\"TechHub Database\";Integrated Security=True", "Customer", "Email",user_Email);
            if (!is_user)
            {
                return RedirectToPage();
            }
            else
            {
                return RedirectToPage("Index");
            }
        }
    }

}
