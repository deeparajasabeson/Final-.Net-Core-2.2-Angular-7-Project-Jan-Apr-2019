using ApplicationCore;
using DomainModels.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Abstraction;

namespace Repository.Implementation
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private DatabaseContext context
        {
            get
            {
                return db as DatabaseContext;
            }
        }

        public ProductRepository(DbContext db)
        {
            this.db = db;
        }
    }
}
