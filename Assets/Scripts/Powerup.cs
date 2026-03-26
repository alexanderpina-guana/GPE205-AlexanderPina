[System.Serializable]

public abstract class Powerup
{
    //The duration of how long the powerup will last on the target
    public float lifespan;

    //Applies the powerup's effect
    public abstract void Apply(Pawn target);

    //Removes the powerup's effect
    public abstract void Remove(Pawn target);
}
