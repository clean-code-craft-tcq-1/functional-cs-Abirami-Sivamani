using System;
using System.Diagnostics;
using BatteryChecker;

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
        static bool batteryIsOk(BatteryMeasure measures)
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
            if (temperature < 0 || temperature > 45)
            {
                BatteryMeasure.EvaluateHighTemperature(temperature);
                BatteryMeasure.EvaluateLowTemperature(temperature);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks the state of charge.
        /// </summary>
        /// <param name="soc">The soc.</param>
        /// <returns></returns>
        static bool CheckStateOfCharge(float soc)
        {
            if (soc < 20 || soc > 80)
            {
                BatteryMeasure.EvaluateHighStateOfCharge(soc);
                BatteryMeasure.EvaluateLowStateOfCharge(soc);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks the charge rate.
        /// </summary>
        /// <param name="chargeRate">The charge rate.</param>
        /// <returns></returns>
        static bool CheckChargeRate(float chargeRate)
        {
            if (chargeRate > 0.8)
            {
                BatteryMeasure.EvaluateHighChargeRate(chargeRate);
                return false;
            }
            return true;
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
            PassedBatteryMeasure(batteryIsOk(new BatteryMeasure(25,70,0.7f)));
            FailedBatteryMeasure(batteryIsOk(new BatteryMeasure(60, 65, 0.6f)));
            FailedBatteryMeasure(batteryIsOk(new BatteryMeasure(-50, 85, 0.0f)));
            FailedBatteryMeasure(batteryIsOk(new BatteryMeasure(43, 10, 0.9f)));
            Console.WriteLine("All ok");
            return 0;
        }
    }
}

