using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Formatting.Json;

namespace Mia.Logging
{
    public class MiaJsonFormatter : ITextFormatter
    {
        private JsonValueFormatter valueFormatter;
        private Dictionary<string, int> map = new Dictionary<string, int>()
        {
            {"Error", 10},
            {"Warning", 20},
            {"Information", 30},
            {"Debug", 40},
            {"Verbose", 50}
        };

        private string LOGGER_PROP_KEY = "logger";

        public MiaJsonFormatter()
        {
            this.valueFormatter = new JsonValueFormatter(typeTagName: "$type");
        }

        public void Format(LogEvent logEvent, TextWriter output)
        {
            if (logEvent == null) throw new ArgumentNullException(nameof(logEvent));
            if (output == null) throw new ArgumentNullException(nameof(output));
            if (valueFormatter == null) throw new ArgumentNullException(nameof(valueFormatter));

            output.Write("{\"level\":");
            output.Write(map[logEvent.Level.ToString()]);

            output.Write(",\"time\":");
            output.Write(logEvent.Timestamp.ToUnixTimeMilliseconds());

            var logger = logEvent.Properties.ToList().Find(p => p.Key == LOGGER_PROP_KEY).Value;
            if (logger != null)
            {
                output.Write(',');
                JsonValueFormatter.WriteQuotedJsonString(LOGGER_PROP_KEY, output);
                output.Write(':');
                valueFormatter.Format(logger, output);
            }

            output.Write(",\"msg\":");
            JsonValueFormatter.WriteQuotedJsonString(logEvent.MessageTemplate.Text, output);

            foreach (var property in logEvent.Properties)
            {
                var name = property.Key;
                if (name == LOGGER_PROP_KEY)
                {
                    continue;
                }
                output.Write(',');
                JsonValueFormatter.WriteQuotedJsonString(name, output);
                output.Write(':');
                valueFormatter.Format(property.Value, output);
            }

            if (logEvent.Exception != null)
            {
                output.Write(",\"exception\":");
                JsonValueFormatter.WriteQuotedJsonString(logEvent.Exception.ToString(), output);
            }

            output.Write('}');
            output.WriteLine();
        }
    }
}