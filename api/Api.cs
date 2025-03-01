using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Flow.Launcher.Plugin.Anytype.api.requests;
using Flow.Launcher.Plugin.Anytype.api.responses;

namespace Flow.Launcher.Plugin.Anytype.api;

public static class Api {
    private static readonly HttpClient Client = new();
    private static string? _challengeId = null;
    private static string? _token = null;
    private static string? _appKey = null;

    static Api() {
        Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public static bool IsAuthenticated => _token != null;

    private static async Task<string> Fetch(EndpointData endpointData, string? body = null) {
        if (_appKey != null) {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _appKey);
        } else {
            Client.DefaultRequestHeaders.Authorization = null;
        }
        var responseTask = endpointData.Method switch {
            "GET" => Client.GetAsync(endpointData.Url),
            "POST" => Client.PostAsync(endpointData.Url, new StringContent(body ?? "")),
            "DELETE" => Client.DeleteAsync(endpointData.Url),
            _ => throw new NotImplementedException(),
        };

        var response = await responseTask;
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    public static async Task DisplayCode() {
        var response = await Fetch(Constants.Endpoints.DisplayCode);
        var json = JsonSerializer.Deserialize<DisplayCodeResponse>(response);
        if (json?.ChallengeId != null) {
            _challengeId = json.ChallengeId;
        }
    }

    public static async Task GetToken(string code) {
        if (_challengeId == null) return;
        var response = await Fetch(Constants.Endpoints.GetToken(_challengeId, code));

        var json = JsonSerializer.Deserialize<GetTokenResponse>(response);
        if (json != null) {
            _token = json.SessionToken;
            _appKey = json.AppKey;
        }
    }

    public static async Task<List<GlobalSearchResponseItem>> GlobalSearch(string query) {
        var body = new GlobalSearchRequest { Query = query };
        var response = await Fetch(Constants.Endpoints.GlobalSearch(0, 25), JsonSerializer.Serialize(body));
        var json = JsonSerializer.Deserialize<GlobalSearchResponse>(response);
        return json?.Data ?? new List<GlobalSearchResponseItem>();
    }
}
