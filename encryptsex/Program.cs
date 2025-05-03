namespace encryptsex;

using System;

using encryptsex.Config;

class Program
{
    static void Main(string[] args)
    {
        SaveState save = null;
        foreach (var saveState in RepoGame.GetSaves())
        {
            if (saveState.RunStats.Level == 12)
                save = saveState;
        }

        var plyr = SteamID.Get("76561198930262816");
        var plyrStats = save.GetPlayer(plyr);

        Console.WriteLine(save.Root);
        save.RunStats.Level = 12; // so i know whhat file i modified

        save.itemsPurchasedTotal.GunTranq.Count = 3;
        save.itemsUpgradesPurchased.GunTranq.Count = 3;
        save.ItemsPurchased.GunTranq.Count = 3;
        save.itemBatteryUpgrades.GunTranq.Count = 3;

        save.Save();
    }
}
