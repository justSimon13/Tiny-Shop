using Microsoft.EntityFrameworkCore;
using TinyShop.Application;
using TinyShop.Domain;
using TinyShop.Infrastructure.Persistence;

namespace TinyShop.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public Task<Product?> GetByIdAsync(Guid id) =>
        _context.Products.Include(c => c.Category).FirstOrDefaultAsync(c => c.Id == id);

    public Task<IEnumerable<Product>> GetAllAsync() =>
        Task.FromResult<IEnumerable<Product>>(_context.Products.ToList());

    public async Task AddAsync(Product product)
    {
        _context.Products.Add(product);
        await Task.CompletedTask;
    }
}