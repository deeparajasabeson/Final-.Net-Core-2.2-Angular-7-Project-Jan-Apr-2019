using Microsoft.AspNetCore.Mvc;
using Repository;
using WebUI.Security;

namespace WebUI.Areas.Admin.Controllers
{
    [CustomAuthorize(Role = "Admin")]
    [Area("Admin")]
    public class BaseController : Controller
    {
        protected IUnitOfWork uow;
        public BaseController(IUnitOfWork _uow)
        {
            uow = _uow;
        }
    }
}