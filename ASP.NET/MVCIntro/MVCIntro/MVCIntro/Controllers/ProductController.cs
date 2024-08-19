using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MVCIntro.Models.Product;
using System.Text;
using System.Text.Json;

namespace MVCIntro.Controllers;
public class ProductController : Controller
{
    private IEnumerable<ProductViewModel> _products =
        new List<ProductViewModel>()
        {
            new ()
            {
                Id = 1,
                Name = "Cheese",
                Price = 5.6m
            },
            new()
            {
                Id = 2,
                Name = "Coke",
                Price = 2.3m
            },
            new()
            {
                Id = 3,
                Name = "Flour",
                Price = 1m
            }
        };

    public IActionResult All()
    {
        return View(_products);
    }

    public IActionResult GetProductById(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);

        if (product == null)
        {
            return BadRequest();
        }

        return View(product);
    }

    public IActionResult GetAllAsJson()
    {

        var productsJson = Json(_products, new JsonSerializerOptions()
        {
            WriteIndented = true
        });

        return productsJson;
    }

    public IActionResult GetAllAsText()
    {
        return Content(GetProductString());
    }

    public IActionResult GetAllAsTextFile()
    {
        Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment; filename=products.txt");
        return File(Encoding.UTF8.GetBytes(GetProductString()), "text/plain");
    }

    private string GetProductString()
        => string
            .Join("\n", (_products
                .Select(pr => $"Product {pr.Id}: {pr.Name} - {pr.Price} lv.")
                .ToArray()));
}
