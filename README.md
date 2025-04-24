# Serilog Integration

Adds a simple sink that logs to Unity's debug console and an override method that takes a ScriptableObject as settings.

## Installation

First, install `NuGet for Unity`

1. Open the Package Manager window in Unity
2. Click the + button and select "Add package from git URL"
3. Enter: `https://github.com/GlitchEnzo/NuGetForUnity.git?path=/src/NuGetForUnity`
   Then, install Serilog using `NuGet for Unity`.
   Now install this `Serilog Unity Integration`
4. Open the Package Manager window in Unity
5. Click the + button and select "Add package from git URL"
6. Enter: `https://github.com/InfiniteCanvas/Serilog-Integration.git`

## Log Settings

You can create a `LogSettingOverrides` asset and use it to configure log levels. It works like this:

```csharp
public LogEventLevel    MinimumLevel = LogEventLevel.Information; // this will set the global minimum log level
public List<LogSetting> Settings; // this contains all overrides for specific name spaces

// for example
setting.NameSpace = "InfiniteCanvas.InkIntegration.Parsers.Audio";
setting.LogLevel = LogEventLevel.Debug; // overrides and sets the minimum log level for that name space
```

You can use the asset like this:

```csharp
public LogSettingOverrides LogSettingOverrides;

var logger = new LoggerConfiguration().OverrideLogLevels(LogSettings)
                                      .WriteTo.Unity()
                                      .CreateLogger();
```

## License

This project is licensed under the MIT License - see the LICENSE file for details.