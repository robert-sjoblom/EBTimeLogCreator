using System.Collections.Generic;

namespace EBTimeLogCreator
{
    public class TimeEntry
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public Dictionary<string, string> time_entry { get; } = new Dictionary<string, string>();

        public TimeEntry(string text)
        {
            time_entry.Add("description", text);
            time_entry.Add("autostart", "true");
        }
    }
}