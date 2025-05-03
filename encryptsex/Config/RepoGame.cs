namespace encryptsex.Config;

using System;
using System.Collections.Generic;

class RepoGame
{
    public static SaveState GetSave(string save_name) => SaveState.GetSave(save_name);

    public static SaveState[] GetSaves()
    {
        List<SaveState> saves = new();

        foreach (var dir in SaveState.RepoSaves.GetDirectories())
            saves.Add(GetSave(dir.Name));

        return saves.ToArray();
    }
}
