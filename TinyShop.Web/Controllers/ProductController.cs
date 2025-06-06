using Microsoft.AspNetCore.Mvc;
using TinyShop.Application.Services;

namespace TinyShop.Web.Controllers;

public class ProductController : Controller
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index(string? input, Guid? categoryId, decimal? minPrice, decimal? maxPrice)
    {
        var products = await _productService.GetAllProductsAsync();

        if (!string.IsNullOrWhiteSpace(input))
            products = products.Where(p => p.Name.Contains(input, StringComparison.OrdinalIgnoreCase)).ToList();

        if (categoryId.HasValue)
            products = products.Where(p => p.CategoryId == categoryId.Value).ToList();

        if (minPrice.HasValue)
        {
            products = products.Where(p => p.Price >= minPrice).ToList();
        }

        if (maxPrice.HasValue)
        {
            products = products.Where(p => p.Price <= maxPrice).ToList();
        }

        var categories = await _productService.GetAllCategoriesAsync();
        
        ViewBag.Categories = categories;
        ViewBag.Input = input;
        ViewBag.SelectedCategory = categoryId;
        ViewBag.MinPrice = minPrice;
        ViewBag.MaxPrice = maxPrice;

        return View(products);
    }


    public async Task<IActionResult> Details(Guid id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null) return NotFound();
        return View(product);
    }

    public async Task<IActionResult> Category(Guid id)
    {
        var products = await _productService.GetProductsByCategoryAsync(id);
        var categories = await _productService.GetAllCategoriesAsync();
        ViewBag.Categories = categories;
        return View("Index", products);
    }
    
    [HttpGet]
    public async Task<IActionResult> Suggestions(string term)
    {
        if (string.IsNullOrWhiteSpace(term))
            return Json(Array.Empty<object>());

        var products = await _productService.GetAllProductsAsync();
        var results = products
            .Where(p => p.Name.Contains(term, StringComparison.OrdinalIgnoreCase))
            .Select(p => new { p.Id, p.Name })
            .Take(5);

        return Json(results);
    }
}