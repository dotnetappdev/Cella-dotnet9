using System;

namespace Cella.Models
{
    public class WeighBridgeEntry
    {
        public int Id { get; set; }
        public string LorryType { get; set; }
        public string LorryRegistration { get; set; }
        public decimal LoadWeight { get; set; }
        public DateTime EntryTime { get; set; } = DateTime.UtcNow;
        public string? Notes { get; set; }
    }
}
