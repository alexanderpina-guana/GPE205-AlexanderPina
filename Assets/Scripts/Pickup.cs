using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Pickup : MonoBehaviour
{

  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        Collider theCollider = GetComponent<Collider>();
        theCollider.isTrigger = true;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public virtual void OnTriggerEnter(Collider other)
    {
      
    }

    public virtual void OnDestroy()
    {
        
    }
}
