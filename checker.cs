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
    
    static void EvaluateHighTemperature(float temperature)
    {
        if (temperature > 45)
            PrintMaximumLimitMessage("Temperature", 45);
    }

    static void EvaluateLowTemperature(float temperature)
    {
        if (temperature < 0)
            PrintMinimumLimitMessage("Temperature", 0);
    }

    static void EvaluateHighStateOfCharge(float soc)
    {
        if (soc > 80)
            PrintMaximumLimitMessage("State of Charge", 80);
    }

    static void EvaluateLowStateOfCharge(float soc)
    {
        if (soc < 20)
            PrintMinimumLimitMessage("State of Charge", 0);
    }

    static void EvaluateHighChargeRate(float chargeRate)
    {
        if (chargeRate > 0.8)
            PrintMaximumLimitMessage("Charge Rate", 0.8f);
    }

    static void PrintMaximumLimitMessage(string Constrain, float MaximumLimit)
    {
        Console.WriteLine(Constrain + " has exceeded its Maximum Limit of " + MaximumLimit);
    }

    static void PrintMinimumLimitMessage(string Constrain, float MaximumLimit)
    {
        Console.WriteLine(Constrain + " has fall behind its Minimum Limit of " + MaximumLimit);
    }

    static void DisplayOutOfRangeMessage(string Constrain)
    {
        Console.WriteLine(Constrain + " is out of range!");
    }
    static void ExpectTrue(bool expression) {
        if(!expression) {
            Console.WriteLine("Expected true, but got false");
            Environment.Exit(1);
        }
    }
    static void ExpectFalse(bool expression) {
        if(expression) {
            Console.WriteLine("Expected false, but got true");
            Environment.Exit(1);
        }
    }
    static int Main() {
        ExpectTrue(batteryIsOk(25, 70, 0.7f));
        ExpectFalse(batteryIsOk(60, 65, 0.6f));
        ExpectFalse(batteryIsOk(-50, 85, 0.0f));
        ExpectFalse(batteryIsOk(55, 10, 0.9f));
        Console.WriteLine("All ok");
        return 0;
    }
}
