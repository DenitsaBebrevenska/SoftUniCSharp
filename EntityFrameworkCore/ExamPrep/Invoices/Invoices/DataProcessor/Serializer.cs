using Newtonsoft.Json;

namespace Invoices.DataProcessor
{
    using Data;

    public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {
            throw new NotImplementedException();
        }

        public static string ExportProductsWithMostClients(InvoicesContext context, int nameLength)
        {
            var products = context.Products
                .Where(p => p.ProductsClients.Count > 0 &&
                            p.ProductsClients.Any(c => c.Client.Name.Length >= nameLength))
                .Select(p => new
                {
                    p.Name,
                    Price = (double)p.Price, //made double to truncate zero at the end as expected by Judge
                    Category = p.CategoryType.ToString(),
                    Clients = p.ProductsClients
                        .Where(c => c.Client.Name.Length >= nameLength)
                        .Select(c => new
                        {
                            c.Client.Name,
                            c.Client.NumberVat
                        })
                        .OrderBy(c => c.Name)
                        .ToArray()
                })
                .OrderByDescending(p => p.Clients.Length)
                .ThenBy(p => p.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }
    }
}