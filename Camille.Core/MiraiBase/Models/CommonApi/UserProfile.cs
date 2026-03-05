using Newtonsoft.Json;

namespace Camille.Core.MiraiBase.Models.CommonApi;

public class UserProfile
{
    [JsonProperty("nickname")] public string Nickname { get; set; } = string.Empty;

    [JsonProperty("email")] public string Email { get; set; } = string.Empty;

    [JsonProperty("age")] public int Age { get; set; }

    [JsonProperty("level")] public int Level { get; set; }

    [JsonProperty("sign")] public string Sign { get; set; } = string.Empty;

    [JsonProperty("sex")] public string Sex { get; set; } = "UNKNOWN"; // UNKNOWN, MALE, FEMALE
}