using UnityEngine;

public class Health : MonoBehaviour
{
    //Variables for health and maximum health
    [HideInInspector]public float currentHealth;
    public float maxHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

//functions that causes a tank to take damage
    public void TakeDamage(float amount)
    {
        currentHealth = currentHealth - amount;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if(currentHealth <= 0)
        {
            Die();
        }
    }

//Unused healing function
    public void Heal(float amount)
    {
        currentHealth += amount;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    //function that destroys object when health is depleted

    public void Die()
    {
        Destroy(gameObject);
    }



}
