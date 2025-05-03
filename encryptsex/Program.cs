namespace encryptsex;

using System;
using System.Diagnostics;
using encryptsex.Config;

class Program
{
    static void Main(string[] args)
    {
        SaveState save = null;
        foreach (var saveState in RepoGame.GetSaves())
        {
            if (saveState.Level == 1)
                save = saveState;
        }

        var plyr = SteamID.Get("76561198930262816");
        var plyrStats = save.GetPlayerStats(plyr);

        plyrStats.GetUpgrades().Stamina = 5;
        plyrStats.GetUpgrades().Health = (2000 - 100) / 20;
        plyrStats.Health = 2000;
        save.Level = 100;

        save.Save();
    }
}
