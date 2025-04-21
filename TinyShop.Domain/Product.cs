using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TinyShop.Domain;

public class Product
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    
    public string? ImageUrl { get; set; }

    public Guid CategoryId { get; private set; }
    public Category? Category { get; private set; }

    public Product(string name, decimal price, Guid categoryId, string? imageUrl)
    {
        Name = name;
        Price = price;
        CategoryId = categoryId;
        ImageUrl = imageUrl;
    }
}