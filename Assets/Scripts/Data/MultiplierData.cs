using System;

[Serializable]
public class MultiplierData
{
    public float rate;
    public float min;
    public float max;
    public float offset = 0f;

    public MultiplierData(float rate, float min, float max, float offset)
    {
        this.rate = rate;
        this.min = min;
        this.max = max;
        this.offset = offset;
    }

    public static MultiplierData Combine(MultiplierData one, MultiplierData two)
    {
        return new MultiplierData(one.rate + two.rate, one.min + two.min, one.max + two.max, one.offset + two.offset);
    }
}