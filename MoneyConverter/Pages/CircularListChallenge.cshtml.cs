using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MoneyConverter.Pages
{
    public class CircularListChallengeModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Your contact page.";
        }
    }
}
