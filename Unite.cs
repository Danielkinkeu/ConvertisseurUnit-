using System;

public class Unites{
    private string type;
    private string name;
    private double value;
    private bool baseUnit;

    public Unites(string type, string nom, double valeur, bool estBase){
        this.type = type;
        name = nom;
        value = valeur;
        baseUnit = estBase;
    }

    public Unites(string type, string name, double value): this(type,name,value,false){}

    public string Type
    {
        get{ return type;}
        set{ type = value; }
    }

    public string Name
    {
        get{ return name;}
        set{ name = value; }
    }

    public double Value
    {
        get{ return value;}
        set{ this.value = value; }
    }

     public bool BaseUnit
    {
        get{ return baseUnit;}
        set{ baseUnit = value; }
    }

}