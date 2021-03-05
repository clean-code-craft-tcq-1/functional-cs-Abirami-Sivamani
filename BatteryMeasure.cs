using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatteryChecker
{
    class BatteryMeasure
    {
        public float Temperature, StateOfCharge, ChargeRate;
        public BatteryMeasure(float temperature, float soc, float chargeRate)
        {
            this.Temperature = temperature;
            this.StateOfCharge = soc;
            this.ChargeRate = chargeRate;
        }

        public static void EvaluateHighTemperature(float temperature)
        {
            if (temperature > 45)
                PrintMaximumLimitMessage("Temperature", 45);
        }

        public static void EvaluateLowTemperature(float temperature)
        {
            if (temperature < 0)
                PrintMinimumLimitMessage("Temperature", 0);
        }

        public static void EvaluateHighStateOfCharge(float soc)
        {
            if (soc > 80)
                PrintMaximumLimitMessage("State of Charge", 80);
        }

        public static void EvaluateLowStateOfCharge(float soc)
        {
            if (soc < 20)
                PrintMinimumLimitMessage("State of Charge", 0);
        }

        public static void EvaluateHighChargeRate(float chargeRate)
        {
            if (chargeRate > 0.8)
                PrintMaximumLimitMessage("Charge Rate", 0.8f);
        }

        static void PrintMaximumLimitMessage(string Measure, float MaximumLimit)
        {
            Console.WriteLine(Measure + " has exceeded its Maximum Limit of " + MaximumLimit);
        }

        static void PrintMinimumLimitMessage(string Measure, float MaximumLimit)
        {
            Console.WriteLine(Measure + " has fall behind its Minimum Limit of " + MaximumLimit);
        }

        static void DisplayOutOfRangeMessage(string Measure)
        {
            Console.WriteLine(Measure + " is out of range!");
        }
    }
}
