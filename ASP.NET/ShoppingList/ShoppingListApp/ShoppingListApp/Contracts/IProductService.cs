﻿using ShoppingListApp.Models;

namespace ShoppingListApp.Contracts;

public interface IProductService
{
	Task<IEnumerable<ProductViewModel>> GetProductsAsync();

	Task<ProductViewModel> GetProductAsync(int id);

	Task AddProductAsync(ProductViewModel model);

	Task UpdateProductAsync(ProductViewModel model);

	Task DeleteProductAsync(int id);
}
