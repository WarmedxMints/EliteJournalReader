using System.Collections.Generic;
using System.Linq;

namespace EliteJournalReader.Events
{
    //When Written: when a player increases their access to an engineer
    //Parameters
    //�	Engineer: name of engineer
    //�	Rank: rank reached (when unlocked)
    //�	Progress: progress stage (Invited/Acquainted/Unlocked/Barred)
    public class EngineerProgressEvent : JournalEvent<EngineerProgressEvent.EngineerProgressEventArgs>
    {
        public EngineerProgressEvent() : base("EngineerProgress") { }

        public class EngineerProgressEventArgs : JournalEventArgs
        {
            public string Engineer { get; set; }
            public long EngineerID { get; set; }
            public int? Rank { get; set; }
            public string Progress { get; set; }

            public IReadOnlyList<EngineerProgressEventArgs> Engineers { get; set; }

            public override JournalEventArgs Clone()
            {
                var clone = (EngineerProgressEventArgs)base.Clone();
                clone.Engineers = Engineers?.Select(e => e.Clone()).Cast<EngineerProgressEventArgs>().ToArray();
                return clone;
            }
        }
    }
}
