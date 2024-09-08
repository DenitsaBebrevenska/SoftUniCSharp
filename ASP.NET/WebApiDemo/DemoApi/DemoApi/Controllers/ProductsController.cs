using DemoApi.Data;
using DemoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : Controller
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Gets a list of products.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///     GET api/products
    ///     {
    ///     }
    /// </remarks>
    /// <response code="200">Returns "OK" with list of products</response>

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _productService
            .GetAllAsync();

        return Ok(products);
    }

    /// <summary>
    /// Gets a product by Id.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///     GET api/products/{id}
    ///     {
    ///     }
    /// </remarks>
    /// <response code="200">Returns "OK" with the product</response>
    /// <response code="404">Returns "Not Found" when the product Id does not exist</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product = await _productService
            .GetByIdAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }


    /// <summary>
    /// Creates a product.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///     POST api/products
    ///     {
    ///        "name": "Chocolate bar",
    ///        "description: "Delicious"
    ///     }
    /// </remarks>
    /// <response code="201">Returns "Created" with the newly created product</response>
    [HttpPost]
    [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
    public async Task<IActionResult> PostProduct(Product product)
    {
        product = await _productService.AddAsync(product.Name, product.Description);

        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);

    }

    /// <summary>
    /// Edits a product.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///     PUT api/products/{id}
    ///     {
    ///        "name": "New Chocolate bar",
    ///        "description: "Extra Delicious"
    ///     }
    /// </remarks>
    /// <response code="204">Returns "No Content" </response>
    /// <response code="400">Returns "Bad Request" when an invalid request is sent. </response>
    /// <response code="404">Returns "Not Found" when product with the given Id does not exist</response>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Product), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PutProduct(int id, Product product)
    {
        if (id != product.Id)
        {
            return BadRequest();
        }

        if (await _productService.GetByIdAsync(id) == null)
        {
            return NotFound();
        }

        await _productService.UpdateAsync(id, product);

        return NoContent();
    }

    /// <summary>
    /// Edits partially a product.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///     PATCH api/products/{id}
    ///     {
    ///        "name": "New Chocolate bar vol.2"
    ///     }
    /// </remarks>
    /// <response code="204">Returns "No Content" </response>
    /// <response code="404">Returns "Not Found" when product with the given Id does not exist</response>
    [HttpPatch("{id}")]
    [ProducesResponseType(typeof(Product), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PatchProduct(int id, Product product)
    {
        if (await _productService.GetByIdAsync(id) == null)
        {
            return NotFound();
        }

        await _productService.PartialUpdateAsync(id, product);
        return NoContent();
    }


    //the task requires return
    //object which is not a standard practice for REST
    /// <summary>
    /// Deletes a product.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///     PUT api/products/{id}
    ///     {
    ///        
    ///     }
    /// </remarks>
    /// <response code="200">Returns "Ok" with the deleted product. </response>
    /// <response code="404">Returns "Not Found" when product with the given Id does not exist</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Product>> DeleteProduct(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        product = await _productService.DeleteAsync(id);
        return product;
    }
}
