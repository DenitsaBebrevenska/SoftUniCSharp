using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        private List<IStudent> _models;

        public StudentRepository()
        {
            _models = new List<IStudent>();
        }

        public IReadOnlyCollection<IStudent> Models => _models.AsReadOnly();
        public void AddModel(IStudent model)
            => _models.Add(model);

        public IStudent FindById(int id)
            => _models.FirstOrDefault(s => s.Id == id);

        public IStudent FindByName(string name)
        {
            string[] fullName = name.Split(' '); //string split remove empty entries? Likely not bcs it can remove a null name
            return _models.FirstOrDefault(s => s.FirstName == fullName[0] && s.LastName == fullName[1]);
        }
    }
}
