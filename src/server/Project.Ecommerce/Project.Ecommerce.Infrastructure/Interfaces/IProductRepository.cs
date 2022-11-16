using Project.Ecommerce.Infrastructure.DTOS.Command;
using Project.Ecommerce.Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Ecommerce.Infrastructure.Interfaces
{
    public interface IProductRepository
    {
        Task<(IEnumerable<Products> list, int totalCount)> FindAsync();
        Task<(IEnumerable<Products> list, int totalCount)> FindByIdAsync(int id);
        Task<Products> CreateProduct(ProductCommand command);
        Task<Products> UpdateProduct(ProductCommand command, int id);
        Task DeleteProduct(int id);
    }
}
