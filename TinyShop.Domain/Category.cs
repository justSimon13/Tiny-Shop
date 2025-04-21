using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TinyShop.Domain;

public class Category
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; }

    private readonly List<Product> _products = new();
    public IReadOnlyCollection<Product> Products => _products;

    public Category(string name)
    {
        Name = name;
    }
}