using System;

[Serializable]
public class Transition
{
    public string nextPhase;
    public bool random = false;

    public Transition(string nextPhase)
    {
        this.nextPhase = nextPhase;
    }

    public Transition(string nextPhase, bool random) : this(nextPhase)
    {
        this.random = random;
    }
}
