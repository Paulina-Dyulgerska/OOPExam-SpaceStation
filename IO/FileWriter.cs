using SpaceStation.IO.Contracts;
using System;
using System.Collections.Generic;
using System.IO;

namespace SpaceStation.IO
{
    public class FileWriter : IWriter, IDisposable
    {
        private readonly StreamWriter streamWriter;
        public FileWriter(string fileName)
        {
            this.streamWriter = new StreamWriter(fileName);
        }

        public void Dispose()
        {
            this.streamWriter.Dispose();
        }

        public void Write(string line)
        {
            this.streamWriter.Write(line);
            this.streamWriter.Flush(); //po-korektno e da zatvorq streama s IDisposable implementacia!
        }

        public void WriteLine(string line)
        {
            this.streamWriter.WriteLine(line);
            this.streamWriter.Flush(); //po-korektno e da zatvorq streama s IDisposable implementacia!
        }

        public void WriteLines(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                this.WriteLine(line);
            }
        }

        //public void Write(string str)
        //{
        //    File.WriteAllText("../../../Output.txt", str);
        //}
    }
}
