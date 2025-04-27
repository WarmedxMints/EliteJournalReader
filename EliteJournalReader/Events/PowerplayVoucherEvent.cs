using System.Collections.Generic;

namespace EliteJournalReader.Events
{
    //When written: when receiving payment for powerplay combat
    //Parameters:
    //•	Power
    //•	Systems:[name,name]
    public class PowerplayVoucherEvent : JournalEvent<PowerplayVoucherEvent.PowerplayVoucherEventArgs>
    {
        public PowerplayVoucherEvent() : base("PowerplayVoucher") { }

        public class PowerplayVoucherEventArgs : JournalEventArgs
        {
            public string Power { get; set; }
            public IReadOnlyList<string> Systems { get; set; }
        }
    }
}
