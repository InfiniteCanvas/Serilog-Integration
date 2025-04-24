using System;
using System.Collections.Generic;
using Serilog.Events;
using UnityEngine;

namespace InfiniteCanvas.SerilogIntegration
{
    [CreateAssetMenu(fileName = "Log Settings", menuName = "Infinite Canvas/Log Settings", order = 0)]
    public class LogSettingOverrides : ScriptableObject
    {
        public LogEventLevel MinimumLevel = LogEventLevel.Information;
        public List<LogSetting> Settings;

        public override string ToString()
        {
            var builder = new System.Text.StringBuilder();
            builder.AppendLine($"{nameof(MinimumLevel)}: {MinimumLevel}");
            foreach (var setting in Settings)
                builder.AppendLine($"{setting.NameSpace}: {setting.LogLevel}");
            return builder.ToString();
        }

        [Serializable]
        public class LogSetting
        {
            public string NameSpace;
            public LogEventLevel LogLevel;
        }
    }
}