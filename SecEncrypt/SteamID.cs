namespace SecEncrypt;

public class SteamID
{
    public string ID;

    public SteamID(string id)
    {
        ID = id;
    }

    public static SteamID Get(string id)
    {
        return new SteamID(id);
    }
}
