using Microsoft.EntityFrameworkCore;
using Project.Ecommerce.Infrastructure.Data;
using Project.Ecommerce.Infrastructure.DTOS.Command;
using Project.Ecommerce.Infrastructure.Entities;
using Project.Ecommerce.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Ecommerce.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbContextOptions<EcommerceContext> _context;

        public ProductRepository()
        {
            _context = new DbContextOptions<EcommerceContext>();
        }

        public async Task<(IEnumerable<Products> list, int totalCount)> FindAsync()
        {
            using (var data = new EcommerceContext(_context))
            {
                var query = (
                            from prod in data.Products
                            select new Products
                            {
                                Id = prod.Id,
                                Name = prod.Name,
                                Description = prod.Description,
                                Inventory = prod.Inventory,
                                Value = prod.Value,
                                Status = prod.Status,
                                Image = prod.Image
                            }
                        ).AsNoTracking();


                var totalCount = await query.CountAsync();
                var list = await query.ToListAsync();

                return (list, totalCount);
            }
        }

        public async Task<(IEnumerable<Products> list, int totalCount)> FindByIdAsync(int id)
        {
            using (var data = new EcommerceContext(_context))
            {
                var query = (
                            from prod in data.Products
                            where prod.Id == id
                            select new Products
                            {
                                Id = prod.Id,
                                Name = prod.Name,
                                Description = prod.Description,
                                Inventory = prod.Inventory,
                                Value = prod.Value,
                                Status = prod.Status,
                                Image = prod.Image
                            }
                        ).AsNoTracking();


                var totalCount = await query.CountAsync();
                var list = await query.ToListAsync();

                return (list, totalCount);
            }
        }

        public async Task<Products> CreateProduct(ProductCommand command)
        {
            Products prod = new Products();

            using (var data = new EcommerceContext(_context))
            {
                var query = (
                           from prods in data.Products
                           orderby prods.Id ascending
                           select new Products
                           {
                               Id = prods.Id
                           }
                       ).AsNoTracking()
                       .Skip(1);

                var returnId = await query.ToListAsync();

                returnId.ForEach(x => prod.Id = ++x.Id);

                prod.Name = command.Name;
                prod.Description = command.Description;
                prod.Inventory = command.Inventory;
                prod.Value = command.Value;
                prod.Status = true;
                prod.Image = command.Image;

                await data.SaveChangesAsync();
            }

            return prod;
        }

        public async Task<Products> UpdateProduct(ProductCommand command, int id)
        {
            if (id == 0)
                throw new ArgumentNullException("Id cannot be null!");

            Products prod = new Products();

            using (var data = new EcommerceContext(_context))
            {
                prod.Name = command.Name;
                prod.Description = command.Description;
                prod.Inventory = command.Inventory;
                prod.Value = command.Value;
                prod.Status = true;
                prod.Image = command.Image;
            }

            return prod;
        }

        public async Task DeleteProduct(int id)
        {
            Products prod = new Products();
            prod.Id = id;

            using (var data = new EcommerceContext(_context))
            {
                if (data != null)
                {
                    data.Products.Remove(prod);
                    data.SaveChanges();
                }
            }
        }
    }
}