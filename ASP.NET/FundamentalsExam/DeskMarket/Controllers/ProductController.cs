using DeskMarket.Data;
using DeskMarket.Data.Models;
using DeskMarket.Models.Category;
using DeskMarket.Models.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;
using static DeskMarket.Common.Constants.GlobalConstants;

namespace DeskMarket.Controllers;
/// <summary>
/// Controller for managing product-related operations such as viewing, adding, editing, deleting, and managing the cart.
/// Inherits from <see cref="BaseController"/>.
/// </summary>
public class ProductController(DeskMarketDbContext context) : BaseController
{
    /// <summary>
    /// Displays the list of products available.
    /// </summary>
    /// <returns>A view with the list of products.</returns>
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var products = await context.Products
            .Select(p => new ProductBriefDetailsViewModel()
            {
                Id = p.Id,
                ProductName = p.ProductName,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                IsSeller = p.SellerId == GetCurrentUserId(),
                HasBought = p.ProductsClients
                    .Any(pc => pc.ClientId == GetCurrentUserId())
            })
            .ToListAsync();

        return View(products);
    }

    /// <summary>
    /// Displays a form for adding a new product.
    /// </summary>
    /// <returns>A view with the product add form.</returns>
    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var model = new ProductAddFormViewModel();
        model.Categories = await GetCategoriesAsync();

        return View(model);
    }

    /// <summary>
    /// Processes the product add form and saves a new product to the database.
    /// </summary>
    /// <param name="model">The product add form model.</param>
    /// <returns>
    /// Redirects to the Product/Index page if successful, or re-displays the form if there are validation errors.
    /// </returns>
    [HttpPost]
    public async Task<IActionResult> Add(ProductAddFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Categories = await GetCategoriesAsync();

            return View(model);
        }

        var product = new Product()
        {
            ProductName = model.ProductName,
            Description = model.Description,
            ImageUrl = model.ImageUrl,
            Price = (decimal)model.Price,
            AddedOn = DateTime.ParseExact(
                model.AddedOn,
                DefaultDateTimeFormat,
                CultureInfo.InvariantCulture),
            CategoryId = model.CategoryId,
            SellerId = GetCurrentUserId()
        };

        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Displays the details of a specific product by its ID.
    /// </summary>
    /// <param name="id">The ID of the product.</param>
    /// <returns>A view with the product details.</returns>
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var item = await context
            .Products
            .Include(p => p.ProductsClients)
            .Include(product => product.Seller)
            .Include(product => product.Category)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (item == null)
        {
            return BadRequest();
        }

        var model = new ProductDetailsViewModel()
        {
            Id = item.Id,
            ProductName = item.ProductName,
            Description = item.Description,
            ImageUrl = item.ImageUrl,
            Price = item.Price,
            CategoryName = item.Category.Name,
            AddedOn = item.AddedOn
                .ToString(DefaultDateTimeFormat),
            Seller = item.Seller.UserName!,
            HasBought = item.ProductsClients
                .Any(pc => pc.ClientId == GetCurrentUserId())
        };

        return View(model);
    }

    /// <summary>
    /// Displays a form for editing a product by its ID.
    /// Only the seller of the product can edit it.
    /// </summary>
    /// <param name="id">The ID of the product to edit.</param>
    /// <returns>A view with the product edit form.</returns>
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var item = await context
            .Products
            .FirstOrDefaultAsync(p => p.Id == id);

        if (item == null)
        {
            return BadRequest();
        }

        if (item.SellerId != GetCurrentUserId())
        {
            return Unauthorized();
        }

        var model = new ProductEditFormViewModel()
        {
            Id = item.Id,
            ProductName = item.ProductName,
            Price = (double)item.Price,
            Description = item.Description,
            ImageUrl = item.ImageUrl,
            AddedOn = item.AddedOn
                .ToString(DefaultDateTimeFormat),
            CategoryId = item.CategoryId,
            SellerId = item.SellerId
        };

        model.Categories = await GetCategoriesAsync();

        return View(model);
    }

    /// <summary>
    /// Processes the product edit form and updates the product in the database.
    /// </summary>
    /// <param name="id">The ID of the product to edit.</param>
    /// <param name="model">The product edit form model.</param>
    /// <returns>
    /// Redirects to the product details page if successful, or re-displays the form if there are validation errors.
    /// </returns>
    [HttpPost]
    public async Task<IActionResult> Edit(int id, ProductEditFormViewModel model)
    {
        var item = await context.Products.FindAsync(id);

        if (model.Id != id || item == null)
        {
            return BadRequest();
        }

        if (item.SellerId != GetCurrentUserId())
        {
            return Unauthorized();
        }

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        item.ProductName = model.ProductName;
        item.Price = (decimal)model.Price;
        item.Description = model.Description;
        item.ImageUrl = model.ImageUrl;
        item.AddedOn = DateTime
            .ParseExact(
                model.AddedOn,
                DefaultDateTimeFormat,
                CultureInfo.InvariantCulture);
        item.CategoryId = model.CategoryId;

        await context.SaveChangesAsync();
        return RedirectToAction(nameof(Details), new { id = item.Id });
    }

    /// <summary>
    /// Displays a confirmation for deleting a product by its ID.
    /// Only the seller of the product can delete it.
    /// </summary>
    /// <param name="id">The ID of the product to delete.</param>
    /// <returns>A view with the product delete confirmation.</returns>
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await context
            .Products
            .Include(p => p.Seller)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (item == null)
        {
            return BadRequest();
        }

        if (item.SellerId != GetCurrentUserId())
        {
            return Unauthorized();
        }

        var model = new ProductDeleteViewModel()
        {
            Id = item.Id,
            ProductName = item.ProductName,
            Seller = item.Seller.UserName!,
            SellerId = item.SellerId
        };

        return View(model);
    }

    /// <summary>
    /// Processes the product delete confirmation and marks the product as deleted/ soft delete.
    /// </summary>
    /// <param name="id">The ID of the product to delete.</param>
    /// <param name="model">The product delete form model.</param>
    /// <returns>Redirects to the product index page.</returns>
    [HttpPost]
    public async Task<IActionResult> Delete(int id, ProductDeleteViewModel model)
    {
        var item = await context.Products.FindAsync(id);

        if (model.Id != id || item == null)
        {
            return BadRequest();
        }

        if (item.SellerId != GetCurrentUserId())
        {
            return Unauthorized();
        }

        item.IsDeleted = true;
        await context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Displays the current user's cart with the products they have added.
    /// </summary>
    /// <returns>A view with the user's cart.</returns>
    [HttpGet]
    public async Task<IActionResult> Cart()
    {
        var currentUser = GetCurrentUserId();

        var cartProducts = await context
            .ProductsClients
            .Where(pc => pc.ClientId == currentUser)
            .Select(p => new ProductCartViewModel()
            {
                Id = p.ProductId,
                ProductName = p.Product.ProductName,
                ImageUrl = p.Product.ImageUrl,
                Price = p.Product.Price
            })
            .ToListAsync();

        return View(cartProducts);
    }

    /// <summary>
    /// Adds a product to the current user's cart.
    /// </summary>
    /// <param name="id">The ID of the product to add to the cart.</param>
    /// <returns>Redirects to the cart page.</returns>
    [HttpPost]
    public async Task<IActionResult> AddToCart(int id)
    {
        var item = await context
            .Products
            .Include(p => p.ProductsClients)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (item == null)
        {
            return BadRequest();
        }

        var currentUserId = GetCurrentUserId();

        if (item.SellerId == currentUserId)
        {
            return BadRequest();
        }

        if (item.ProductsClients
            .Any(pc => pc.ClientId == currentUserId))
        {
            return RedirectToAction(nameof(Index));
        }

        await context.ProductsClients
            .AddAsync(new ProductClient()
            {
                ProductId = id,
                ClientId = currentUserId
            });
        await context.SaveChangesAsync();

        return RedirectToAction(nameof(Cart));
    }

    /// <summary>
    /// Removes a product from the current user's cart.
    /// </summary>
    /// <param name="id">The ID of the product to remove from the cart.</param>
    /// <returns>Redirects to the cart page.</returns>
    [HttpPost]
    public async Task<IActionResult> RemoveFromCart(int id)
    {
        var item = await context
            .Products
            .Include(p => p.ProductsClients)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (item == null)
        {
            return BadRequest();
        }

        var currentUserId = GetCurrentUserId();

        var productClient = await context
            .ProductsClients
            .FirstOrDefaultAsync(pc => pc.ClientId == currentUserId && pc.ProductId == item.Id);

        if (productClient == null)
        {
            return Unauthorized();
        }

        context.ProductsClients
            .Remove(productClient);

        await context.SaveChangesAsync();

        return RedirectToAction(nameof(Cart));
    }

    /// <summary>
    /// Retrieves the list of available categories for the product forms.
    /// </summary>
    /// <returns>A list of categories.</returns>
    private async Task<ICollection<CategoryFormViewModel>> GetCategoriesAsync()
    {
        return await context
            .Categories
            .Select(c => new CategoryFormViewModel()
            {
                Id = c.Id,
                Name = c.Name,
            })
            .ToListAsync();
    }

    /// <summary>
    /// Retrieves the current user's ID from the claims principal.
    /// </summary>
    /// <returns>The current user's ID.</returns>
    private string GetCurrentUserId()
        => User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
}
