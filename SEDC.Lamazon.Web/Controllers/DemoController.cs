using Microsoft.AspNetCore.Mvc;

namespace SEDC.Lamazon.Web.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Test(int id, string fName, string lName, int age, string message)
        {
            ViewBag.Id = id;
            ViewBag.fName = fName;
            ViewBag.lName = lName;
            ViewBag.age = age;
            ViewBag.message = message;


            return View();
        }
    }
}
