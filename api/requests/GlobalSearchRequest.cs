using System.Text.Json.Serialization;

namespace Flow.Launcher.Plugin.Anytype.api.requests;

public record GlobalSearchRequest {
    [JsonPropertyName("query")]
    public string Query { get; init; }

    [JsonPropertyName("types")] public string[] Types { get; init; } = System.Array.Empty<string>();

    [JsonPropertyName("sort")] public SortOptions Sort { get; init; } = new();
}

public record SortOptions {
    [JsonPropertyName("direction")] public string Direction { get; init; } = "desc";

    [JsonPropertyName("timestamp")] public string Timestamp { get; init; } = "last_modified_date";
}
