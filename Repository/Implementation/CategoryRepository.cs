using ApplicationCore;
using DomainModels.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Abstraction;

namespace Repository.Implementation
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public DatabaseContext context
        {
            get
            {
                return db as DatabaseContext;
            }
        }

        public CategoryRepository(DbContext db)
        {
            this.db = db;
        }

    }
}
