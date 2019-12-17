using SpaceStation.IO.Contracts;
using System.IO;

namespace SpaceStation.IO
{
   public class FileReader : IReader
    {
        private readonly StreamReader streamReader;

        public FileReader(string fileName)
        {
            this.streamReader = new StreamReader(fileName);
        }

        public void Dispose()
        {
            this.streamReader.Dispose();
        }

        public string ReadLine()
        {
            var result = this.streamReader.ReadLine();
            //this.streamReader.Dispose(); //po-korektno e da zatvorq streama s IDisposable implementacia!
            return result;
        }

        //public string Read()
        //{
        //    return File.ReadAllText("../../../Input.txt");
        //}
    }
}
