using System;

[Serializable]
public class Enemy
{
    public string name;
    public bool isBoss;

    public Enemy(string name, bool isBoss)
    {
        this.name = name;
        this.isBoss = isBoss;
    }
}
