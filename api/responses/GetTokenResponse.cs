using System.Text.Json.Serialization;

namespace Flow.Launcher.Plugin.Anytype.api.responses;

public record GetTokenResponse {
    [JsonPropertyName("session_token")]
    public string SessionToken { get; init; }

    [JsonPropertyName("app_key")]
    public string AppKey { get; init; }
}
