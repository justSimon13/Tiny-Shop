using TinyStore.Application;
using TinyStore.Infrastructure.Persistence;

namespace TinyStore.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public IProductRepository Products { get; }
    public ICategoryRepository Categories { get; }

    public UnitOfWork(AppDbContext context,
        IProductRepository productRepo,
        ICategoryRepository categoryRepo)
    {
        _context = context;
        Products = productRepo;
        Categories = categoryRepo;
    }

    public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
}