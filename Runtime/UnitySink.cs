using Serilog;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;
using UnityEngine;

namespace InfiniteCanvas.SerilogIntegration
{
	public class UnitySink : ILogEventSink
	{
		public void Emit(LogEvent logEvent)
		{
			var message = logEvent.RenderMessage();

			if (logEvent.Exception != null)
			{
				Debug.LogException(logEvent.Exception);
			}

			switch (logEvent.Level)
			{
				case LogEventLevel.Warning:
					Debug.LogWarning(message);
					break;
				case LogEventLevel.Error:
				case LogEventLevel.Fatal:
					Debug.LogError(message);
					break;
				case LogEventLevel.Verbose:
				case LogEventLevel.Debug:
				case LogEventLevel.Information:
				default:
					Debug.Log(message);
					break;
			}
		}
	}

	public static class UnitySinkExtensions
	{
		public static LoggerConfiguration Unity(this LoggerSinkConfiguration loggerConfiguration) => loggerConfiguration.Sink(new UnitySink());
	}
}