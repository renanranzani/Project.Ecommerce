using Project.Ecommerce.Infrastructure.DTOS.Command;
using Project.Ecommerce.Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Ecommerce.Domain.Interfaces
{
    public interface IProductService
    {
        Task<(IEnumerable<Products> products, int totalCount)> GetAllAsync();
        Task<(IEnumerable<Products> products, int totalCount)> GetByIdAsync(int id);
        Task<Products> CreateAsync(ProductCommand command);
        Task<Products> UpdateAsync(ProductCommand command, int id);
        Task DeleteAsync(int id);
    }
}
