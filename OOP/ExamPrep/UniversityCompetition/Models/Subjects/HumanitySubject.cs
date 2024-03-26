namespace UniversityCompetition.Models.Subjects
{
    public class HumanitySubject : Subject
    {
        private const double HumanitySubjectRate = 1.15;
        public HumanitySubject(string name, int id)
            : base(name, id, HumanitySubjectRate)
        {
        }
    }
}
