using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Utilities.Messages;
using System;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxyden;
        private const int oxygenTakenByOneBreath = 10;

        public Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.Bag = new Backpack();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }
                this.name = value;
            }
        }

        public double Oxygen
        {
            get => this.oxyden;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }
                this.oxyden = value;
            }
        }

        public bool CanBreath
        {
            get => this.Oxygen > 0;
        }

        public IBag Bag { get; }

        public virtual void Breath()
        {
            if (this.Oxygen >= oxygenTakenByOneBreath)
            {
                this.Oxygen -= oxygenTakenByOneBreath;
            }
            else
            {
                this.Oxygen = 0;
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Name: {this.Name}");
            stringBuilder.AppendLine($"Oxygen: {this.Oxygen}");
            stringBuilder.AppendLine($"Bag items: {this.Bag.ToString()}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
