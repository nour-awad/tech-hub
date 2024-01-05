using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Tech_Hub.Pages
{
    [BindProperties(SupportsGet = true)]
    public class ReviewsTable
    {
        [Required]
        public int reviewID { get; set; }

        public int rating { get; set; }

        public DateTime reviewDate { get; set; }

        public string reviewText { get; set; }

        public int customerID { get; set; }

        public int productID { get; set; }
    }
}
