using Domain.Entities;

namespace Application.Interfaces
{
    public interface IHouseRepository : IRepositoryBase<House>
    {
        public string GetCollectionName();
    }
}
