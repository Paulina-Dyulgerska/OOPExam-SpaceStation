using System.Collections.Generic;
using System.Linq;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts)
            {
                while (astronaut.CanBreath && planet.Items.Count > 0)
                {
                    astronaut.Bag.Items.Add(planet.Items.ElementAt(0));
                    astronaut.Breath();
                    planet.Items.Remove(planet.Items.ElementAt(0));
                }

                if (planet.Items.Count == 0)
                {
                    break;
                }
            }
        }
    }
}
