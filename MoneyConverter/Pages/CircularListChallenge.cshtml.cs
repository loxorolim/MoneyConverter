using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoneyConvert.Core;
using System;

namespace MoneyConverter.Pages
{
    public class CircularListChallengeModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Your contact page.";
        }

        public JsonResult OnPost(string circularListString, int numberToFind)
        {
            string[] splitted = circularListString.Split(',');
            int[] myInts = Array.ConvertAll(splitted, s => int.Parse(s));

            bool result = CircularListUtils.Exists(numberToFind, myInts);

            return new JsonResult(result);
        }
    }
}
