using System;
using Newtonsoft.Json;

namespace MT.JsonLoader.Models
{
    public class Person
    {
        [JsonProperty("Id")]
        public Guid Id { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("CharacterRace")]
        public string CharacterRace { get; set; }

        [JsonProperty("CharacterClass")]
        public string CharacterClass { get; set; }

        public Followers FollowerCount { get; set; }

        public string SourceFile { get; set; }
    }
}