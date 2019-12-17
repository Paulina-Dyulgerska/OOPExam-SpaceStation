using SpaceStation.Core.Contracts;
using SpaceStation.IO.Contracts;
using System;
using System.Linq;

namespace SpaceStation.Core
{
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IController controller;

        public Engine(IWriter writer, IReader reader, IController controller)
        {
            this.writer = writer;
            this.reader = reader;
            this.controller = controller;
        }
        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();

                var result = string.Empty;

                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "AddAstronaut")
                    {
                        var astronautType = input[1];
                        var astronautName = input[2];
                        result = controller.AddAstronaut(astronautType, astronautName);
                    }
                    else if (input[0] == "AddPlanet")
                    {
                        var planetName = input[1];
                        string[] planetItems = input.Skip(2).ToArray();
                        result = controller.AddPlanet(planetName, planetItems);
                    }
                    else if (input[0] == "RetireAstronaut")
                    {
                        var astronautName = input[1];
                        result = controller.RetireAstronaut(astronautName);
                    }
                    else if (input[0] == "ExplorePlanet")
                    {
                        var planetName = input[1];
                        result = controller.ExplorePlanet(planetName);
                    }
                    else if (input[0] == "Report")
                    {
                        result = controller.Report();
                    }

                    writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
