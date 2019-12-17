namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const int initialOxygen = 70;
        private const int oxygenTakenByOneBreath = 5;

        public Biologist(string name) : base(name, initialOxygen)
        {
        }

        public override void Breath()
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
    }
}
