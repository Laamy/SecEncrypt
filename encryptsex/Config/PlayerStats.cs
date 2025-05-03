namespace encryptsex.Config;

using System;

class PlayerStats
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
        get => SaveState.RunStats.itemPurchased[Identifier.ID];
        set => SaveState.RunStats.itemPurchased[Identifier.ID] = value;
    }

    public int ItemsUpgradesPurchased
    {
        get => SaveState.RunStats.itemsUpgradesPurchased[Identifier.ID];
        set => SaveState.RunStats.itemsUpgradesPurchased[Identifier.ID] = value;
    }

    public int ItemsPurchasedTotal
    {
        get => SaveState.RunStats.itemsPurchasedTotal[Identifier.ID];
        set => SaveState.RunStats.itemsPurchasedTotal[Identifier.ID] = value;
    }

    /// <summary>
    /// The amount of remaining health the player has
    /// </summary>
    public int Health
    {
        get => SaveState.RunStats.playerHealth[Identifier.ID];
        set => SaveState.RunStats.playerHealth[Identifier.ID] = value;
    }

    /// <summary>
    /// If the player has a crown or not
    /// </summary>
    public int HasCrown
    {
        get => SaveState.RunStats.playerHasCrown[Identifier.ID];
        set => SaveState.RunStats.playerHasCrown[Identifier.ID] = value;
    }

    /// <summary>
    /// Get the players upgrade stats
    /// </summary>
    public PlayerUpgrades GetUpgrades() => new(Identifier, SaveState);

    /// <summary>
    /// Get the player inventory
    /// </summary>
    public PlayerInventory GetInventory() => new(Identifier, SaveState);
}
class PlayerSlot
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
        get => SaveState.RunStats[$"playerInventorySpot{SlotId}Taken"][Identifier.ID];
        set => SaveState.RunStats[$"playerInventorySpot{SlotId}Taken"][Identifier.ID] = value;
    }

    /// <summary>
    /// The ID of the item in the slot
    /// </summary>
    public int ItemID
    {
        get => SaveState.RunStats[$"playerInventorySpot{SlotId}"][Identifier.ID];
        set => SaveState.RunStats[$"playerInventorySpot{SlotId}"][Identifier.ID] = value;
    }
}
class PlayerInventory
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
class PlayerUpgrades
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
        get => SaveState.RunStats.itemBatteryUpgrades[Identifier.ID];
        set => SaveState.RunStats.itemBatteryUpgrades[Identifier.ID] = value;
    }

    /// <summary>
    /// The amount of health the player has extra (100 + (Health*20))
    /// </summary>
    public int Health
    {
        get => SaveState.RunStats.playerUpgradeHealth[Identifier.ID];
        set => SaveState.RunStats.playerUpgradeHealth[Identifier.ID] = value;
    }

    /// <summary>
    /// The amount of stamina the player has extra (100 + (Stamina*10))
    /// </summary>
    public int Stamina
    {
        get => SaveState.RunStats.playerUpgradeStamina[Identifier.ID];
        set => SaveState.RunStats.playerUpgradeStamina[Identifier.ID] = value;
    }

    /// <summary>
    /// The amount of extra jumps the player has (0 + ExtraJump)
    /// </summary>
    public int ExtraJump
    {
        get => SaveState.RunStats.playerUpgradeExtraJump[Identifier.ID];
        set => SaveState.RunStats.playerUpgradeExtraJump[Identifier.ID] = value;
    }

    /// <summary>
    /// The speed launch of the player
    /// </summary>
    public int Launch
    {
        get => SaveState.RunStats.playerUpgradeLaunch[Identifier.ID];
        set => SaveState.RunStats.playerUpgradeLaunch[Identifier.ID] = value;
    }

    public int MapPlayerCount
    {
        get => SaveState.RunStats.playerUpgradeMapPlayerCount[Identifier.ID];
        set => SaveState.RunStats.playerUpgradeMapPlayerCount[Identifier.ID] = value;
    }

    /// <summary>
    /// More speed for the player at the cost of stamina
    /// </summary>
    public int Speed
    {
        get => SaveState.RunStats.playerUpgradeSpeed[Identifier.ID];
        set => SaveState.RunStats.playerUpgradeSpeed[Identifier.ID] = value;
    }

    /// <summary>
    /// The amount of strength the player has (to pick up objects)
    /// </summary>
    public int Strength
    {
        get => SaveState.RunStats.playerUpgradeStrength[Identifier.ID];
        set => SaveState.RunStats.playerUpgradeStrength[Identifier.ID] = value;
    }

    /// <summary>
    /// The amount of throw the player has (to throw objects)
    /// </summary>
    public int Throw
    {
        get => SaveState.RunStats.playerUpgradeThrow[Identifier.ID];
        set => SaveState.RunStats.playerUpgradeThrow[Identifier.ID] = value;
    }

    /// <summary>
    /// The amount of range the player has (to grab objects)
    /// </summary>
    public int Range
    {
        get => SaveState.RunStats.playerUpgradeRange[Identifier.ID];
        set => SaveState.RunStats.playerUpgradeRange[Identifier.ID] = value;
    }
}