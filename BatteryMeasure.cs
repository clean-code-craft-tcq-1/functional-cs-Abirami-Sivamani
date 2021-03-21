using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatteryManagement
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
        
        public static bool CrossedMaximum(BatteryMeasureFactors battery)
        {
              if(battery.MeasureValue > battery.MaximumLimit) {
                  PrintMaximumLimitMessage(battery.MeasureName, battery.MaximumLimit);
                  return false;
              }
            return true;
        }
        
        public static bool CrossedMinimum(BatteryMeasureFactors battery) 
        {
             if (battery.MeasureValue < battery.MinimumLimit) {
                 PrintMinimumLimitMessage(battery.MeasureName, battery.MinimumLimit);
                 return false;
             }
            return true;
        }
        
        static void PrintMaximumLimitMessage(string Measure, float MaximumLimit)
        {
            Console.WriteLine(Measure + " has exceeded its Maximum Limit of " + MaximumLimit);
            DisplayOutOfRangeMessage(Measure);
        }

        static void PrintMinimumLimitMessage(string Measure, float MaximumLimit)
        {
            Console.WriteLine(Measure + " has fall behind its Minimum Limit of " + MaximumLimit);
            DisplayOutOfRangeMessage(Measure);
        }

        static void DisplayOutOfRangeMessage(string Measure)
        {
            Console.WriteLine(Measure + " is out of range!");
        }
    }
    
    class BatteryMeasureFactors
    {
       public float MeasureValue, MaximumLimit, MinimumLimit;
       public string MeasureName;
        public BatteryMeasureFactors(string Name, float Value, float MaximumValue, float MinimumValue)
        {
            this.MeasureName = Name;
            this.MeasureValue = Value;
            this.MaximumLimit = MaximumValue;
            this.MinimumLimit = MinimumValue;
        }
    }
}

