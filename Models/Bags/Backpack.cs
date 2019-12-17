using System.Collections.Generic;

namespace SpaceStation.Models.Bags
{
    public class Backpack : IBag
    {
        private readonly ICollection<string> items;
        public Backpack()
        {
            this.items = new List<string>();
        }
        public ICollection<string> Items => this.items;

        public override string ToString()
        {
            if (this.items.Count > 0)
            {
                return string.Join(", ", this.Items);
            }

            return "none";
        }
    }
}