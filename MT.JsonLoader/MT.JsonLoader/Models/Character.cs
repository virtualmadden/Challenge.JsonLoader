using System;

namespace MT.JsonLoader.Models
{
    public class Character
    {
        public Guid Id { get; set; }
        public string CharacterRace { get; set; }
        public string CharacterClass { get; set; }
    }
}