using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Tech_Hub.Pages
{
    public class ProductModel : PageModel
    {
        private readonly Cart _cart;

        DatabaseOperations Operation = new DatabaseOperations();


        public ProductModel()
        {
			ReviewsCount = CountElements(reviews);
			avg_rating = CalculateAverage(reviews, r => r.Rating);

            _cart = new Cart();
        }
        

        private List<Review> reviews = new List<Review>();

        public IEnumerable<Review> Reviews => reviews; // make the page reads review

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




		public string productName;

		public string productOldPrice;

		public string productNewPrice;

		public string productCategory;



		int review_id = 33;
        int product_id = 30;


        public void OnGet(string namme,string emaiil,string revieew,int ratingg)
        {



			productName = "MAC BOOK";

			productOldPrice = "$950";

			productNewPrice = "$1000";

			productCategory = "LAPTOPS";


			DatabaseOperations.InsertReviewData("Data Source=kimo;Initial Catalog=\"TechHub Database\";Integrated Security=True", 48, 5, DateTime.Now, revieew, 1, product_id);




            reviews.Add(new Review
            {
                UserName = "karim",
                Email = "john@example.com",
                Comment = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                Rating = 5,
                now = DateTime.Now
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
			Console.WriteLine("on post");
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

        public static int CountElements<T>(List<T> list)
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
            float avg;
            
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
		public void OnPostAddToCart()
		{
            DatabaseOperations.InsertCartData("Data Source=kimo;Initial Catalog=\"TechHub Database\";Integrated Security=True",39,1,1,1);
		}

	}



}
