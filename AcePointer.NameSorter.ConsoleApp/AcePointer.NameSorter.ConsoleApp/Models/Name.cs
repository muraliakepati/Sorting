using System;
using System.Linq;

namespace AcePointer.NameSorter.ConsoleApp.Models
{
    public class Name
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }

        public Name(string fullName)
        {
            if (IsNameValid(fullName))
            {
                FullName = fullName;
                (FirstName, LastName) = GetFirstAndLastNames(fullName);
            }
            else
            {
                throw new Exception($"Invalid Name: {fullName}");
            }
        }

        /// <summary>
        /// Checks whether the name is having one lastname and one to three firstnames
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        private bool IsNameValid(string fullName)
        {
            bool isValidName = false;

            if (string.IsNullOrEmpty(fullName))
                return isValidName;

            var names = fullName.Split(' ').ToList().Where(x => x.Trim().Length > 0).Select(x => x);
            if (names != null && names.Count() > 1 && names.Count() <= 4) 
                isValidName = true;

            return isValidName;
        }

        /// <summary>
        /// It return first and lastname from given fullname
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        private (string,string) GetFirstAndLastNames(string fullName)
        {
            int lastNameIndex = fullName.IndexOf(fullName.Trim().Split(' ').Last());

            string lastName = fullName.Trim().Split(' ').Last().Trim();
            string firstName = fullName.Substring(0, lastNameIndex).Trim();

            return (firstName, lastName);
        }
    }
}
