using System;
using System.Threading;
using System.Linq;
using cAlgo.API;
using cAlgo.API.Indicators;
using cAlgo.API.Internals;
using cAlgo.API.Requests;
using cAlgo.Indicators;

namespace cAlgo
{
    [Robot(TimeZone = TimeZones.UTC, AccessRights = AccessRights.None)]
    public class NewcBot : Robot
    {
        [Parameter(DefaultValue = 0.1, MinValue = 0.01)]
        public double dpLots { get; set; }
        [Parameter(DefaultValue = 5, MinValue = 1)]
        public double dpStopLossPips { get; set; }
        [Parameter(DefaultValue = 10, MinValue = 1)]
        public double dpTakeProfitPips { get; set; }

        protected override void OnStart()
        {

        }

        protected override void OnBar()
        {
            Buy(dpLots, dpStopLossPips, dpTakeProfitPips);
            //Sell(dpLots, dpStopLossPips, dpTakeProfitPips);
        }

        protected override void OnStop()
        {
            // Put your deinitialization logic here
        }
        public void Buy(double dLot, double dStopLossPips, double dTakeProfitPips)
        {
            long volume = Symbol.QuantityToVolume(dpLots);
            if (!ExecuteMarketOrder(TradeType.Buy, this.Symbol, volume, "", dStopLossPips, dTakeProfitPips).IsSuccessful)
                Thread.Sleep(400);

        }
        public void Sell(double dLot, double dStopLossPips, double dTakeProfitPips)
        {
            long volume = Symbol.QuantityToVolume(dpLots);
            if (!ExecuteMarketOrder(TradeType.Sell, this.Symbol, volume, "", dStopLossPips, dTakeProfitPips).IsSuccessful)
                Thread.Sleep(400);

        }
    }
}
