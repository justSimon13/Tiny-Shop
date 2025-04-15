using Microsoft.EntityFrameworkCore;
using TinyStore.Application;
using TinyStore.Domain;
using TinyStore.Infrastructure.Persistence;

namespace TinyStore.Infrastructure;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<Category?> GetByIdAsync(Guid id) =>
        _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);

    public Task<IEnumerable<Category>> GetAllAsync() =>
        Task.FromResult<IEnumerable<Category>>(_context.Categories.ToList());

    public async Task AddAsync(Category category)
    {
        _context.Categories.Add(category);
        await Task.CompletedTask;
    }
}