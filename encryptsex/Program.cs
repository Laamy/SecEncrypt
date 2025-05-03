namespace encryptsex;

using System;

using encryptsex.Config;

class Program
{
    static void Main(string[] args)
    {
        var save = SaveState.GetSave("save_name");

        var plyr = SteamID.Get("my_steam_id");
        var plyrStats = save.GetPlayerStats(plyr);

        plyrStats.GetUpgrades().Stamina = 5;
        plyrStats.Health = 100;

        plyrStats.GetInventory().GetSlot(1).ItemID = 1;

        save.Save();
    }
}
