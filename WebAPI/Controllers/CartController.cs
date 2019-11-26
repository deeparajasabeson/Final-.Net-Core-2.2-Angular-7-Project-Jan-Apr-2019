using DomainModels.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Service.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("CrossOrigin")]
    public class CartController : Controller
    {
        IUnitOfWork uow;
        public CartController(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        // POST api/<controller>
        [HttpPost]
        public void SaveCart([FromBody]Cart cart)
        {
        }
    }
}
