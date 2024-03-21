using Microsoft.AspNetCore.Mvc;

namespace cSharpCalculatorMahib.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(double InputValue1, double InputValue2, string op)
        {
            double result = 0;

            switch(op)
            {
                case "+":
                    result = InputValue1 + InputValue2;
                    break;
                case "-":
                    result = InputValue1 - InputValue2;
                    break;
                case "*":
                    result = InputValue1 * InputValue2;
                    break;
                case "/":
                    if (InputValue2 != 0)
                    {
                        result = InputValue1 / InputValue2;
                    }
                    else
                    {
                        ViewBag.Error = "Error: Division by zero";
                        return View("Index");
                    }
                    break;
                default:
                    ViewBag.Error = "Invalid operator";
                    return View("Index");
            }

            ViewData["ResultView"] = result;
            ViewData["error"] = ViewBag.error;
            return View("Index");
            

        }
    }
}