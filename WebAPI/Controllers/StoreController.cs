using DomainModels.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("CrossOrigin")]
    public class StoreController : ControllerBase
    {
        IUnitOfWork uow;
        public StoreController(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        //https://localhost:44384/api/store/getProducts
        public IEnumerable<Product> GetProducts()
        {
            return uow.ProductRepo.GetAll();
        }

        [HttpPost]
        public int SaveCart([FromBody]Cart cart)
        {
            return uow.OrderRepo.SaveCart(cart);
        }

        [HttpPost]
        public void AddProduct(Product model)
        {
            uow.ProductRepo.Add(model);
            uow.SaveChanges();
        }

    }
}