using Humanizer;

namespace Leasing.Models.DB
{
    public class IRRDetail
    {
        public int ID { get; set; }
        public int Bulan { get; set; }
        public decimal NilaiPV { get; set; }
        public double PV => (double)NilaiPV;
    }
}
