using System;

[Serializable]
public class StatData
{
    public float speed;
    public float attackSpeed;

    public StatData(float speed, float attackSpeed)
    {
        this.speed = speed;
        this.attackSpeed = attackSpeed;
    }
}
