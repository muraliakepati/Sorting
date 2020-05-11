using AcePointer.NameSorter.ConsoleApp.Definators;
using AcePointer.NameSorter.ConsoleApp.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace AcePointer.NameSorter.ConsoleApp.Implementors
{
    public class NameCompareService : INameCompareService
    {
        private readonly IFileService _fileService;
        private readonly ISortService<Name> _sortService;
        private readonly ILogger<NameCompareService> _logger;
        public NameCompareService(IFileService fileService,ISortService<Name> sortService, ILogger<NameCompareService> logger)
        {
            _fileService = fileService;
            _sortService = sortService;
            _logger = logger;
        }

        /// <summary>
        /// Reads File from given input path
        /// Compares the data
        /// Writes data to output path
        /// </summary>
        /// <param name="inputFilePath"></param>
        /// <param name="outputFilePath"></param>
        public void CompareAndWriteToFile(string inputFilePath, string outputFilePath)
        {
            try
            {
                //Reads all the names from file
                List<Name> names = _fileService.ReadFromGivenFile(inputFilePath);

                if (names != null && names.Count > 0)
                {
                    //Sort all the names
                    names.Sort(_sortService);

                    //Writes sorted list to Console
                    names.ForEach(Name =>
                    {
                        Console.WriteLine(Name.FullName);
                    });

                    //Writes Sorted list to File
                    _fileService.WriteToGivenFile(names, outputFilePath);
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }
    }
}
