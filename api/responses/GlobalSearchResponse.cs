using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Flow.Launcher.Plugin.Anytype.api.responses;

public record GlobalSearchResponse {
    [JsonPropertyName("data")]
    public List<GlobalSearchResponseItem> Data { get; init; }
}
