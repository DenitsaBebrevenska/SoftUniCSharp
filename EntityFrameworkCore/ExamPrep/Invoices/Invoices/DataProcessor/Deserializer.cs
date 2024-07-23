using Invoices.Common;
using Invoices.Data.Models;
using Invoices.Data.Models.Enums;
using Invoices.DataProcessor.ImportDto;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;

namespace Invoices.DataProcessor
{
    using Invoices.Data;
    using System.ComponentModel.DataAnnotations;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";


        public static string ImportClients(InvoicesContext context, string xmlString)
        {
            string rootName = "Clients";
            var clientDtos = XmlHelper.Deserialize<ImportClientDto[]>(xmlString, rootName);
            var validClients = new HashSet<Client>();
            StringBuilder sb = new StringBuilder();

            foreach (var clientDto in clientDtos)
            {
                if (!IsValid(clientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Client client = new Client()
                {
                    Name = clientDto.Name,
                    NumberVat = clientDto.NumberVat
                };

                foreach (var addressDto in clientDto.Addresses)
                {
                    if (!IsValid(addressDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Address address = new Address()
                    {
                        StreetName = addressDto.StreetName,
                        StreetNumber = addressDto.StreetNumber,
                        PostCode = addressDto.PostCode,
                        City = addressDto.City,
                        Country = addressDto.Country
                    };

                    client.Addresses.Add(address);
                }

                validClients.Add(client);
                sb.AppendLine(string.Format(SuccessfullyImportedClients, client.Name));
            }

            context.AddRange(validClients);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }


        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
            var invoiceDtos = JsonConvert.DeserializeObject<ImportInvoiceDto[]>(jsonString);
            StringBuilder sb = new StringBuilder();
            var validInvoices = new HashSet<Invoice>();
            Client[] clients = context.Clients.ToArray();

            foreach (var invoiceDto in invoiceDtos)
            {
                DateTime issueDateResult;
                DateTime dueDateResult;
                CurrencyType currencyTypeResult;

                //if invalid issue or due date, due date is before issue date, invalid amount, currency type or client, continue
                if (!IsValid(invoiceDto) ||
                    clients.All(c => c.Id != invoiceDto.ClientId) ||
                    !DateTime.TryParse(invoiceDto.DueDate, CultureInfo.InvariantCulture, DateTimeStyles.None, out dueDateResult) ||
                    !DateTime.TryParse(invoiceDto.IssueDate, CultureInfo.InvariantCulture, DateTimeStyles.None, out issueDateResult) ||
                    dueDateResult < issueDateResult ||
                    (invoiceDto.CurrencyType > (int)CurrencyType.USD || invoiceDto.CurrencyType < (int)CurrencyType.BGN))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Invoice invoice = new Invoice()
                {
                    Number = invoiceDto.Number,
                    IssueDate = issueDateResult,
                    DueDate = dueDateResult,
                    Amount = invoiceDto.Amount,
                    CurrencyType = (CurrencyType)invoiceDto.CurrencyType
                };

                Client client = clients.First(c => c.Id == invoiceDto.ClientId);
                client.Invoices.Add(invoice);
                invoice.Client = client;
                validInvoices.Add(invoice);
                sb.AppendLine(string.Format(SuccessfullyImportedInvoices, invoice.Number));
            }

            context.Invoices.AddRange(validInvoices);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {


            throw new NotImplementedException();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
