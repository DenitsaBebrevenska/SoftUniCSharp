using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EDriveRent.Repositories
{
    public class RouteRepository : IRepository<IRoute>
    {
        private List<IRoute> _routes;

        public RouteRepository()
        {
            _routes = new List<IRoute>();
        }

        public IReadOnlyCollection<IRoute> GetAll() => _routes.AsReadOnly();
        public void AddModel(IRoute model)
            => _routes.Add(model);

        public bool RemoveById(string identifier)
            => _routes.Remove(_routes.FirstOrDefault(r => r.RouteId == int.Parse(identifier)));

        public IRoute FindById(string identifier)
            => _routes.FirstOrDefault(r => r.RouteId == int.Parse(identifier));


    }
}
