using Microsoft.AspNetCore.Mvc;

namespace Agentie.Controllers
{
    public class Empty : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
