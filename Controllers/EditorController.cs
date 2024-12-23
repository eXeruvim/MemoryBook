using Microsoft.AspNetCore.Mvc;

namespace MemoryBook.Controllers
{
    public class EditorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
