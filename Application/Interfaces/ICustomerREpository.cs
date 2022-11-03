

using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICustomerREpository : IRepositoryBase<Customer>
    {
        public string GetCollectionName();
    }
}
