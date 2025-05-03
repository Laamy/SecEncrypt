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

    /// <summary>
    /// The current level of the run + 1 (because they start at 0)
    /// </summary>
    public int Level
    {
        get => runStats.level + 1;
        set => runStats.level = value - 1;
    }

    /// <summary>
    /// The current currency of the run (div by 1000 cuz they use thousands)
    /// </summary>
    public int Currency
    {
        get => runStats.currency;
        set => runStats.currency = value;
    }

    /// <summary>
    /// The current lives of the run
    /// </summary>
    public int Lives
    {
        get => runStats.lives;
        set => runStats.lives = value;
    }

    /// <summary>
    /// The current charge of the charging station
    /// </summary>
    public int ChargingStationCharge
    {
        get => runStats.chargingStationCharge;
        set => runStats.chargingStationCharge = value;
    }

    /// <summary>
    /// The total charge of the charging station
    /// </summary>
    public int ChargingStationChargeTotal
    {
        get => runStats.chargingStationChargeTotal;
        set => runStats.chargingStationChargeTotal = value;
    }

    /// <summary>
    /// The total haul of the run (div by 1000 cuz they use thousands)
    /// </summary>
    public int TotalHaul
    {
        get => runStats.totalHaul;
        set => runStats.totalHaul = value;
    }

    /// <summary>
    /// The save level of the run (no clue what this is)
    /// </summary>
    public int SaveLevel
    {
        get => runStats.saveLevel;
        set => runStats.saveLevel = value;
    }
}
