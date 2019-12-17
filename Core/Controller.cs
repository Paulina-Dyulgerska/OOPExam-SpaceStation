using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private IRepository<IAstronaut> astronautRepository;
        private IRepository<IPlanet> planetRepository;
        private int exploredPlanetsCount;
        public Controller(IRepository<IAstronaut> astronautRepository, IRepository<IPlanet> planetRepository)
        {
            this.astronautRepository = astronautRepository;
            this.planetRepository = planetRepository;
        }

        public string AddAstronaut(string type, string astronautName)
        {

            //tova ne raboti prez Judge!!!
            //Type astronautType = Assembly.GetCallingAssembly()
            //    .GetTypes().FirstOrDefault(x => x.Name == type);
            //if (astronautType == null)
            //{
            //    throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            //}
            ////pravq si instanciq ot typa na astonauta:
            //IAstronaut instanceType = Activator.CreateInstance(astronautType, astronautName) as IAstronaut;
            ////ako sym namerila takyv class == astronautType, no toj NE e IAstronaut,
            ////shte mi ostane null instanciqta!
            //if (instanceType == null)
            //{
            //    throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            //}
            //this.astronautRepository.Add(instanceType);

            IAstronaut astronaut;
            switch (type)
            {
                case "Biologist": astronaut = new Biologist(astronautName); break;
                case "Geodesist": astronaut = new Geodesist(astronautName); break;
                case "Meteorologist": astronaut = new Meteorologist(astronautName); break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            this.astronautRepository.Add(astronaut);

            string result = string.Format(OutputMessages.AstronautAdded, type, astronautName);
            return result;
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            this.planetRepository.Add(planet);

            string result = string.Format(OutputMessages.PlanetAdded, planetName);

            return result;
        }

        public string ExplorePlanet(string planetName)
        {
            ICollection<IAstronaut> astronautsForMission = this.astronautRepository.Models.Where(x => x.Oxygen > 60).ToList();

            if (astronautsForMission.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            IPlanet planet = this.planetRepository.FindByName(planetName);

            IMission mission = new Mission();

            mission.Explore(planet, astronautsForMission);

            this.exploredPlanetsCount++;

            int deadAstronauts = astronautsForMission.Where(x => x.Oxygen == 0).Count();
            //int deadAstronauts = astronautsForMission.Count(x => !x.CanBreath);

            string result = string.Format(OutputMessages.PlanetExplored, planetName, deadAstronauts);

            return result;
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronaut = this.astronautRepository.FindByName(astronautName);

            if (astronaut == null)
            {
                string exceptionMessage = string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName);
                throw new InvalidOperationException(exceptionMessage);
            }

            this.astronautRepository.Remove(astronaut);

            string result = string.Format(OutputMessages.AstronautRetired, astronautName);

            return result;
        }

        public string Report()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{this.exploredPlanetsCount} planets were explored!");

            stringBuilder.AppendLine(this.astronautRepository.ToString().TrimEnd());

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
