namespace SecEncrypt;

// i might make a use for this later..
public enum itemType
{
    drone,
    orb,
    cart,
    item_upgrade,
    player_upgrade,
    power_crystal,
    grenade,
    melee,
    healthPack,
    gun,
    tracker,
    mine,
    pocket_cart
}

// i might make a use for this later..
public enum emojiIcon
{
    drone_heal,
    drone_zero_gravity,
    drone_indestructible,
    drone_feather,
    drone_torque,
    drone_battery,
    orb_heal,
    orb_zero_gravity,
    orb_indestructible,
    orb_feather,
    orb_torque,
    orb_battery,
    orb_magnet,
    grenade_explosive,
    grenade_stun,
    weapon_baseball_bat,
    weapon_sledgehammer,
    weapon_frying_pan,
    weapon_sword,
    weapon_inflatable_hammer,
    item_health_pack_S,
    item_health_pack_M,
    item_health_pack_L,
    item_gun_handgun,
    item_gun_shotgun,
    item_gun_tranq,
    item_valuable_tracker,
    item_extraction_tracker,
    item_grenade_human,
    item_grenade_duct_taped,
    item_rubber_duck,
    item_mine_explosive,
    item_grenade_shockwave,
    item_mine_shockwave,
    item_mine_stun
}

// i might make a use for this later..
public enum itemSecretShopType
{
    none,
    shop_attic
}

// i might make a use for this later..
public enum itemVolume
{
    small,
    medium,
    large,
    large_wide,
    power_crystal,
    large_high,
    upgrade,
    healthPack,
    large_plus
}

// i might make a use for this later..
public class Item
{
    //private void OnValidate()
    //{
    //    if (SemiFunc.OnValidateCheck())
    //    {
    //        return;
    //    }
    //    this.itemAssetName = base.name;
    //    this.prefab = Resources.Load<GameObject>("Items/" + this.itemAssetName);
    //}

    public bool disabled;

    public string itemAssetName;
    public string itemName = "N/A";
    public string description;

    public itemType itemType;
    public emojiIcon emojiIcon;

    public itemVolume itemVolume;
    public itemSecretShopType itemSecretShopType;

    //public ColorPresets colorPreset;
    //public GameObject prefab;
    //public Value value;
    public int maxAmount = 1;
    public int maxAmountInShop = 1;
    public bool maxPurchase;
    public int maxPurchaseAmount = 1;
    //public Quaternion spawnRotationOffset;
    public bool physicalItem = true;
}