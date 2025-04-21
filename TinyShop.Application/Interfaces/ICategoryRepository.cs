using TinyShop.Domain;

namespace TinyShop.Application;

public interface ICategoryRepository
{
    Task<Category?> GetByIdAsync(Guid id);
    Task<IEnumerable<Category>> GetAllAsync();
    Task AddAsync(Category category);
}