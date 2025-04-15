using Microsoft.AspNetCore.Mvc;
using TinyStore.Application.Services;

namespace TinyStore.Web.Controllers;

public class ProductController : Controller
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetAllProductsAsync();
        var categories = await _productService.GetAllCategoriesAsync();
        ViewBag.Categories = categories;
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
}