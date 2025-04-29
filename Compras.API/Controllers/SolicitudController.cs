using Microsoft.AspNetCore.Mvc;

namespace Compras.API.Controllers
{
    public class SolicitudController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
