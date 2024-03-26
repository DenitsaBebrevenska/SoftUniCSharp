namespace UniversityCompetition.Models.Subjects
{
    public class TechnicalSubject : Subject
    {
        private const double TechnicalSubjectRate = 1.3;
        public TechnicalSubject(string name, int id)
            : base(name, id, TechnicalSubjectRate)
        {
        }
    }
}
