using System;


[Serializable]
public class MyConfiguration
{
    public string data;
    public string model;
    public string code;

    public MyConfiguration(string Data, string Model, string Code)
    {
        data = Data;
        model = Model;
        code = Code;
    }
}
