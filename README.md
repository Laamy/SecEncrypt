# SecEncrypt

**SecEncrypt** lets you manage and modify game save files easily with full autocomplete support.

## Features
- Load all saves or a specific save by name  
- Decrypt and modify save contents cleanly  
- Re-encrypt and save your changes  

## Example
```cs
SaveState save = RepoGame.GetSaves()[0]; // first save in the saves folder

var plyr = SteamID.Get("your_steam_id");
var plyrStats = save.GetPlayer(plyr); // get player stats via their SteamID

save.RunStats.Level = 12; // set the run's level easily

save.ItemsPurchasedTotal.GunTranq.Count = 1; // give yourself an upgraded tranq gun easily for example
save.ItemsUpgradesPurchased.GunTranq.Count = 1;
save.ItemsPurchased.GunTranq.Count = 1;
save.ItemBatteryUpgrades.GunTranq.Count = 1;

save.Save(); // save all your changes afterwards
```

## Tags

repo saves decryptor, R.E.P.O
