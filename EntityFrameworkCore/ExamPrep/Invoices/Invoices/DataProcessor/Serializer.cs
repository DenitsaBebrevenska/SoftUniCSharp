using Invoices.Common;
using Invoices.DataProcessor.ExportDto;
using Newtonsoft.Json;
using System.Globalization;

namespace Invoices.DataProcessor
{
    using Data;

    public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {
            var clients = context.Clients
                .Where(c => c.Invoices
                    .Count(i => i.IssueDate > date) > 0)
                .Select(c => new ExportClientDto()
                {
                    Name = c.Name,
                    NumberVat = c.NumberVat,
                    InvoicesCount = c.Invoices.Count(),
                    Invoices = c.Invoices
                        .OrderBy(i => i.IssueDate)
                        .ThenByDescending(i => i.DueDate)
                        .Select(i => new ExportInvoiceDto()
                        {
                            Number = i.Number,
                            Amount = (double)i.Amount,
                            DueDate = i.DueDate.ToString("d", CultureInfo.InvariantCulture),
                            CurrencyType = i.CurrencyType.ToString()
                        })
                    .ToArray()
                })
                .OrderByDescending(c => c.InvoicesCount)
                .ThenBy(c => c.Name)
                .ToArray();

            string rootName = "Clients";
            return XmlHelper.Serialize(clients, rootName);

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