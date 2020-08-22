using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    public int health;
    public int maxHealth;

    public void TakeHit(int damage)
    {
        health -= damage;

        if (health <= 0)
            Destroy(gameObject);
    }

    public void AddHealth(int health)
    {
        this.health += health;
        
        if (this.health > maxHealth)
            this.health = maxHealth;
    }
}
