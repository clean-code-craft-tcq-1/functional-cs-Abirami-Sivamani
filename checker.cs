using System;
using System.Diagnostics;

class Checker
{
   /// <summary>
    /// Batteries the is ok.
    /// </summary>
    /// <param name="temperature">The temperature.</param>
    /// <param name="soc">The soc.</param>
    /// <param name="chargeRate">The charge rate.</param>
    /// <returns></returns>
    static bool batteryIsOk(float temperature, float soc, float chargeRate)
    {
        bool temperatureConstrainCheck = checkTemperature(temperature);
        bool chargeStateConstrainCheck = checkStateOfCharge(soc);
        bool chargeRateConstrainCheck = checkChargeRate(chargeRate);
        return (temperatureConstrainCheck && chargeStateConstrainCheck && chargeRateConstrainCheck);
    }

    /// <summary>
    /// Checks the temperature.
    /// </summary>
    /// <param name="temperature">The temperature.</param>
    /// <returns></returns>
    static bool checkTemperature(float temperature)
    {
        if (temperature < 0 || temperature > 45)
        {
            EvaluateHighTemperature(temperature);
            EvaluateLowTemperature(temperature);
            DisplayOutOfRangeMessage("Temperature");
            return false;
        }
        return true;
    }

    /// <summary>
    /// Checks the state of charge.
    /// </summary>
    /// <param name="soc">The soc.</param>
    /// <returns></returns>
    static bool checkStateOfCharge(float soc)
    {
        if (soc < 20 || soc > 80)
        {
            EvaluateHighStateOfCharge(soc);
            EvaluateLowStateOfCharge(soc);
            DisplayOutOfRangeMessage("State of Charge");
            return false;
        }
        return true;
    }

    /// <summary>
    /// Checks the charge rate.
    /// </summary>
    /// <param name="chargeRate">The charge rate.</param>
    /// <returns></returns>
    static bool checkChargeRate(float chargeRate)
    {
        if (chargeRate > 0.8)
        {
            EvaluateHighChargeRate(chargeRate);
            DisplayOutOfRangeMessage("Charge Rate");
            return false;
        }
        return true;
    }
    
     /// <summary>
    /// Evaluates the battery high temperature.
    /// </summary>
    /// <param name="temperature">The temperature.</param>
    static void EvaluateHighTemperature(float temperature)
    {
        if (temperature > 45)
            PrintMaximumLimitMessage("Temperature", 45);
    }

    /// <summary>
    /// Evaluates the battery low temperature.
    /// </summary>
    /// <param name="temperature">The temperature.</param>
    static void EvaluateLowTemperature(float temperature)
    {
        if (temperature < 0)
            PrintMinimumLimitMessage("Temperature", 0);
    }

    /// <summary>
    /// Evaluates the battery high state of charge.
    /// </summary>
    /// <param name="soc">The soc.</param>
    static void EvaluateHighStateOfCharge(float soc)
    {
        if (soc > 80)
            PrintMaximumLimitMessage("State of Charge", 80);
    }

    /// <summary>
    /// Evaluates the battery low state of charge.
    /// </summary>
    /// <param name="soc">The soc.</param>
    static void EvaluateLowStateOfCharge(float soc)
    {
        if (soc < 20)
            PrintMinimumLimitMessage("State of Charge", 0);
    }

    /// <summary>
    /// Evaluates the battery high charge rate.
    /// </summary>
    /// <param name="chargeRate">The charge rate.</param>
    static void EvaluateHighChargeRate(float chargeRate)
    {
        if (chargeRate > 0.8)
            PrintMaximumLimitMessage("Charge Rate", 0.8f);
    }

     /// <summary>
    /// Prints the battery constrain maximum limit reached message.
    /// </summary>
    static void PrintMaximumLimitMessage(string BatteryMeasure, float MaximumLimit)
    {
        Console.WriteLine(BatteryMeasure + " has exceeded its Maximum Limit of " + MaximumLimit);
    }

    /// <summary>
    /// Prints the battery constrain fall behinid minimum limit reached.
    /// </summary>
    static void PrintMinimumLimitMessage(string BatteryMeasure, float MinimumLimit)
    {
        Console.WriteLine(BatteryMeasure + " has fall behind its Minimum Limit of " + MinimumLimit);
    }

     /// <summary>
    /// Prints the battery constrain out of range message
    /// </summary>
    static void DisplayOutOfRangeMessage(string BatteryMeasure)
    {
        Console.WriteLine(BatteryMeasure + " is out of range!");
    }
   
    static void PassedBatteryMeasure(bool IsBatteryOk) {
        if(!IsBatteryOk) {
            Console.WriteLine("Expected true, but got false");
            Environment.Exit(1);
        }
    }
   
    static void FailedBatteryMeasure(bool IsBatteryOk) {
        if(IsBatteryOk) {
            Console.WriteLine("Expected false, but got true");
            Environment.Exit(1);
        }
    }
   
   ///<summary>
   ///Test cases to test the Battery Constrain Measure
   ///<summary>
    static int Main() {
        PassedBatteryMeasure(batteryIsOk(25, 70, 0.7f));
        FailedBatteryMeasure(batteryIsOk(60, 65, 0.6f));
        FailedBatteryMeasure(batteryIsOk(-50, 85, 0.0f));
        FailedBatteryMeasure(batteryIsOk(43, 10, 0.9f));
        Console.WriteLine("All ok");
        return 0;
    }
}
