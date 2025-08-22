using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    public class WorkerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
