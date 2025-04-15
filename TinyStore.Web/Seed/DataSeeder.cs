using TinyStore.Application;
using TinyStore.Domain;

namespace TinyStore.Web.Seed;

public class DataSeeder
{
    private readonly IUnitOfWork _uow;

    public DataSeeder(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task SeedAsync()
    {
        var existing = await _uow.Categories.GetAllAsync();
        if (existing.Any()) return;

        var electronics = new Category("Elektronik");
        var books = new Category("Bücher");

        await _uow.Categories.AddAsync(electronics);
        await _uow.Categories.AddAsync(books);

        await _uow.Products.AddAsync(new Product("Smartphone X", 799, electronics.Id));
        await _uow.Products.AddAsync(new Product("Laptop Pro", 1299, electronics.Id));
        await _uow.Products.AddAsync(new Product("Roman Bestseller", 19.99m, books.Id));

        await _uow.SaveChangesAsync();
    }
}