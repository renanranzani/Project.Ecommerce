using Project.Ecommerce.Domain.Interfaces;
using Project.Ecommerce.Infrastructure.DTOS.Command;
using Project.Ecommerce.Infrastructure.Entities;
using Project.Ecommerce.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Ecommerce.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<(IEnumerable<Products> products, int totalCount)> GetAllAsync()
        {
            var (produtsCollection, count) = await _productRepository.FindAsync().ConfigureAwait(false);
           
            return (produtsCollection, count);
        }

        public async Task<(IEnumerable<Products> products, int totalCount)> GetByIdAsync(int id)
        {
            var (produtsByIdCollection, count) = await _productRepository.FindByIdAsync(id).ConfigureAwait(false);

            return (produtsByIdCollection, count);
        }

        public async Task<Products> CreateAsync(ProductCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var addProducts = await _productRepository.CreateProduct(command).ConfigureAwait(false);

            return addProducts;
        }

        public async Task<Products> UpdateAsync(ProductCommand command, int id)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var getProductId = await _productRepository.UpdateProduct(command, id);

            return getProductId;
        }

        public async Task DeleteAsync(int id)
        {
            if (id == 0)
                throw new ArgumentNullException();

             await _productRepository.DeleteProduct(id);
        }
    }
}
