namespace encryptsex;

using System;
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

        Console.WriteLine(save.Root);

        save.Save();
    }
}
