using UnityEngine;

public class ShooterTank : Shooter
{

//The bullet prefab
    public GameObject bulletPrefab;

    //Pawn
    private PawnTank pawn;
    //Fire rate of bullets
    public float fireRate;

    //how long it would take to shoot again
    public float nextShootTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pawn = GetComponent<PawnTank>();
        nextShootTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

//function that shoots the bullet
    public override void Shoot()
    {
        if(Time.time >= nextShootTime)
        {
            Shoot(pawn.shootForce);
            nextShootTime = Time.time + (1/fireRate);
        }
        
    }

//calculates the direction and magnitude of the bullet
    public override void Shoot(float shootForce)
    {
        GameObject bulletObject = Instantiate<GameObject>(bulletPrefab, muzzleLocation.position, muzzleLocation.rotation);
        Rigidbody rb = bulletObject.GetComponent<Rigidbody>();
        rb.AddForce(muzzleLocation.forward * shootForce);
    }
}
