using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Tech_Hub.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        DatabaseOperations Operations = new DatabaseOperations();

		public void btnClick_AddToCart()
		{
            DatabaseOperations.InsertCartData("Data Source=kimo;Initial Catalog=\"TechHub Database\";Integrated Security=True", 1, 1, 1,1);

		}
	}
}