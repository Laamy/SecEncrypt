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

// for item and itemStatsBattery scroll to the very bottom

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

// these are most likely related to their prices in the shop but for now I wont even attempt implementing them
// if i do it'll just beasLargeMarketPlace

/*
"item": {
    "Item Cart Medium": 0,
    "Item Cart Small": 0,
    "Item Drone Battery": 0,
    "Item Drone Feather": 0,
    "Item Drone Indestructible": 0,
    "Item Drone Torque": 0,
    "Item Drone Zero Gravity": 0,
    "Item Extraction Tracker": 0,
    "Item Grenade Duct Taped": 0,
    "Item Grenade Explosive": 0,
    "Item Grenade Human": 0,
    "Item Grenade Shockwave": 0,
    "Item Grenade Stun": 0,
    "Item Gun Handgun": 0,
    "Item Gun Shotgun": 0,
    "Item Gun Tranq": 0,
    "Item Health Pack Large": 0,
    "Item Health Pack Medium": 0,
    "Item Health Pack Small": 0,
    "Item Melee Baseball Bat": 0,
    "Item Melee Frying Pan": 0,
    "Item Melee Inflatable Hammer": 0,
    "Item Melee Sledge Hammer": 0,
    "Item Melee Sword": 0,
    "Item Mine Explosive": 0,
    "Item Mine Shockwave": 0,
    "Item Mine Stun": 0,
    "Item Orb Zero Gravity": 0,
    "Item Power Crystal": 0,
    "Item Rubber Duck": 0,
    "Item Upgrade Map Player Count": 0,
    "Item Upgrade Player Energy": 0,
    "Item Upgrade Player Extra Jump": 0,
    "Item Upgrade Player Grab Range": 0,
    "Item Upgrade Player Grab Strength": 0,
    "Item Upgrade Player Health": 0,
    "Item Upgrade Player Sprint Speed": 0,
    "Item Upgrade Player Tumble Launch": 0,
    "Item Valuable Tracker": 0,
    "Item Cart Medium/1": 0,
    "Item Drone Zero Gravity/1": 6,
    "Item Upgrade Player Grab Strength/7": 34,
    "Item Extraction Tracker/1": 7,
    "Item Grenade Shockwave/1": 11,
    "Item Power Crystal/1": 28,
    "Item Upgrade Player Sprint Speed/1": 36,
    "Item Upgrade Player Grab Range/1": 33,
    "Item Upgrade Player Energy/1": 31,
    "Item Upgrade Player Energy/2": 31,
    "Item Power Crystal/2": 28,
    "Item Health Pack Medium/1": 17,
    "Item Upgrade Player Grab Strength/1": 34,
    "Item Power Crystal/3": 28,
    "Item Upgrade Player Grab Range/2": 33,
    "Item Health Pack Large/1": 16,
    "Item Grenade Shockwave/2": 11,
    "Item Health Pack Large/2": 16,
    "Item Mine Shockwave/2": 25,
    "Item Gun Tranq/1": 15,
    "Item Upgrade Player Health/1": 35,
    "Item Health Pack Large/3": 16,
    "Item Upgrade Player Sprint Speed/2": 36,
    "Item Upgrade Player Sprint Speed/3": 36,
    "Item Upgrade Player Energy/3": 31,
    "Item Health Pack Small/2": 18,
    "Item Grenade Human/1": 10,
    "Item Grenade Human/2": 10,
    "Item Grenade Human/3": 10,
    "Item Grenade Human/4": 10,
    "Item Grenade Human/5": 10,
    "Item Grenade Human/6": 10,
    "Item Upgrade Player Energy/4": 31,
    "Item Upgrade Player Grab Strength/2": 34,
    "Item Upgrade Player Energy/5": 31,
    "Item Upgrade Player Energy/6": 31,
    "Item Grenade Explosive/2": 9,
    "Item Grenade Explosive/3": 9,
    "Item Grenade Explosive/4": 9,
    "Item Grenade Explosive/5": 9,
    "Item Upgrade Player Grab Strength/8": 34,
    "Item Melee Baseball Bat/1": 19,
    "Item Cart Small/1": 1,
    "Item Cart Small/2": 1,
    "Item Drone Battery/1": 2,
    "Item Upgrade Map Player Count/1": 30,
    "Item Upgrade Player Extra Jump/1": 32,
    "Item Health Pack Medium/2": 17,
    "Item Upgrade Player Health/2": 35,
    "Item Health Pack Small/3": 18,
    "Item Upgrade Player Health/3": 35,
    "Item Upgrade Player Health/4": 35,
    "Item Upgrade Player Energy/7": 31,
    "Item Upgrade Player Sprint Speed/4": 36,
    "Item Upgrade Player Sprint Speed/5": 36,
    "Item Upgrade Player Grab Range/3": 33,
    "Item Upgrade Player Energy/8": 31,
    "Item Grenade Stun/3": 12,
    "Item Grenade Stun/4": 12,
    "Item Melee Inflatable Hammer/1": 21,
    "Item Upgrade Player Tumble Launch/1": 37,
    "Item Orb Zero Gravity/1": 27,
    "Item Melee Frying Pan/1": 20,
    "Item Health Pack Medium/3": 17,
    "Item Upgrade Player Grab Strength/3": 34,
    "Item Upgrade Player Grab Strength/4": 34,
    "Item Upgrade Player Tumble Launch/2": 37,
    "Item Upgrade Player Grab Range/4": 33,
    "Item Grenade Explosive/6": 9,
    "Item Grenade Duct Taped/3": 8,
    "Item Gun Handgun/1": 13,
    "Item Rubber Duck/1": 29,
    "Item Upgrade Player Grab Strength/5": 34,
    "Item Upgrade Player Grab Strength/6": 34,
    "Item Grenade Duct Taped/4": 8,
    "Item Mine Explosive/2": 24,
    "Item Mine Shockwave/3": 25,
    "Item Upgrade Player Energy/9": 31,
    "Item Health Pack Small/4": 18
},
"itemStatBattery": {
    "Item Cart Medium": 0,
    "Item Cart Small": 0,
    "Item Drone Battery": 0,
    "Item Drone Feather": 0,
    "Item Drone Indestructible": 0,
    "Item Drone Torque": 0,
    "Item Drone Zero Gravity": 0,
    "Item Extraction Tracker": 0,
    "Item Grenade Duct Taped": 0,
    "Item Grenade Explosive": 0,
    "Item Grenade Human": 0,
    "Item Grenade Shockwave": 0,
    "Item Grenade Stun": 0,
    "Item Gun Handgun": 0,
    "Item Gun Shotgun": 0,
    "Item Gun Tranq": 0,
    "Item Health Pack Large": 0,
    "Item Health Pack Medium": 0,
    "Item Health Pack Small": 0,
    "Item Melee Baseball Bat": 0,
    "Item Melee Frying Pan": 0,
    "Item Melee Inflatable Hammer": 0,
    "Item Melee Sledge Hammer": 0,
    "Item Melee Sword": 0,
    "Item Mine Explosive": 0,
    "Item Mine Shockwave": 0,
    "Item Mine Stun": 0,
    "Item Orb Zero Gravity": 0,
    "Item Power Crystal": 0,
    "Item Rubber Duck": 0,
    "Item Upgrade Map Player Count": 0,
    "Item Upgrade Player Energy": 0,
    "Item Upgrade Player Extra Jump": 0,
    "Item Upgrade Player Grab Range": 0,
    "Item Upgrade Player Grab Strength": 0,
    "Item Upgrade Player Health": 0,
    "Item Upgrade Player Sprint Speed": 0,
    "Item Upgrade Player Tumble Launch": 0,
    "Item Valuable Tracker": 0,
    "Item Cart Medium/1": 100,
    "Item Drone Zero Gravity/1": 99,
    "Item Upgrade Player Grab Strength/7": 100,
    "Item Extraction Tracker/1": 99,
    "Item Grenade Shockwave/1": 100,
    "Item Power Crystal/1": 100,
    "Item Upgrade Player Sprint Speed/1": 100,
    "Item Upgrade Player Grab Range/1": 100,
    "Item Upgrade Player Energy/1": 100,
    "Item Upgrade Player Energy/2": 100,
    "Item Power Crystal/2": 100,
    "Item Health Pack Medium/1": 100,
    "Item Upgrade Player Grab Strength/1": 100,
    "Item Power Crystal/3": 100,
    "Item Upgrade Player Grab Range/2": 100,
    "Item Health Pack Large/1": 100,
    "Item Grenade Shockwave/2": 100,
    "Item Health Pack Large/2": 100,
    "Item Mine Shockwave/2": 100,
    "Item Gun Tranq/1": 99,
    "Item Upgrade Player Health/1": 100,
    "Item Health Pack Large/3": 100,
    "Item Upgrade Player Sprint Speed/2": 100,
    "Item Upgrade Player Sprint Speed/3": 100,
    "Item Upgrade Player Energy/3": 100,
    "Item Health Pack Small/2": 100,
    "Item Grenade Human/1": 100,
    "Item Grenade Human/2": 100,
    "Item Grenade Human/3": 100,
    "Item Grenade Human/4": 100,
    "Item Grenade Human/5": 100,
    "Item Grenade Human/6": 100,
    "Item Upgrade Player Energy/4": 100,
    "Item Upgrade Player Grab Strength/2": 100,
    "Item Upgrade Player Energy/5": 100,
    "Item Upgrade Player Energy/6": 100,
    "Item Grenade Explosive/2": 100,
    "Item Grenade Explosive/3": 100,
    "Item Grenade Explosive/4": 100,
    "Item Grenade Explosive/5": 100,
    "Item Upgrade Player Grab Strength/8": 100,
    "Item Melee Baseball Bat/1": 99,
    "Item Cart Small/1": 100,
    "Item Cart Small/2": 100,
    "Item Drone Battery/1": 99,
    "Item Upgrade Map Player Count/1": 100,
    "Item Upgrade Player Extra Jump/1": 100,
    "Item Health Pack Medium/2": 100,
    "Item Upgrade Player Health/2": 100,
    "Item Health Pack Small/3": 100,
    "Item Upgrade Player Health/3": 100,
    "Item Upgrade Player Health/4": 100,
    "Item Upgrade Player Energy/7": 100,
    "Item Upgrade Player Sprint Speed/4": 100,
    "Item Upgrade Player Sprint Speed/5": 100,
    "Item Upgrade Player Grab Range/3": 100,
    "Item Upgrade Player Energy/8": 100,
    "Item Grenade Stun/3": 100,
    "Item Grenade Stun/4": 100,
    "Item Melee Inflatable Hammer/1": 99,
    "Item Upgrade Player Tumble Launch/1": 100,
    "Item Orb Zero Gravity/1": 99,
    "Item Melee Frying Pan/1": 99,
    "Item Health Pack Medium/3": 100,
    "Item Upgrade Player Grab Strength/3": 100,
    "Item Upgrade Player Grab Strength/4": 100,
    "Item Upgrade Player Tumble Launch/2": 100,
    "Item Upgrade Player Grab Range/4": 100,
    "Item Grenade Explosive/6": 100,
    "Item Grenade Duct Taped/3": 100,
    "Item Gun Handgun/1": 99,
    "Item Rubber Duck/1": 99,
    "Item Upgrade Player Grab Strength/5": 100,
    "Item Upgrade Player Grab Strength/6": 100,
    "Item Grenade Duct Taped/4": 100,
    "Item Mine Explosive/2": 100,
    "Item Mine Shockwave/3": 100,
    "Item Upgrade Player Energy/9": 100,
    "Item Health Pack Small/4": 100
}*/