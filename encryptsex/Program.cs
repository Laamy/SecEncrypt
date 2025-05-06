namespace encryptsex;

using SecEncrypt;

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

        save.PurchaseItem(MarketItemType.DroneIndestructible);
        save.Save();
    }
}
