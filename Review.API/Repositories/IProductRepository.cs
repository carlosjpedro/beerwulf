using System.Threading.Tasks;
using Review.API.Services.Model;

namespace Review.API.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProduct(int productId);
    }
}

