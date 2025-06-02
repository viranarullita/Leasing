using Leasing.Interface;
using Leasing.Models;
using Leasing.Models.DB;
using Leasing.Models.DTO;
using System;
using System.Collections.Generic;

namespace Leasing.Services
{
    public class LeasingService : ILeasingCalculator
    {
        private readonly ApplicationContext _context;

        public LeasingService(ApplicationContext context)
        {
            _context = context;
        }

        public LeasingResult HitungLeasing(LeasingRequestDTO r)
        {
            var totalAngsuran = r.Cicilan * r.LamaBulan;
            var sisaPembayaran = r.HargaMotor - r.DP;
            var profitLeasing = totalAngsuran - sisaPembayaran;
            var presentasiKeuntungan = (profitLeasing / sisaPembayaran) * 100;

            var (npv10, pv10) = HitungNPVDetail(0.10m, r.Cicilan, r.LamaBulan, sisaPembayaran);
            var (npv20, pv20) = HitungNPVDetail(0.20m, r.Cicilan, r.LamaBulan, sisaPembayaran);
            var (npv30, pv30) = HitungNPVDetail(0.30m, r.Cicilan, r.LamaBulan, sisaPembayaran);
            var (npv40, pv40) = HitungNPVDetail(0.40m, r.Cicilan, r.LamaBulan, sisaPembayaran);
            var (npv50, pv50) = HitungNPVDetail(0.50m, r.Cicilan, r.LamaBulan, sisaPembayaran);

            var (irr, irrMonthlyRate, irrDetailList) = HitungIRRDetail(sisaPembayaran, r.Cicilan, r.LamaBulan);

            var chartData = new List<NPVChartPoint>();
            for (decimal rate = 0.01m; rate <= 0.60m; rate += 0.01m)
            {
                var npv = HitungNPV(rate, r.Cicilan, r.LamaBulan, sisaPembayaran);
                chartData.Add(new NPVChartPoint
                {
                    Interest = rate,
                    NPV = npv
                });
            }

            return new LeasingResult
            {
                TotalAngsuran = totalAngsuran,
                SisaPembayaran = sisaPembayaran,
                ProfitLeasing = profitLeasing,
                PresentasiKeuntungan = presentasiKeuntungan,
                NPV10 = npv10,
                NPV20 = npv20,
                NPV30 = npv30,
                NPV40 = npv40,
                NPV50 = npv50,
                IRR = irr,
                IRRMonthlyRate = irrMonthlyRate,
                IRRDetails = irrDetailList,
                PV10List = pv10,
                PV20List = pv20,
                PV30List = pv30,
                PV40List = pv40,
                PV50List = pv50,
                NPVChartData = chartData
            };
        }

        private (decimal npv, List<PVDetail> details) HitungNPVDetail(decimal rateTahunan, decimal cicilan, int bulan, decimal initialInvestment)
        {
            decimal npv = -initialInvestment;
            var list = new List<PVDetail>();
            decimal rateBulanan = rateTahunan / 12;

            list.Add(new PVDetail
            {
                Bulan = 0,
                NilaiPV = -initialInvestment
            });

            for (int t = 1; t <= bulan; t++)
            {
                double rate = (double)(1 + rateBulanan);
                double pow = Math.Pow(rate, t);
                decimal pv = cicilan / (decimal)pow;

                npv += pv;

                list.Add(new PVDetail
                {
                    Bulan = t,
                    NilaiPV = decimal.Round(pv, 0)
                });
            }

            return (decimal.Round(npv, 0), list);
        }

        private decimal HitungNPV(decimal rateTahunan, decimal cicilan, int bulan, decimal initialInvestment)
        {
            decimal npv = -initialInvestment;
            decimal rateBulanan = rateTahunan / 12;

            for (int t = 1; t <= bulan; t++)
            {
                double rate = (double)(1 + rateBulanan);
                double pow = Math.Pow(rate, t);
                decimal pv = cicilan / (decimal)pow;

                npv += pv;
            }

            return decimal.Round(npv, 0);
        }

        private (decimal irr, decimal monthlyRate, List<IRRDetail>) HitungIRRDetail(decimal initialInvestment, decimal cicilan, int bulan)
        {
            decimal low = 0.0001m;
            decimal high = 1.0m;
            decimal mid = 0;
            decimal tolerance = 0.01m;
            int maxIterasi = 100;

            for (int i = 0; i < maxIterasi; i++)
            {
                mid = (low + high) / 2;
                decimal rateBulanan = mid;
                decimal npv = -initialInvestment;

                for (int t = 1; t <= bulan; t++)
                {
                    double pow = Math.Pow((double)(1 + rateBulanan), t);
                    decimal pv = cicilan / (decimal)pow;
                    npv += pv;
                }

                if (Math.Abs(npv) < tolerance)
                    break;

                if (npv > 0)
                    low = mid;
                else
                    high = mid;
            }

            var finalRate = mid;
            var detailList = new List<IRRDetail>();

            for (int i = 1; i <= bulan; i++)
            {
                double pow = Math.Pow((double)(1 + finalRate), i);
                decimal pv = cicilan / (decimal)pow;

                detailList.Add(new IRRDetail
                {
                    Bulan = i,
                    NilaiPV = Math.Round(pv, 0)
                });
            }

            return (Math.Round(finalRate * 12 * 100, 1), finalRate, detailList);
        }
    }
}