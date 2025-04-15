using TinyStore.Domain;

namespace TinyStore.Application.Services;

public class ProductService
{
    private readonly IUnitOfWork _uow;

    public ProductService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public Task<IEnumerable<Product>> GetAllProductsAsync() =>
        _uow.Products.GetAllAsync();

    public async Task<Product?> GetProductByIdAsync(Guid id) =>
        await _uow.Products.GetByIdAsync(id);

    public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(Guid categoryId)
    {
        var all = await _uow.Products.GetAllAsync();
        return all.Where(p => p.CategoryId == categoryId);
    }

    public Task<IEnumerable<Category>> GetAllCategoriesAsync() =>
        _uow.Categories.GetAllAsync();
}