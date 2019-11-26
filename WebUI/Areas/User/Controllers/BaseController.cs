using Microsoft.AspNetCore.Mvc;
using WebUI.Security;

namespace WebUI.Areas.User.Controllers
{
    [CustomAuthorize(Role = "User")]
    [Area("User")]
    public class BaseController : Controller
    {

    }
}