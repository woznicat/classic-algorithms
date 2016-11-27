using System;
using System.Diagnostics.Tracing;
using System.IO;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging.Formatters;

namespace SortingAlgorithms
{
    public class TextFormatter : IEventTextFormatter
    {
        public EventLevel VerbosityThreshold { get; private set; }

        public void WriteEvent(EventEntry eventEntry, TextWriter writer)
        {

            // Write with summary format
            writer.WriteLine(
                "{0} : {1}, {2} : {3}",
                eventEntry.EventId,
                eventEntry.Schema.Level,
                eventEntry.ThreadId,
                eventEntry.FormattedMessage);

        }
    }
}