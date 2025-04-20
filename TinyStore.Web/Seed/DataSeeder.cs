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
        var coffee = new Category("Kaffee");
        var tools = new Category("Tools");

        await _uow.Categories.AddAsync(electronics);
        await _uow.Categories.AddAsync(coffee);
        await _uow.Categories.AddAsync(tools);

        await _uow.Products.AddAsync(new Product("DELONGHI Dedica Style EC685.M Espressomaschine Silber Matt", 167.99m, electronics.Id, "/assets/images/delongi.webp"));
        await _uow.Products.AddAsync(new Product("Lavazza Crema e Aroma", 15.41m, coffee.Id, "/assets/images/kaffee.png"));
        await _uow.Products.AddAsync(new Product("DELONGHI DLSC059 Abschlagbehälter Edelstahl", 33.99m, tools.Id, "/assets/images/pixelboxx-mss-81060271.webp"));
        await _uow.Products.AddAsync(new Product("Barista Essentials Set", 129.00m, tools.Id, "/assets/images/full-set-barista.webp"));
        await _uow.Products.AddAsync(new Product("Tchibo Barista Caffè Crema", 12.99m, coffee.Id, "/assets/images/tchibo-barista-caffe-crema-bohne-bonen-1-kilo-kopen-kaufen-koffie-bonen-kaffee-kl.webp"));
        await _uow.Products.AddAsync(new Product("Sage The Barista Express", 529.00m, electronics.Id, "/assets/images/Sage-The-Barista-Express-Brushed-Stainless-Steel.jpg"));

        await _uow.SaveChangesAsync();
    }

}