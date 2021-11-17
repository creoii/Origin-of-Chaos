using System;

[Serializable]
public class MultiplierData
{
    public float rate;

    public MultiplierData(float rate)
    {
        this.rate = rate;
    }

    public static MultiplierData Combine(MultiplierData one, MultiplierData two)
    {
        return new MultiplierData(one.rate + two.rate);
    }
}