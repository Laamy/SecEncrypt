namespace SecEncrypt;
#pragma warning disable IDE0025

using System;
using System.IO;
using System.Text.RegularExpressions;

using Newtonsoft.Json;

public class SaveState
{
    /* 
    "playerNames": {
        "__type": "System.Collections.Generic.Dictionary`2[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]],mscorlib",
        "value": {
            "76561198930262816": "yeemi"
        }
    },
    "timePlayed": {
        "__type": "float",
        "value": 6032.528
    },
    "dateAndTime": {
        "__type": "string",
        "value": "2025-05-02"
    },
    "teamName": {
        "__type": "string",
        "value": "R.E.P.O."
    }*/

    public static readonly DirectoryInfo RepoSaves = new(Path.Combine(
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "AppData", "LocalLow"),
        "semiwork", "Repo", "saves"
    ));

    private string saveFileName = "REPO_SAVE_xxxx_xx_xx_xx_xx_xx";
    private DirectoryInfo saveDir;
    private FileInfo saveFile;
    private RepoFileStream saveFileStream;
    private dynamic _Root;

    #region InternalMumbo

    private void LoadContent()
    {
        if (!saveDir.Exists)
            throw new Exception("Save directory does not exist.");

        foreach (var file in saveDir.GetFiles())
        {
            if (!file.Name.Contains("BACKUP"))
            {
                saveFile = file;
                break;
            }
        }

        if (saveFile == null)
            throw new Exception("Failed to load save file.");

        saveFileStream = new RepoFileStream(saveFile);
        string decryptedState = saveFileStream.Read();
        if (RepoSaves == null)
            throw new Exception("Failed to load save file.");

        dynamic root = JsonConvert.DeserializeObject(decryptedState);
        _Root = root;

        if (root == null)
            throw new Exception("Failed to load save file.");
    }

    /// <summary>
    /// Get a save file by name
    /// </summary>
    public static SaveState GetSave(string saveName)
    {
        SaveState repoSave = new SaveState();
        repoSave.saveFileName = saveName;
        repoSave.saveDir = new DirectoryInfo(Path.Combine(RepoSaves.FullName, repoSave.saveFileName));
        repoSave.LoadContent();

        return repoSave;
    }

    /// <summary>
    /// Generate a new save file name based on the current time
    /// </summary>
    public static string GenerateSaveName()
    {
        return "REPO_SAVE_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
    }

    /// <summary>
    /// Create a shallow clone of a save without backup files
    /// </summary>
    public SaveState Clone()
    {
        var newSave = saveFileName;
        DirectoryInfo newSaveDir;

        while (true)
        {
            Console.WriteLine("old " + newSave);

            var match = Regex.Match(newSave, @"^(REPO_SAVE_\d{4}(?:_\d{2}){5})(?:_clone(\d+))?$");
            if (match.Success)
            {
                var baseName = match.Groups[1].Value;
                var cloneNum = match.Groups[2].Success ? int.Parse(match.Groups[2].Value) + 1 : 1;
                newSave = $"{baseName}_clone{cloneNum}";
            }

            // shallow copy save
            newSaveDir = new DirectoryInfo(Path.Combine(RepoSaves.FullName, newSave));

            if (!newSaveDir.Exists)
                break;
        }

        newSaveDir.Create();

        foreach (var file in saveDir.GetFiles())
        {
            if (!file.Name.Contains("BACKUP")) // REPO_SAVE_2025_04_14_22_17_01.es3
                file.CopyTo(Path.Combine(newSaveDir.FullName, $"{newSave}.es3"));
        }

        return SaveState.GetSave(newSave);
    }

    /// <summary>
    /// Delete the save file
    /// </summary>
    public void Destroy()
    {
        if (!saveDir.Exists)
            throw new Exception("Save directory does not exist.");

        saveDir.Delete(true);
    }

    /// <summary>
    /// Save the current state of the save state
    /// </summary>
    public void Save()
    {
        if (saveFile == null)
            throw new Exception("Save file does not exist.");
        saveFileStream.Write(JsonConvert.SerializeObject(_Root));
    }

    #endregion

    // the actual modify utils start here..
    /// <summary>
    /// The raw root of the save file
    /// </summary>
    public dynamic Root { get => _Root; }

    /// <summary>
    /// Game dictionaries (actual weirdos for doing this)
    /// </summary>
    public Value Dictionaries { get => new Value(_Root.dictionaryOfDictionaries); }

    /// <summary>
    /// Contains the stats for the run (level, currency, haul, ect.)
    /// </summary>
    public RunStats RunStats { get => new(this); }

    /// <summary>
    /// Get the items purchased by the players
    /// </summary>
    public MarketPlace ItemsPurchased { get => new(this, "itemsPurchased"); }

    /// <summary>
    /// Get the items purchased by the players in total
    /// </summary>
    public MarketPlace ItemsPurchasedTotal { get => new(this, "itemsPurchasedTotal"); }

    /// <summary>
    /// Get the item upgrades purchased by the players (Not sure what this is)
    /// </summary>
    public MarketPlace ItemsUpgradesPurchased { get => new(this, "itemsUpgradesPurchased"); }

    /// <summary>
    /// Get the items battery upgrades that are available for purchase in the game
    /// </summary>
    public MarketPlace ItemBatteryUpgrades { get => new(this, "itemBatteryUpgrades"); }

    /// <summary>
    /// Get the stats for a specific player
    /// </summary>
    public PlayerStats GetPlayer(SteamID player) => new(player, this);

    /// <summary>
    /// The amount of time the player has played the game in seconds
    /// </summary>
    public Value TimePlayed
    {
        get => new(_Root.timePlayed);
        set => _Root.timePlayed = value;
    }

    /// <summary>
    /// The date and time the save was created (format yyyy-MM-dd)
    /// </summary>
    public Value DateAndTime
    {
        get => new(_Root.dateAndTime);
        set => _Root.dateAndTime = value;
    }

    /// <summary>
    /// The name of the team (This is currently not used in the game)
    /// </summary>
    public Value TeamName
    {
        get => new(_Root.teamName);
        set => _Root.teamName = value;
    }
}
