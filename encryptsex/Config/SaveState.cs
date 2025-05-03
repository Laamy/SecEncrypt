namespace encryptsex.Config;
#pragma warning disable IDE0025

using System;
using System.IO;
using System.Text.RegularExpressions;

using Newtonsoft.Json;

class SaveState
{
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
    public dynamic Root { get => _Root; }
    public dynamic Dictionaries { get => _Root.dictionaryOfDictionaries.value; }
    public dynamic RunStats { get => _Root.dictionaryOfDictionaries.value.runStats; }

    public PlayerStats GetPlayerStats(SteamID player) => new(player, this);

    //{
    //  "runStats": {
    //      "level": 0,
    //      "currency": 0,
    //      "lives": 3,
    //      "chargingStationCharge": 1,
    //      "chargingStationChargeTotal": 100,
    //      "totalHaul": 0,
    //      "save level": 0
    //  }
    //}

    public int Level
    {
        get => RunStats.level + 1;
        set => RunStats.level = value - 1;
    }

    public int Currency
    {
        get => RunStats.currency;
        set => RunStats.currency = value;
    }

    public int Lives
    {
        get => RunStats.lives;
        set => RunStats.lives = value;
    }

    public int ChargingStationCharge
    {
        get => RunStats.chargingStationCharge;
        set => RunStats.chargingStationCharge = value;
    }

    public int ChargingStationChargeTotal
    {
        get => RunStats.chargingStationChargeTotal;
        set => RunStats.chargingStationChargeTotal = value;
    }

    public int TotalHaul
    {
        get => RunStats.totalHaul;
        set => RunStats.totalHaul = value;
    }

    public int SaveLevel
    {
        get => RunStats.saveLevel;
        set => RunStats.saveLevel = value;
    }

    //envClone.saveRoot.dictionaryOfDictionaries.value.playerUpgradeStrength["76561198930262816"] = 30;
}
