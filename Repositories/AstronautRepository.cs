using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private List<IAstronaut> models;

        public AstronautRepository()
        {
            this.models = new List<IAstronaut>();
        }
        public IReadOnlyCollection<IAstronaut> Models => this.models.AsReadOnly();

        public void Add(IAstronaut model)
        {
            this.models.Add(model);
        }

        public IAstronaut FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IAstronaut model)
        {
            IAstronaut astronautToRemove = this.models.FirstOrDefault(x => x.Name == model.Name);

            if (astronautToRemove == null)
            {
                return false;
            }
            return this.models.Remove(astronautToRemove);
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Astronauts info:");
            foreach (var astronaut in this.Models)
            {
                stringBuilder.AppendLine(astronaut.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
