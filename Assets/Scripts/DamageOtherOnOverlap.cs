using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DamageOtherOnOverlap : MonoBehaviour
{
    //float for damage to be done by bullets
    public float damageDone;
    //collider variable
    private Collider _collider;

    public void Start()
    {
        //registers the damage done to tank
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        //depletes health when damage is done
        Health otherHealth = other.GetComponent<Health>();
        if(otherHealth != null)
        {
            otherHealth.TakeDamage(damageDone);
        }

        //Destroys the object 
        Destroy(gameObject);
    }

    
}
