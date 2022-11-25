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
    public class ProductBrandRepository : IProductBrandRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductBrandRepository(ApplicationDbContext context)
        {
            _context= context;
        }
        public async Task<IReadOnlyList<ProductBrand>> GetAllProductBrandsAsync()
        {
            var productBrands = await _context.ProductBrands.ToListAsync();
            return productBrands;
        }

        public async Task<ProductBrand> GetProductBrandByIdAsync(int id)
        {
            var productBrand = await _context.ProductBrands.FindAsync(id);
            return productBrand;
        }
    }
}
