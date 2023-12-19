using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tech_Hub.Pages
{
    public class TrackOrderModel : PageModel
    {
		public DateTime OrderTime { get; set; }

		public void OnGet(DateTime orderTime)
		{
			OrderTime = orderTime;
		}
		
    }
}
