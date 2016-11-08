using System;
using Newtonsoft.Json;

namespace MT.JsonLoader.Models
{
    public class Character
    {
        [JsonProperty("Id")]
        public Guid Id { get; set; }

        [JsonProperty("CharacterRace")]
        public string CharacterRace { get; set; }

        [JsonProperty("CharacterClass")]
        public string CharacterClass { get; set; }
    }
}