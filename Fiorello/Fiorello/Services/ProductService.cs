using Fiorello.Data;
using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Services
{
    public class ProductService : IProductService
    {


        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.Include(m => m.Images).ToListAsync();
        }

        public async Task<Product> GetByIdAsnyc(int? id)
        {
            return await _context.Products.FindAsync(id); ;
        }

        public async Task<Product> GetByIdWithImageAsnyc(int? id)
        {
           return await _context.Products.Include(m => m.Images).FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
