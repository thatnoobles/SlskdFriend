using System.Threading;
using System.Threading.Tasks;
using Lidarr.Plugin.Abstractions.Contracts;
using Lidarr.Plugin.Abstractions.Manifest;
using SlskdFriend.Indexer;
using SlskdFriend.Settings;

namespace SlskdFriend;

public class SlskdFriendPlugin : IPlugin
{
    public PluginManifest Manifest => new()
    {
        Id              = "slskd-friend",
        Name            = "Slskd Friend",
        Version         = "0.0.1",
        ApiVersion      = "1.x",
        MinHostVersion  = "2.12.0",
        EntryAssembly   = "Lidarr.Plugin.SlskdFriend.dll",
        Author          = "thatnoobles",
    };
    
    private IPluginContext? context;

    public ValueTask InitializeAsync(IPluginContext context, CancellationToken token = default)
    {
        this.context = context;
        return ValueTask.CompletedTask;
    }

    public ValueTask<IIndexer?> CreateIndexerAsync(CancellationToken token = default) =>
        ValueTask.FromResult<IIndexer?>(new SlskdIndexer());

    public ValueTask<IDownloadClient?> CreateDownloadClientAsync(CancellationToken token = default) =>
        ValueTask.FromResult<IDownloadClient?>(null);

    public ISettingsProvider SettingsProvider => new SlskdFriendSettingsProvider();

    public ValueTask DisposeAsync() => ValueTask.CompletedTask;
}
