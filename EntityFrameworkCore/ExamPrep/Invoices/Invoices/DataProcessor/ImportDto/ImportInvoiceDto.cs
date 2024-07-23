using Invoices.Common;
using System.ComponentModel.DataAnnotations;

namespace Invoices.DataProcessor.ImportDto;
public class ImportInvoiceDto
{
    [Required]
    [Range(TableConstraints.InvoiceMinNumber, TableConstraints.InvoiceMaxNumber)]
    public int Number { get; set; }

    [Required]
    public string IssueDate { get; set; }

    [Required]
    public string DueDate { get; set; }

    [Required]
    public decimal Amount { get; set; }

    [Required]
    public int CurrencyType { get; set; }

    [Required]
    public int ClientId { get; set; }
}
