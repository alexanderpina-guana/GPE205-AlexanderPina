using UnityEngine;

public class Projectile : MonoBehaviour
{
    //variable that determines for how long the projectile will exist
    public float lifespan;


//destroys the projectile after a certain amount of time
    private void Start()
    {
        Destroy(gameObject, lifespan);
    }
}
