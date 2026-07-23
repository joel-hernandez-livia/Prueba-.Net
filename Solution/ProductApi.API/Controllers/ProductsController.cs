using Microsoft.AspNetCore.Mvc;

namespace ProductApi.API.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
