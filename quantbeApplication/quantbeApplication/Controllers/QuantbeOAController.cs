using Microsoft.AspNetCore.Mvc;

namespace quantbeApplication.Controllers
{
    public class QuantbeOAController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
