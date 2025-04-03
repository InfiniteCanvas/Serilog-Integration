using Serilog;

namespace InfiniteCanvas.SerilogIntegration
{
	public static class LogSettingsExtensions
	{
		public static LoggerConfiguration OverrideLogLevels(this LoggerConfiguration loggerConfiguration, LogSettingOverrides logSettingOverrides)
		{
			loggerConfiguration.MinimumLevel.Is(logSettingOverrides.MinimumLevel);

			foreach (var logSetting in logSettingOverrides.Settings) loggerConfiguration.MinimumLevel.Override(logSetting.NameSpace, logSetting.LogLevel);

			return loggerConfiguration;
		}
	}
}