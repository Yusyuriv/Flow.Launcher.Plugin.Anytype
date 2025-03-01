using System.Text.Json.Serialization;

namespace Flow.Launcher.Plugin.Anytype.api.responses;

public record GlobalSearchResponseItem {
    [JsonPropertyName("id")]
    public string ObjectId { get; init; }

    [JsonPropertyName("space_id")]
    public string SpaceId { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("snippet")]
    public string Snippet { get; init; }

    [JsonPropertyName("type")]
    public string Type { get; init; }
}
