using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteJournalReader.Events
{
    //When written: at startup, when loading from main menu
    //Parameters:
    //•	Inventory: array of cargo, with Name and Count for each
    public class CargoTransferEvent : JournalEvent<CargoTransferEvent.CargoTransferEventArgs>
    {
        public CargoTransferEvent() : base("CargoTransfer") { }

        public class CargoTransferEventArgs : JournalEventArgs
        {
            public List<CargoTransferInfo> Transfers { get; set; }
        }
    }
}
