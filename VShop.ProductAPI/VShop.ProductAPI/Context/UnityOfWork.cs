using VShop.ProductAPI.Repositories.Contracts;

namespace VShop.ProductAPI.Context
{
    public class UnityOfWork : IUnitOfWork
    {
        private readonly ProductApiContext _context;

        public UnityOfWork(ProductApiContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
