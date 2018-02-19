using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Challenge.JsonLoader.Models;
using Newtonsoft.Json;

namespace Challenge.JsonLoader.Core
{
    public static class FileHandler
    {
        private const string LocalDir = @"..\..\Data\";

        /// <summary>
        ///     Loads the JSON files
        /// </summary>
        /// <param name="directory">A given directory.</param>
        /// <returns>A list of Persons</returns>
        public static IEnumerable<Person> LoadJsonFiles(string directory)
        {
            var files = new List<string>();

            try
            {
                files = GetFiles(directory ?? LocalDir);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("No json files found.");
            }

            var people = new List<Person>();

            foreach (var file in files)
                people.AddRange(LoadFile(file));

            return people;
        }

        /// <summary>
        ///     Gets the files in a given directory.
        /// </summary>
        /// <param name="directory">Given a directory.</param>
        /// <returns>A list of Files</returns>
        public static List<string> GetFiles(string directory)
        {
            return
                Directory.GetFiles(directory)
                    .Where(x => x.Contains(Path.GetExtension("json")))
                    .Select(Path.GetFileName)
                    .ToList();
        }

        /// <summary>
        ///     Loads the contents of the JSON file.
        /// </summary>
        /// <param name="fileName">The path of a file in the give directory.</param>
        /// <returns>A list of Persons</returns>
        public static List<Person> LoadFile(string fileName)
        {
            try
            {
                using (var reader = new StreamReader($"{LocalDir}{fileName}"))
                {
                    var content = reader.ReadToEnd();

                    var people = JsonConvert.DeserializeObject<List<Person>>(content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                    people.ForEach(x => { x.SourceFile = fileName; });

                    return people;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to load data in file.");
                return new List<Person>();
            }
        }
    }
}