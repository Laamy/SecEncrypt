namespace encryptsex.Config;

class RunStats
{
    //{
    //  "runStats": {
    //      "level": 0,
    //      "currency": 0,
    //      "lives": 3,
    //      "chargingStationCharge": 1,
    //      "chargingStationChargeTotal": 100,
    //      "totalHaul": 0,
    //      "save level": 0
    //  }
    //}

    private SaveState saveState;
    private dynamic runStats { get => saveState.Dictionaries.value.runStats; }

    public RunStats(SaveState saveState) => this.saveState = saveState;

    public int Level
    {
        get => runStats.level + 1;
        set => runStats.level = value - 1;
    }

    public int Currency
    {
        get => runStats.currency;
        set => runStats.currency = value;
    }

    public int Lives
    {
        get => runStats.lives;
        set => runStats.lives = value;
    }

    public int ChargingStationCharge
    {
        get => runStats.chargingStationCharge;
        set => runStats.chargingStationCharge = value;
    }

    public int ChargingStationChargeTotal
    {
        get => runStats.chargingStationChargeTotal;
        set => runStats.chargingStationChargeTotal = value;
    }

    public int TotalHaul
    {
        get => runStats.totalHaul;
        set => runStats.totalHaul = value;
    }

    public int SaveLevel
    {
        get => runStats.saveLevel;
        set => runStats.saveLevel = value;
    }
}
