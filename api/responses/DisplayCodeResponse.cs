using System.Text.Json.Serialization;

namespace Flow.Launcher.Plugin.Anytype.api.responses;

public record DisplayCodeResponse {
    [JsonPropertyName("challenge_id")]
    public string ChallengeId { get; init; }
}
