namespace SecEncrypt;

using System;
using System.Collections.Generic;

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
    //public PlayerInventory GetInventory() => new(Identifier, SaveState);

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
        GetUpgrades()[PlayerUpgrade.Health].Count = neededUpgrades;
    }

    /// <summary>
    /// Gets the players maximum health (100 + (HealthUpgrades*20))
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    public int GetMaxHealth()
    {
        return 100 + (GetUpgrades()[PlayerUpgrade.Health].Count * 20);
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

    public PlayerSlot GetSlot(int id)
    {
        if (id < 1 || id > 3)
            throw new ArgumentOutOfRangeException(nameof(id), "Slot ID must be between 1 and 3.");

        return new PlayerSlot(Identifier, SaveState, id);
    }
}

public enum PlayerUpgrade
{
    Health,
    Stamina,
    ExtraJump,
    Launch,
    MapPlayerCount,
    Speed,
    Strength,
    Throw,
    Range
}

public class PlayerUpgradeItem
{
    private SaveState saveState;
    public SteamID Identifier;
    private string itemName;

    public PlayerUpgradeItem(SaveState saveState, SteamID identifier, string itemName)
    {
        this.saveState = saveState;
        Identifier = identifier;
        this.itemName = itemName;
    }

    public int Count
    {
        get => saveState.Dictionaries.value[itemName][Identifier.ID];
        set => saveState.Dictionaries.value[itemName][Identifier.ID] = value;
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

    private static readonly Dictionary<PlayerUpgrade, string> UpgradeKeys = new()
    {
        [PlayerUpgrade.Health] = "playerUpgradeHealth",
        [PlayerUpgrade.Stamina] = "playerUpgradeStamina",
        [PlayerUpgrade.ExtraJump] = "playerUpgradeExtraJump",
        [PlayerUpgrade.Launch] = "playerUpgradeLaunch",
        [PlayerUpgrade.MapPlayerCount] = "playerUpgradeMapPlayerCount",
        [PlayerUpgrade.Speed] = "playerUpgradeSpeed",
        [PlayerUpgrade.Strength] = "playerUpgradeStrength",
        [PlayerUpgrade.Throw] = "playerUpgradeThrow",
        [PlayerUpgrade.Range] = "playerUpgradeRange"
    };

    public PlayerUpgradeItem this[PlayerUpgrade upgrade] =>
        new(SaveState, Identifier, UpgradeKeys[upgrade]);

    public PlayerUpgradeItem Get(PlayerUpgrade itemType) => this[itemType];
}