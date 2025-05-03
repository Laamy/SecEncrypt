namespace encryptsex.Config;

class Value
{
    /*"timePlayed": {
        "__type": "float",
        "value": 6032.528
    }*/

    public string __type { get; set; }
    public dynamic value { get; set; }

    public Value(string type, float value)
    {
        this.__type = type;
        this.value = value;
    }

    public Value(dynamic value)
    {
        this.__type = value.__type;
        this.value = value.value;
    }
}
