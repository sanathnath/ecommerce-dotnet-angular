using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<AppProduct> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<AppProduct> GetProductByTitleAsync(string title)
        {
            return await _context.Products.SingleOrDefaultAsync(x => x.Title == title);
        }

        public async Task<IEnumerable<AppProduct>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(AppProduct product)
        {
            _context.Entry(product).State = EntityState.Modified;
        }
    }
}