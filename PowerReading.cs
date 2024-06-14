using System;
using System.Collections.Generic;

namespace TestEnergyProject;

public partial class PowerReading
{
    public long Id { get; set; }

    public string? DeviceId { get; set; }

    public DateTime? CreationTimestamp { get; set; }

    public DateTime? ReadingTimestamp { get; set; }

    public decimal? Watts { get; set; }

    public decimal? Amperage { get; set; }

    public decimal? Voltage { get; set; }

    public decimal? Frequency { get; set; }
}
