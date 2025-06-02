namespace Leasing.Models.DB
{
    public class LeasingInput
    {
        public int id {  get; set; }
        public decimal Harga { get; set; }
        public decimal DP { get; set; }
        public decimal CicilanPerBulan { get; set; }
        public int LamaBulan { get; set; }
    }
}
