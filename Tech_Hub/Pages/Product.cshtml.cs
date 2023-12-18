using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Tech_Hub.Pages
{
    public class ProductModel : PageModel
    {
        private List<Review> reviews = new List<Review>();

        // Property to expose reviews to the Razor Page
        public IEnumerable<Review> Reviews => reviews;

        public void OnGet()
        {
            
        }

        public IActionResult OnPostSubmitReview(Review review)
        {
            reviews.Add(review);

            return RedirectToPage();
        }
    }
}
