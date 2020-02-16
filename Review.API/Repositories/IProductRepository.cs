using System.Threading.Tasks;
using Review.API.Entities;

namespace Review.API.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProduct(int productId);
    }
}

