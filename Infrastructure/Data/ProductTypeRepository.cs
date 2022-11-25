using Core.Entities;
using Core.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductTypeRepository(ApplicationDbContext context)
        {
            _context= context;
        }
        public async Task<IReadOnlyList<ProductType>> GetAllProductTypesAsync()
        {
            var productTypes = await _context.ProductTypes.ToListAsync();
            return productTypes;
        }

        public async Task<ProductType> GetProductTypeById(int id)
        {
            var productType = await _context.ProductTypes.FindAsync(id);
            return productType;
        }
    }
}
