using System.Text;

namespace DetailPrinter
{
    public class Manager : BaseEmployee
    {
        public Manager(string name, ICollection<string> documents) : base(name)
        {
            Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public override string GetDetails()
        {
            StringBuilder details = new StringBuilder();
            details.AppendLine(base.GetDetails());

            foreach (var document in Documents)
            {
                details.AppendLine(document);
            }

            return details.ToString().TrimEnd();
        }
    }
}
