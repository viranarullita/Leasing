using Microsoft.EntityFrameworkCore;

[Keyless]
public class NPVChartPoint
{
    public decimal Interest { get; set; }
    public decimal NPV { get; set; }
}
