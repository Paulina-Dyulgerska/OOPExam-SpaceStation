namespace SpaceStation.IO
{
    using SpaceStation.IO.Contracts;
    using System;
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
