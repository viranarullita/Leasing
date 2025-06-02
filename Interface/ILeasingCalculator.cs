using Leasing.Models.DB;
using Leasing.Models.DTO;

namespace Leasing.Interface
{
    public interface ILeasingCalculator
    {
        LeasingResult HitungLeasing(LeasingRequestDTO request);
    }
}
