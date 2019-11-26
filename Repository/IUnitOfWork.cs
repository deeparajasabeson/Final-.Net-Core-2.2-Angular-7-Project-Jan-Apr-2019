using Repository.Abstraction;

namespace Repository
{
    public interface IUnitOfWork
    {

        IAuthenticateRepository AuthenticateRepo { get; }
        ICategoryRepository CategoryRepo { get; }
        IProductRepository ProductRepo { get; }
        IOrderRepository OrderRepo { get; }

        int SaveChanges();
    }
}
