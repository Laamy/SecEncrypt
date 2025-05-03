namespace SecEncrypt;

// TODO: alloww direct modifying of this
public class Value
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

//namespace encryptsex.Config;

//class Value
//{
//    /*"timePlayed": {
//        "__type": "float",
//        "value": 6032.528
//    }*/

//    private string __typeInternal = "";
//    private dynamic valueInternal = null;
//    private dynamic valueObj = null;

//    public string __type
//    {
//        get => {
//            if (saveState != null)
//                return valueObj.__type;
//            else return __typeInternal;
//        }
//        set => {
//            if (saveState != null)
//                valueObj.__type = value;
//            else __typeInternal = value;
//        }
//    }
//    public dynamic value
//    {
//        get; set;
//    }

//    private SaveState saveState;

//    public Value(string type, float value)
//    {
//        this.__type = type;
//        this.value = value;
//    }

//    public Value(SaveState saveState, dynamic value)
//    {
//        this.saveState = saveState;
//        this.valueObj = value;
//    }
//}
