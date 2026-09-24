using System.Collections.Generic;
using Lidarr.Plugin.Abstractions.Contracts;

namespace SlskdFriend.Settings;

public sealed class SlskdFriendSettingsProvider : ISettingsProvider
{
    public IReadOnlyCollection<SettingDefinition> Describe() => new[]
    {
        new SettingDefinition()
        {
            Key         = "Host",
            DisplayName = "Slskd host",
            Description = "Hostname of the Slskd instance (e.g. \"localhost\", \"slskd.server.com\")",
            DataType    = SettingDataType.String,
            IsRequired  = true,
        },
        new SettingDefinition()
        {
            Key             = "Port",
            DisplayName     = "Slskd port",
            Description     = "Port of the Slskd instance",
            DataType        = SettingDataType.Integer,
            IsRequired      = true,
            DefaultValue    = 5030
        },
        new SettingDefinition()
        {
            Key         = "ApiKey",
            DisplayName = "Slskd API key",
            Description = "User-configured API key for authentication. See: https://github.com/slskd/slskd/blob/master/docs/config.md",
            DataType    = SettingDataType.Password,
            IsRequired  = true,
        },
    };

    public IReadOnlyDictionary<string, object?> GetDefaults() => new Dictionary<string, object?>();

    public PluginValidationResult Validate(IDictionary<string, object?> settings)
    {
        List<string> errors = new();

        if (!settings.TryGetValue("Host", out object? host) || string.IsNullOrWhiteSpace(host as string))
            errors.Add("Host is required");

        if (!settings.TryGetValue("Port", out object? port) || (port as int? ?? 0) <= 0)
            errors.Add("Port is required");

        if (!settings.TryGetValue("ApiKey", out object? apiKey) || string.IsNullOrWhiteSpace(apiKey as string))
            errors.Add("API key is required");

        return errors.Count > 0
            ? PluginValidationResult.Failure([..errors])
            : PluginValidationResult.Success();
    }

    public PluginValidationResult Apply(IDictionary<string, object?> settings)
        => PluginValidationResult.Success();
}