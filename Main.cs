using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Flow.Launcher.Plugin.Anytype.api;

namespace Flow.Launcher.Plugin.Anytype;

public class Anytype : IAsyncPlugin {
    private PluginInitContext _context;
    private readonly Regex _fourDigits = new(@"^\d{4}$");

    public async Task InitAsync(PluginInitContext context) {
        _context = context;
    }

    public async Task<List<Result>> QueryAsync(Query query, CancellationToken token) {
        await Task.Delay(300, token);

        if (!Api.IsAuthenticated) {
            if (_fourDigits.IsMatch(query.Search)) {
                return new List<Result> {
                    new() {
                        Title = "Send the 4-digit code",
                        Action = _ => {
                            Api.GetToken(query.Search);
                            return true;
                        },
                    },
                };
            }

            return new List<Result> {
                new() {
                    Title = "Not authenticated",
                    SubTitle = "Press Enter to authentication",
                    Action = _ => {
                        Api.DisplayCode();
                        return false;
                    },
                },
            };
        }

        var objects = await Api.GlobalSearch(query.Search);

        return objects
               .Select(v => new Result {
                   Title = string.IsNullOrEmpty(v.Name) ? v.Type : v.Name,
                   SubTitle = v.Snippet.Split('\n')[0],
                   Action = _ => {
                       _context.API.OpenAppUri($"anytype://object?objectId={v.ObjectId}&spaceId={v.SpaceId}");
                       return true;
                   },
               })
               .ToList();
    }
}
