using AcePointer.NameSorter.ConsoleApp.Models;
using System.Collections.Generic;

namespace AcePointer.NameSorter.ConsoleApp.Definators
{
    /// <summary>
    /// All File Operations definitions will go here
    /// </summary>
    public interface IFileService
    {
        List<Name> ReadFromGivenFile(string fileName);
        void WriteToGivenFile(List<Name> names,string fileName);
    }
}
