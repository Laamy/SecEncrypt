# SecEncrypt

allows you to get all the repo save files or get a save by name</br>
also lets you decrypt and view/modify the saves content in a clean manner with autocomplete</br>
also lets you re-encrypt and save the save files

example:
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
