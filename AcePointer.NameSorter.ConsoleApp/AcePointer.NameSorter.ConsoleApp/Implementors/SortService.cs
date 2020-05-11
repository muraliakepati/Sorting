using AcePointer.NameSorter.ConsoleApp.Definators;
using AcePointer.NameSorter.ConsoleApp.Models;

namespace AcePointer.NameSorter.ConsoleApp.Implementors
{
    /// <summary>
    /// Implementation for all Name operators will go here
    /// </summary>
    public class SortService : ISortService<Name>
    {
        public int Compare(Name firstNameToCompare, Name secondNameToCompare)
        {
            var lastName = firstNameToCompare.LastName.CompareTo(secondNameToCompare.LastName);

            if (lastName == 0)
                return firstNameToCompare.FirstName.CompareTo(secondNameToCompare.FirstName);

            return lastName;
        }
    }
}
