using SpaceStation.Models.Planets;
using SpaceStation.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Repositories
{
    class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> models;
        public PlanetRepository()
        {
            this.models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => this.models.AsReadOnly();

        public void Add(IPlanet model)
        {
            this.models.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IPlanet model)
        {
            IPlanet planetToRemove = this.models.FirstOrDefault(x => x.Name == model.Name);

            if (planetToRemove == null)
            {
                return false;
            }
            return this.models.Remove(planetToRemove);
        }
    }
}
