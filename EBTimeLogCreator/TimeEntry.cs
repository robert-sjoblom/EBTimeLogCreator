using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace EBTimeLogCreator
{
    public class TimeEntry
    {
        public Dictionary<string, string> time_entry { get; } = new Dictionary<string, string>();

        public TimeEntry(string text)
        {
            time_entry.Add("description", text);
        }
    }
}