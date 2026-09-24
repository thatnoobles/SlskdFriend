using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Lidarr.Plugin.Abstractions.Contracts;
using Lidarr.Plugin.Abstractions.Models;

namespace SlskdFriend.Indexer;

public sealed class SlskdIndexer : IIndexer
{
    private SlskdClient? client;

    public ValueTask<PluginValidationResult> InitializeAsync(CancellationToken cancellationToken = default)
    {
        client = new();
        return ValueTask.FromResult(PluginValidationResult.Success());
    }

    public ValueTask DisposeAsync() => ValueTask.CompletedTask;

    public ValueTask<StreamingAlbum?> GetAlbumAsync(string albumId, CancellationToken cancellationToken = default)
    {
        if (client == null)
            throw new Exception("Slskd client not initialized!");

        throw new NotImplementedException();
    }

    public ValueTask<IReadOnlyList<StreamingAlbum>> SearchAlbumsAsync(string query, CancellationToken cancellationToken = default)
    {
        if (client == null)
            throw new Exception("Slskd client not initialized!");

        throw new NotImplementedException();
    }

    public IAsyncEnumerable<StreamingAlbum> SearchAlbumsStreamAsync(string query, CancellationToken cancellationToken = default)
    {
        if (client == null)
            throw new Exception("Slskd client not initialized!");

        throw new NotImplementedException();
    }

    public ValueTask<IReadOnlyList<StreamingTrack>> SearchTracksAsync(string query, CancellationToken cancellationToken = default)
    {
        if (client == null)
            throw new Exception("Slskd client not initialized!");

        throw new NotImplementedException();
    }

    public IAsyncEnumerable<StreamingTrack> SearchTracksStreamAsync(string query, CancellationToken cancellationToken = default)
    {
        if (client == null)
            throw new Exception("Slskd client not initialized!");

        throw new NotImplementedException();
    }
}