namespace encryptsex.Config;

class MarketItem
{
    private SaveState saveState;
    private string itemName;
    private string target;
    public MarketItem(SaveState saveState, string itemName, string target)
    {
        this.saveState = saveState;
        this.itemName = itemName;
        this.target = target;
    }
    
    public int Count
    {
        get => saveState.Dictionaries.value[target][$"Item {itemName}"];
        set => saveState.Dictionaries.value[target][$"Item {itemName}"] = value;
    }
}

//"itemsPurchased": {
//    "Item Cart Medium": 1,
//    "Item Cart Small": 0,
//    "Item Drone Battery": 0,
//    "Item Drone Feather": 0,
//    "Item Drone Indestructible": 0,
//    "Item Drone Torque": 0,
//    "Item Drone Zero Gravity": 0,
//    "Item Extraction Tracker": 0,
//    "Item Grenade Duct Taped": 0,
//    "Item Grenade Explosive": 0,
//    "Item Grenade Human": 0,
//    "Item Grenade Shockwave": 0,
//    "Item Grenade Stun": 0,
//    "Item Gun Handgun": 0,
//    "Item Gun Shotgun": 0,
//    "Item Gun Tranq": 0,
//    "Item Health Pack Large": 0,
//    "Item Health Pack Medium": 0,
//    "Item Health Pack Small": 0,
//    "Item Melee Baseball Bat": 0,
//    "Item Melee Frying Pan": 0,
//    "Item Melee Inflatable Hammer": 0,
//    "Item Melee Sledge Hammer": 0,
//    "Item Melee Sword": 0,
//    "Item Mine Explosive": 0,
//    "Item Mine Shockwave": 0,
//    "Item Mine Stun": 0,
//    "Item Orb Zero Gravity": 0,
//    "Item Power Crystal": 4,
//    "Item Rubber Duck": 0,
//    "Item Upgrade Map Player Count": 0,
//    "Item Upgrade Player Energy": 0,
//    "Item Upgrade Player Extra Jump": 0,
//    "Item Upgrade Player Grab Range": 0,
//    "Item Upgrade Player Grab Strength": 0,
//    "Item Upgrade Player Health": 0,
//    "Item Upgrade Player Sprint Speed": 0,
//    "Item Upgrade Player Tumble Launch": 0,
//    "Item Valuable Tracker": 0
//},

//TODO: item registry i can inherit so i dont gotta redefine items constantly..
class MarketPlace
{
    private SaveState saveState;
    private string target;
    public MarketPlace(SaveState saveState, string target)
    {
        this.saveState = saveState;
        this.target = target;
    }

    public MarketItem CartMedium => new(saveState, "Cart Medium", target);
    public MarketItem CartSmall => new(saveState, "Cart Small", target);

    public MarketItem ExtractionTracker => new(saveState, "Extraction Tracker", target); // no category? wwtf is thhe repo devs doing bruh
    public MarketItem ValuableTracker => new(saveState, "Valuable Tracker", target);

    public MarketItem DroneBattery => new(saveState, "Drone Battery", target);
    public MarketItem DroneFeather => new(saveState, "Drone Feather", target);
    public MarketItem DroneIndestructible => new(saveState, "Drone Indestructible", target);
    public MarketItem DroneTorque => new(saveState, "Drone Torque", target);
    public MarketItem DroneZeroGravity => new(saveState, "Drone Zero Gravity", target);

    public MarketItem GrenadeDuctTaped => new(saveState, "Grenade Duct Taped", target);
    public MarketItem GrenadeExplosive => new(saveState, "Grenade Explosive", target);
    public MarketItem GrenadeHuman => new(saveState, "Grenade Human", target);
    public MarketItem GrenadeShockwave => new(saveState, "Grenade Shockwave", target);
    public MarketItem GrenadeStun => new(saveState, "Grenade Stun", target);

    public MarketItem GunHandgun => new(saveState, "Gun Handgun", target);
    public MarketItem GunShotgun => new(saveState, "Gun Shotgun", target);
    public MarketItem GunTranq => new(saveState, "Gun Tranq", target);

    public MarketItem HealthPackLarge => new(saveState, "Health Pack Large", target);
    public MarketItem HealthPackMedium => new(saveState, "Health Pack Medium", target);
    public MarketItem HealthPackSmall => new(saveState, "Health Pack Small", target);

    public MarketItem MeleeBaseballBat => new(saveState, "Melee Baseball Bat", target);
    public MarketItem MeleeFryingPan => new(saveState, "Melee Frying Pan", target);
    public MarketItem MeleeInflatableHammer => new(saveState, "Melee Inflatable Hammer", target);
    public MarketItem MeleeSledgeHammer => new(saveState, "Melee Sledge Hammer", target);
    public MarketItem MeleeSword => new(saveState, "Melee Sword", target);

    public MarketItem MineExplosive => new(saveState, "Mine Explosive", target);
    public MarketItem MineShockwave => new(saveState, "Mine Shockwave", target);
    public MarketItem MineStun => new(saveState, "Mine Stun", target);

    public MarketItem OrbZeroGravity => new(saveState, "Orb Zero Gravity", target);
    public MarketItem PowerCrystal => new(saveState, "Power Crystal", target);
    public MarketItem RubberDuck => new(saveState, "Rubber Duck", target);

    public MarketItem UpgradeMapPlayerCount => new(saveState, "Upgrade Map Player Count", target);
    public MarketItem UpgradePlayerEnergy => new(saveState, "Upgrade Player Energy", target);
    public MarketItem UpgradePlayerExtraJump => new(saveState, "Upgrade Player Extra Jump", target);
    public MarketItem UpgradePlayerGrabRange => new(saveState, "Upgrade Player Grab Range", target);
    public MarketItem UpgradePlayerGrabStrength => new(saveState, "Upgrade Player Grab Strength", target);
    public MarketItem UpgradePlayerHealth => new(saveState, "Upgrade Player Health", target);
    public MarketItem UpgradePlayerSprintSpeed => new(saveState, "Upgrade Player Sprint Speed", target);
    public MarketItem UpgradePlayerTumbleLaunch => new(saveState, "Upgrade Player Tumble Launch", target);
}