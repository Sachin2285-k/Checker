using Checker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Checker.Controllers
{
    public class PalindromeChecker : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CheckValue(FormData formData)
        {
            char[] text = formData.TextToCheck.ToCharArray();

            var sb = new StringBuilder();

            foreach (char c in text)
            {
                if (!char.IsWhiteSpace(c) && !char.IsSymbol(c) && !char.IsPunctuation(c))
                {
                    sb.Append(c);
                }
            }

            var str = sb.ToString();

            char[] arr = str.ToCharArray();

            Array.Reverse(arr);

            string reversedString = new string(arr);

            if(reversedString.Length == 0) {
                return Content("Sorry there are no letters or numbers!!");
            }

            if(string.Equals(reversedString, str, StringComparison.OrdinalIgnoreCase))
            {
                return Content("String is Palindrome " + str);
            }

            return Content("String is not Palindrome " + str); 
        }
    }
}
