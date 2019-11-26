using Microsoft.AspNetCore.Mvc;
using Repository;

namespace WebUI.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IUnitOfWork _uow) : base(_uow)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}