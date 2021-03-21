using System;
using System.Diagnostics;

namespace BatteryManagement
{
    class Checker
    {
        /// <summary>
        /// Batteries the is ok.
        /// </summary>
        /// <param name="temperature">The temperature.</param>
        /// <param name="soc">The soc.</param>
        /// <param name="chargeRate">The charge rate.</param>
        /// <returns></returns>
        static bool IsBatteryOk(BatteryMeasure measures)
        {
            bool TemperatureMeasureCheck = CheckTemperature(measures.Temperature);
            bool ChargeStateMeasureCheck = CheckStateOfCharge(measures.StateOfCharge);
            bool ChargeRateMeasureCheck = CheckChargeRate(measures.ChargeRate);
            return (TemperatureMeasureCheck && ChargeStateMeasureCheck && ChargeRateMeasureCheck);
        }

        /// <summary>
        /// Checks the temperature.
        /// </summary>
        /// <param name="temperature">The temperature.</param>
        /// <returns></returns>
        static bool CheckTemperature(float temperature)
        {
            BatteryMeasureFactors measures = new BatteryMeasureFactors("Temperature", temperature, 45 ,0);
            return BatteryMeasure.CrossedMaximum(measures) && BatteryMeasure.CrossedMinimum(measures);
        }

        /// <summary>
        /// Checks the state of charge.
        /// </summary>
        /// <param name="soc">The soc.</param>
        /// <returns></returns>
        static bool CheckStateOfCharge(float soc)
        {
            BatteryMeasureFactors measures = new BatteryMeasureFactors("State of Charge", soc, 80, 20);
            return BatteryMeasure.CrossedMaximum(measures) && BatteryMeasure.CrossedMinimum(measures);
        }

        /// <summary>
        /// Checks the charge rate.
        /// </summary>
        /// <param name="chargeRate">The charge rate.</param>
        /// <returns></returns>
        static bool CheckChargeRate(float chargeRate)
        {
            BatteryMeasureFactors measures = new BatteryMeasureFactors("Charge Rate",chargeRate, 0.8f, 0.0f);
            return BatteryMeasure.CrossedMaximum(measures) && BatteryMeasure.CrossedMinimum(measures);
        }

        static void PassedBatteryMeasure(bool IsBatteryOk)
        {
            if (!IsBatteryOk)
            {
                Console.WriteLine("Expected true, but got false");
                Environment.Exit(1);
            }
        }
        static void FailedBatteryMeasure(bool IsBatteryOk)
        {
            if (IsBatteryOk)
            {
                Console.WriteLine("Expected false, but got true");
                Environment.Exit(1);
            }
        }

        static int Main()
        {
            PassedBatteryMeasure(IsBatteryOk(new BatteryMeasure(25,70,0.7f)));
            FailedBatteryMeasure(IsBatteryOk(new BatteryMeasure(60, 65, 0.6f)));
            FailedBatteryMeasure(IsBatteryOk(new BatteryMeasure(-50, 85, 0.2f)));
            FailedBatteryMeasure(IsBatteryOk(new BatteryMeasure(43, 10, 0.9f)));
            Console.WriteLine("All ok");
            return 0;
        }
    }
}

