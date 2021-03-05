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
            EvaluateBatteryMeasure(temperature, "Temperature");
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
            EvaluateBatteryMeasure(soc, "State of Charge");
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
            EvaluateBatteryMeasure(chargeRate, "Charge Rate");
            return false;
        }
        return true;
    }
    static void EvaluateBatteryMeasure(float MeasureValue, string Measure)
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

    class BatteryMeasure
    {
        public float Temperature, StateOfCharge, ChargeRate;
        public BatteryMeasure(float temperature, float soc, float chargeRate)
        {
            this.Temperature = temperature;
            this.StateOfCharge = soc;
            this.ChargeRate = chargeRate;
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

