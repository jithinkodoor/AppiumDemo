using AppiumDemoTest.Config;
using Microsoft.Extensions.Configuration;

public static class ConfigReader
{
    public static AppConfig Settings { get; private set; }

    static ConfigReader()
    {
        var args = Environment.GetCommandLineArgs();
        var cmdEnv = GetCommandLineArg(args, "--environment");
        var cmdPlatform = GetCommandLineArg(args, "--platform");
        var envVarEnv = Environment.GetEnvironmentVariable("ENVIRONMENT");

        var baseConfig = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("Config/appsettings.json", optional: false)
            .Build();

        var configEnv = baseConfig["Environment"];
        var configPlatform = baseConfig["Platform"];
        var environment = cmdEnv ?? envVarEnv ?? configEnv ?? "dev";
        var platform = cmdPlatform ?? configPlatform ?? "ios";
        Environment.SetEnvironmentVariable("PLATFORM", platform);

        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("Config/appsettings.json", optional: false)
            .AddJsonFile($"Config/appsettings.{platform}.{environment}.json", optional: true)
            .Build();

        Settings = config.GetSection("AppConfig").Get<AppConfig>() ?? new AppConfig();
    }

    private static string? GetCommandLineArg(string[] args, string key)
    {
        var index = Array.IndexOf(args, key);
        return (index >= 0 && index < args.Length - 1) ? args[index + 1] : null;
    }
}
