using System;

[Serializable]
public class Movement
{
    public string name;

    public Movement()
    {

    }

    public static Movement Override(Movement one, Movement two)
    {
        return new Movement();
    }

    public void Run(Enemy enemy, Character character)
    {

    }
}
