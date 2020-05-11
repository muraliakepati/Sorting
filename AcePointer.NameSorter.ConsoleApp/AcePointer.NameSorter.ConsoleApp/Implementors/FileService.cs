using AcePointer.NameSorter.ConsoleApp.Definators;
using AcePointer.NameSorter.ConsoleApp.Models;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;

namespace AcePointer.NameSorter.ConsoleApp.Implementors
{
    public class FileService : IFileService
    {
        public List<Name> ReadFromGivenFile(string fileName)
        {
            List<Name> names = new List<Name>();
            string line = string.Empty;

            using (StreamReader reader = new StreamReader(fileName))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    names.Add(new Name(line));
                }
            }

            return names;
        }

        public void WriteToGivenFile(List<Name> names,string fileName)
        {
            using(StreamWriter writer=new StreamWriter(new IsolatedStorageFileStream(fileName, FileMode.Create)))
            {
                names.ForEach(name =>
                {
                    writer.WriteLine(name.FullName);
                });
            }
        }
    }
}
