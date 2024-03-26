using UniversityCompetition.Factories.Contracts;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Models.Subjects;

namespace UniversityCompetition.Factories
{
    public class SubjectFactory : IFactory<ISubject>
    {
        public ISubject Create(string type, params string[] details)
        {
            ISubject subject;

            switch (type)
            {
                case "EconomicalSubject":
                    return subject = new EconomicalSubject(details[0], int.Parse(details[1]));
                case "HumanitySubject":
                    return subject = new HumanitySubject(details[0], int.Parse(details[1]));
                case "TechnicalSubject":
                    return subject = new TechnicalSubject(details[0], int.Parse(details[1]));
                default:
                    return subject = null;
            }
        }
    }
}
