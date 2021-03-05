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

        public static void EvaluateBatteryMeasure(float MeasureValue, string Measure)
        {
            if (MeasureValue > 45 && Measure == "Temperature")
                PrintMaximumLimitMessage(Measure, 45);
            if (MeasureValue < 0 && Measure == "Temperature")
                PrintMinimumLimitMessage(Measure, 0);
            if (MeasureValue > 80 && Measure == "State of Charge")
                PrintMaximumLimitMessage(Measure, 80);
            if (MeasureValue < 20 && Measure == "State of Charge")
                PrintMinimumLimitMessage(Measure, 0);
            if (MeasureValue > 0.8 && Measure == "Charge Rate")
                PrintMaximumLimitMessage(Measure, 0.8f);

            DisplayOutOfRangeMessage(Measure);
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
