using DomainModels.Entities;
using DomainModels.ViewModels;

namespace Repository.Abstraction
{
    public interface IOrderRepository : IRepository<Order>
    {
        int SaveCart(Cart model);
        void PlaceOrder(TransactionModel model);
    }
}
