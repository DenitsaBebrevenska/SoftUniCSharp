namespace UniversityCompetition.Models.Subjects
{
    public class EconomicalSubject : Subject
    {
        private const double EconomicalSubjectRate = 1;
        public EconomicalSubject(string name, int id)
            : base(name, id, EconomicalSubjectRate)
        {
        }
    }
}
