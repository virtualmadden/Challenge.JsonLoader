using System;
using Newtonsoft.Json;

namespace Challenge.JsonLoader.Models
{
    public class Followers
    {
        [JsonProperty("Id")]
        public Guid Id { get; set; }

        [JsonProperty("Followers")]
        public int FollowerCount { get; set; }
    }
}