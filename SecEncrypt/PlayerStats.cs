namespace SecEncrypt;

using System;

public class PlayerStats
{
    private SaveState SaveState { get; set; }
    public SteamID Identifier { get; set; }

    public PlayerStats(SteamID id, SaveState state)
    {
        Identifier = id;
        SaveState = state;
    }

    public int ItemsPurchased
    {
        get => SaveState.Dictionaries.value.itemPurchased[Identifier.ID];
        set => SaveState.Dictionaries.value.itemPurchased[Identifier.ID] = value;
    }

    public int ItemsUpgradesPurchased
    {
        get => SaveState.Dictionaries.value.itemsUpgradesPurchased[Identifier.ID];
        set => SaveState.Dictionaries.value.itemsUpgradesPurchased[Identifier.ID] = value;
    }

    public int ItemsPurchasedTotal
    {
        get => SaveState.Dictionaries.value.itemsPurchasedTotal[Identifier.ID];
        set => SaveState.Dictionaries.value.itemsPurchasedTotal[Identifier.ID] = value;
    }

    /// <summary>
    /// The amount of remaining health the player has
    /// </summary>
    public int Health
    {
        get => SaveState.Dictionaries.value.playerHealth[Identifier.ID];
        set => SaveState.Dictionaries.value.playerHealth[Identifier.ID] = value;
    }

    /// <summary>
    /// If the player has a crown or not
    /// </summary>
    public int HasCrown
    {
        get => SaveState.Dictionaries.value.playerHasCrown[Identifier.ID];
        set => SaveState.Dictionaries.value.playerHasCrown[Identifier.ID] = value;
    }

    /// <summary>
    /// Get the players upgrade stats
    /// </summary>
    public PlayerUpgrades GetUpgrades() => new(Identifier, SaveState);

    /// <summary>
    /// Get the player inventory
    /// </summary>
    public PlayerInventory GetInventory() => new(Identifier, SaveState);

    #region Helpers

    /// <summary>
    /// Sets the players health to the maximum health (100 + (HealthUpgrades*20))
    /// </summary>
    public void Heal()
    {
        Health = GetMaxHealth();
    }

    /// <summary>
    /// Sets the players maximum health (100 + (HealthUpgrades*20))
    /// </summary>
    /// <param name="health"></param>
    public void SetMaxHealth(int health)
    {
        var neededUpgrades = (health - 100) / 20;
        GetUpgrades().Health = neededUpgrades;
    }

    /// <summary>
    /// Gets the players maximum health (100 + (HealthUpgrades*20))
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    public int GetMaxHealth()
    {
        return 100 + (GetUpgrades().Health * 20);
    }

    #endregion
}

public class PlayerSlot
{
    private SaveState SaveState { get; set; }
    public SteamID Identifier { get; set; }
    public int SlotId { get; set; }

    public PlayerSlot(SteamID id, SaveState state, int slotId)
    {
        Identifier = id;
        SaveState = state;
    }

    /// <summary>
    /// If the slot is taken or not (why did they do this bruh just use -1 or smth. in the future i might combine these)
    /// </summary>
    public int SpotTaken
    {
        get => SaveState.Dictionaries.value[$"playerInventorySpot{SlotId}Taken"][Identifier.ID];
        set => SaveState.Dictionaries.value[$"playerInventorySpot{SlotId}Taken"][Identifier.ID] = value;
    }

    /// <summary>
    /// The ID of the item in the slot
    /// </summary>
    public int ItemID
    {
        get => SaveState.Dictionaries.value[$"playerInventorySpot{SlotId}"][Identifier.ID];
        set => SaveState.Dictionaries.value[$"playerInventorySpot{SlotId}"][Identifier.ID] = value;
    }
}

public class PlayerInventory
{
    private SaveState SaveState { get; set; }
    public SteamID Identifier { get; set; }

    public PlayerInventory(SteamID id, SaveState state)
    {
        Identifier = id;
        SaveState = state;
    }

    /// <summary>
    /// Get the slot for an ID (1-3)
    /// </summary>
    public PlayerSlot GetSlot(int id)
    {
        if (id < 1 || id > 3)
            throw new ArgumentOutOfRangeException(nameof(id), "Slot ID must be between 1 and 3.");

        return new PlayerSlot(Identifier, SaveState, id);
    }
}

public class PlayerUpgrades
{
    private SaveState SaveState { get; set; }
    public SteamID Identifier { get; set; }

    public PlayerUpgrades(SteamID id, SaveState state)
    {
        Identifier = id;
        SaveState = state;
    }

    public int ItemBatteryUpgrades
    {
        get => SaveState.Dictionaries.value.itemBatteryUpgrades[Identifier.ID];
        set => SaveState.Dictionaries.value.itemBatteryUpgrades[Identifier.ID] = value;
    }

    /// <summary>
    /// The amount of health the player has extra (100 + (Health*20))
    /// </summary>
    public int Health
    {
        get => SaveState.Dictionaries.value.playerUpgradeHealth[Identifier.ID];
        set => SaveState.Dictionaries.value.playerUpgradeHealth[Identifier.ID] = value;
    }

    /// <summary>
    /// The amount of stamina the player has extra (100 + (Stamina*10))
    /// </summary>
    public int Stamina
    {
        get => SaveState.Dictionaries.value.playerUpgradeStamina[Identifier.ID];
        set => SaveState.Dictionaries.value.playerUpgradeStamina[Identifier.ID] = value;
    }

    /// <summary>
    /// The amount of extra jumps the player has (0 + ExtraJump)
    /// </summary>
    public int ExtraJump
    {
        get => SaveState.Dictionaries.value.playerUpgradeExtraJump[Identifier.ID];
        set => SaveState.Dictionaries.value.playerUpgradeExtraJump[Identifier.ID] = value;
    }

    /// <summary>
    /// The speed launch of the player
    /// </summary>
    public int Launch
    {
        get => SaveState.Dictionaries.value.playerUpgradeLaunch[Identifier.ID];
        set => SaveState.Dictionaries.value.playerUpgradeLaunch[Identifier.ID] = value;
    }

    public int MapPlayerCount
    {
        get => SaveState.Dictionaries.value.playerUpgradeMapPlayerCount[Identifier.ID];
        set => SaveState.Dictionaries.value.playerUpgradeMapPlayerCount[Identifier.ID] = value;
    }

    /// <summary>
    /// More speed for the player at the cost of stamina
    /// </summary>
    public int Speed
    {
        get => SaveState.Dictionaries.value.playerUpgradeSpeed[Identifier.ID];
        set => SaveState.Dictionaries.value.playerUpgradeSpeed[Identifier.ID] = value;
    }

    /// <summary>
    /// The amount of strength the player has (to pick up objects)
    /// </summary>
    public int Strength
    {
        get => SaveState.Dictionaries.value.playerUpgradeStrength[Identifier.ID];
        set => SaveState.Dictionaries.value.playerUpgradeStrength[Identifier.ID] = value;
    }

    /// <summary>
    /// The amount of throw the player has (to throw objects)
    /// </summary>
    public int Throw
    {
        get => SaveState.Dictionaries.value.playerUpgradeThrow[Identifier.ID];
        set => SaveState.Dictionaries.value.playerUpgradeThrow[Identifier.ID] = value;
    }

    /// <summary>
    /// The amount of range the player has (to grab objects)
    /// </summary>
    public int Range
    {
        get => SaveState.Dictionaries.value.playerUpgradeRange[Identifier.ID];
        set => SaveState.Dictionaries.value.playerUpgradeRange[Identifier.ID] = value;
    }
}