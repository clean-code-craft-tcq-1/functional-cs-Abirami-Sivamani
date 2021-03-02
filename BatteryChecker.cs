using System;
using System.Diagnostics;

class BatteryChecker
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
            DisplayOutOfRangeMessage("Charge Rate");
            return false;
        }
        return true;
    }
    
    ///<summary>
    ///Displays the Out of Range Message for all battery constrain
    ///<summary>
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
        ExpectFalse(batteryIsOk(50, 85, 0.0f));
        ExpectFalse(batteryIsOk(55, 10, 0.9f));
        Console.WriteLine("All ok");
        return 0;
    }
}
