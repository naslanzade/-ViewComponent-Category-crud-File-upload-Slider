using Fiorello.Models;

namespace Fiorello.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsnyc(int? id);
        Task<Product> GetByIdWithImageAsnyc(int? id);
    }
}
