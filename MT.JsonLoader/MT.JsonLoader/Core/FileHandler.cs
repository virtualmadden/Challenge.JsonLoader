using System.Collections.Generic;
using System.IO;
using System.Linq;
using MT.JsonLoader.Models;
using Newtonsoft.Json;

namespace MT.JsonLoader.Core
{
    public static class FileHandler
    {
        public static List<string> GetFiles(string directory)
        {
            return Directory.GetFiles(directory).Select(Path.GetFileName).ToList();
        }

        public static List<Person> LoadFile(string fileName)
        {
            using (var reader = new StreamReader($@"..\..\Data\{fileName}"))
            {
                var content = reader.ReadToEnd();

                var people = JsonConvert.DeserializeObject<List<Person>>(content, new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});

                people.ForEach(x => { x.SourceFile = fileName; });

                return people;
            }
        }
    }
}