namespace Flow.Launcher.Plugin.Anytype.api;

public static class Constants {
    public const string AppName = "flow_launcher_plugin";
    public const string BaseUrl = "http://localhost:31009/v1";
    public const string AnytypeNetwork = "N83gJpVd9MuNRZAuJLZ7LiMntTThhPc6DtzWWVjb1M3PouVU";
    public const string DownloadUrl = "https://download.anytype.io/";

    public static class Endpoints {
        public static EndpointData CreateObject(string spaceId) => new($"{BaseUrl}/spaces/{spaceId}/objects", "POST");

        public static EndpointData CreateSpace => new($"{BaseUrl}/spaces", "POST");

        public static EndpointData DeleteObject(string spaceId, string objectId) =>
            new($"{BaseUrl}/spaces/{spaceId}/objects/{objectId}", "DELETE");

        public static EndpointData DisplayCode => new($"{BaseUrl}/auth/display_code?app_name={AppName}", "POST");

        public static EndpointData GetExport(string spaceId, string objectId, string format) =>
            new($"{BaseUrl}/spaces/{spaceId}/objects/{objectId}/export/{format}", "GET");

        public static EndpointData GetMembers(string spaceId, int offset, int limit) =>
            new($"{BaseUrl}/spaces/{spaceId}/members?offset={offset}&limit={limit}", "GET");

        public static EndpointData GetObject(string spaceId, string objectId) =>
            new($"{BaseUrl}/spaces/{spaceId}/objects/{objectId}", "GET");

        public static EndpointData GetObjects(string spaceId, int offset, int limit) =>
            new($"{BaseUrl}/spaces/{spaceId}/objects?offset={offset}&limit={limit}", "GET");

        public static EndpointData GetSpaces(int offset, int limit) =>
            new($"{BaseUrl}/spaces?offset={offset}&limit={limit}", "GET");

        public static EndpointData GetTemplates(string spaceId, string typeId, int offset, int limit) =>
            new($"{BaseUrl}/spaces/{spaceId}/types/{typeId}/templates?offset={offset}&limit={limit}", "GET");

        public static EndpointData GetToken(string challengeId, string code) =>
            new($"{BaseUrl}/auth/token?challenge_id={challengeId}&code={code}", "POST");

        public static EndpointData GetTypes(string spaceId, int offset, int limit) =>
            new($"{BaseUrl}/spaces/{spaceId}/types?offset={offset}&limit={limit}", "GET");

        public static EndpointData GlobalSearch(int offset, int limit) =>
            new($"{BaseUrl}/search?offset={offset}&limit={limit}", "POST");

        public static EndpointData Search(string spaceId, int offset, int limit) =>
            new($"{BaseUrl}/spaces/{spaceId}/search?offset={offset}&limit={limit}", "POST");
    }
}
