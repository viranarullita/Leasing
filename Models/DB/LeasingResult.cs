using System.ComponentModel.DataAnnotations.Schema;

namespace Leasing.Models.DB
{
    public class LeasingResult
    {
        public int id { get; set; }
        public decimal TotalAngsuran { get; set; }
        public decimal SisaPembayaran { get; set; }
        public decimal ProfitLeasing { get; set; }
        public decimal PresentasiKeuntungan { get; set; }

        public decimal NPV10 { get; set; }
        public decimal NPV20 { get; set; }
        public decimal NPV30 { get; set; }
        public decimal NPV40 { get; set; }
        public decimal NPV50 { get; set; }

        public decimal IRR { get; set; }

        [NotMapped] public List<PVDetail> PV10List { get; set; }
        [NotMapped] public List<PVDetail> PV20List { get; set; }
        [NotMapped] public List<PVDetail> PV30List { get; set; }
        [NotMapped] public List<PVDetail> PV40List { get; set; }
        [NotMapped] public List<PVDetail> PV50List { get; set; }

        [NotMapped] public List<NPVChartPoint> NPVChartData { get; set; } = new();

        [NotMapped] public List<IRRDetail> IRRDetails { get; set; } = new();

        [NotMapped] public decimal IRRMonthlyRate { get; set; }
    }
}
