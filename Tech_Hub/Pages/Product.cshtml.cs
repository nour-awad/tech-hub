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

        StarCalculator starCalculator = new StarCalculator();

        public int ReviewsCount { get; set; }
        public float avg_rating { get; set; }

        public int star1Count { get; set; }
        public int star2Count { get; set; }
        public int star3Count { get; set; }
        public int star4Count { get; set; }
        public int star5Count { get; set; }

        [BindProperty]
        public string namme { get; set; }
        [BindProperty]
        public string emaiil { get; set; }
        [BindProperty]
        public string revieew { get; set; }
        [BindProperty]
        public int ratingg { get; set; }

        public ProductModel()
        {
            ReviewsCount = CountElements(reviews);
            avg_rating = CalculateAverage(reviews, r => r.Rating);
        }

        public void OnGet(string namme,string emaiil,string revieew,int ratingg)
        {
            reviews.Add(new Review
            {
                UserName = "karim",
                Email = "john@example.com",
                Comment = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                Rating = 5
            });

            
            reviews.Add(new Review
            {
                UserName = namme,
                Email = emaiil,
                Comment = revieew,
                Rating = ratingg
            });

            ReviewsCount = CountElements(reviews);
            avg_rating = CalculateAverage(reviews,r => r.Rating);

            star1Count = starCalculator.CalculateStar1(reviews);
            star2Count = starCalculator.CalculateStar2(reviews);
            star3Count = starCalculator.CalculateStar3(reviews);
            star4Count = starCalculator.CalculateStar4(reviews);
            star5Count = starCalculator.CalculateStar5(reviews);
        }

        public IActionResult OnPostSubmitReview()
        {
            reviews.Add(new Review
            {
                UserName = namme,
                Email = emaiil,
                Comment = revieew,
                Rating = ratingg
            });

            ReviewsCount = CountElements(reviews);

            avg_rating = CalculateAverage(reviews, r => r.Rating);

            star1Count = starCalculator.CalculateStar1(reviews);
            star2Count = starCalculator.CalculateStar2(reviews);
            star3Count = starCalculator.CalculateStar3(reviews);
            star4Count = starCalculator.CalculateStar4(reviews);
            star5Count = starCalculator.CalculateStar5(reviews);
            
            return RedirectToPage();
        }

        private static int CountElements<T>(List<T> list)
        {
            int count = 0;

            foreach (T item in list)
            {
                count++;
            }

            return count;
        }

        public static float CalculateAverage<T>(List<T> list, Func<T, int> ratingSelector)
        {
            int count = 0;
            int sum = 0;
            float avg=0;
            
            foreach (T item in list)
            {
                count++;
                sum += ratingSelector(item);
            }

            if (count > 0)
            {
                avg = (float)sum / count;
                return (float)Math.Round(avg, 1);
            }
            else
            {
                return 0;
            }
        }
    }
}
