using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using TravelAgency.Common;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;

namespace TravelAgency.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            string rootName = "Customers";
            var customerDtos = XmlHelper.Deserialize<ImportCustomerDto[]>(xmlString, rootName);
            var validCustomers = new HashSet<Customer>();
            StringBuilder sb = new StringBuilder();
            var existingCustomers = context.Customers
                .AsNoTracking()
                .ToArray();

            foreach (var customerDto in customerDtos)
            {
                if (!IsValid(customerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool customerExistsInDb = existingCustomers
                    .Any(c => c.Email == customerDto.Email ||
                              c.FullName == customerDto.FullName ||
                              c.PhoneNumber == customerDto.PhoneNumber);
                bool customerExistsInXml = validCustomers
                    .Any(c => c.Email == customerDto.Email ||
                              c.FullName == customerDto.FullName ||
                              c.PhoneNumber == customerDto.PhoneNumber);
                if (customerExistsInDb || customerExistsInXml)
                {
                    sb.AppendLine(DuplicationDataMessage);
                    continue;
                }

                Customer customer = new Customer()
                {
                    FullName = customerDto.FullName,
                    Email = customerDto.Email,
                    PhoneNumber = customerDto.PhoneNumber
                };

                validCustomers.Add(customer);
                sb.AppendLine(string.Format(SuccessfullyImportedCustomer, customer.FullName));
            }

            context.Customers.AddRangeAsync(validCustomers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            var bookingDtos = JsonConvert.DeserializeObject<ImportBookingDto[]>(jsonString);
            StringBuilder sb = new StringBuilder();
            var validBookings = new HashSet<Booking>();
            var existingCustomers = context.Customers
                .ToArray();
            var existingPackages = context.TourPackages
                .ToArray();

            foreach (var bookingDto in bookingDtos)
            {
                if (!IsValid(bookingDto) ||
                    !DateTime
                        .TryParseExact(bookingDto.BookingDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                int customerId = existingCustomers
                    .First(c => c.FullName == bookingDto.CustomerName)
                    .Id;
                int packageId = existingPackages
                    .First(p => p.PackageName == bookingDto.TourPackageName)
                    .Id;

                Booking booking = new Booking()
                {
                    BookingDate = result,
                    CustomerId = customerId,
                    TourPackageId = packageId
                };

                validBookings.Add(booking);
                sb.AppendLine(string.Format(SuccessfullyImportedBooking, bookingDto.TourPackageName,
                    result.ToString("yyyy-MM-dd")));
            }
            context.Bookings.AddRange(validBookings);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                string currValidationMessage = validationResult.ErrorMessage; //?
            }

            return isValid;
        }
    }
}
