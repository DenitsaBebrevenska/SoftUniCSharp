using Microsoft.AspNetCore.Mvc;
using MVCIntro.Models.Product;

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
}
