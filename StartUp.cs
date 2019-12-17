using SpaceStation.Core;
using SpaceStation.Core.Contracts;
using SpaceStation.IO;
using SpaceStation.IO.Contracts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Utilities.Messages;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SpaceStation
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //IReader reader = new FileReader("../../../Input.txt");
            //IWriter writer = new FileWriter("../../../Output.txt");

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IRepository<IAstronaut> astronautRepository = new AstronautRepository();
            IRepository<IPlanet> planetRepository = new PlanetRepository();
            
            IController controller = new Controller(astronautRepository, planetRepository);
            
            IEngine engine = new Engine(writer, reader, controller);
            
            engine.Run();

            //(reader as FileReader).Dispose();
        }
    }
}