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

        await _uow.Products.AddAsync(new Product("DELONGHI Dedica Style EC685.M Espressomaschine Silber Matt", 167.99m, electronics.Id, "/assets/images/delongi.webp"));
        await _uow.Products.AddAsync(new Product("Lavazza Crema e Aroma", 15.41m, electronics.Id, "/assets/images/kaffee.png"));
        await _uow.Products.AddAsync(new Product("DELONGHI DLSC059 Abschlagbehälter Edelstahl", 33.99m, books.Id, "/assets/images/pixelboxx-mss-81060271.webp"));

        await _uow.SaveChangesAsync();
    }
}