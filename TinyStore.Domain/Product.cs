using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TinyStore.Domain;

public class Product
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    public Guid CategoryId { get; private set; }
    public Category? Category { get; private set; }

    public Product(string name, decimal price, Guid categoryId)
    {
        Name = name;
        Price = price;
        CategoryId = categoryId;
    }
}