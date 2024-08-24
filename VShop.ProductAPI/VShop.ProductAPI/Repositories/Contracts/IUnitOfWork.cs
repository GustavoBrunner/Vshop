namespace VShop.ProductAPI.Repositories.Contracts
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();
    }
}
