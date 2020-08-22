using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    public int health;
    public int maxHealth;

    private int maxHitCooldown = 100;
    private int hitCooldown = 0;
    private bool isHit = false;

    private int maxHealCooldown = 50;
    private int healCooldown = 0;
    private bool isHealed = false;


    public void TakeHit(int damage)
    {
        if (isHit)
            return;
        health -= damage;
        hitCooldown = maxHitCooldown;
        isHit = true;
        if (health <= 0)
            Destroy(gameObject);
    }

    public void AddHealth(int health)
    {
        this.health += health;
        isHealed = true;
        healCooldown = maxHealCooldown;
        if (this.health > maxHealth)
            this.health = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (health < maxHealth && col.gameObject.CompareTag("Health")){
            AddHealth(1);
            Destroy(col.gameObject);
        }
    }

    public void Update()
    {
        if (isHit){
            SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
            sr.color = Color.red;
            hitCooldown--;
            if (hitCooldown <= 0){
                sr.color = Color.white;
                isHit = false;
            }
        }else
        if (isHealed){
            SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
            sr.color = Color.cyan;
            healCooldown--;
            if (healCooldown <= 0){
                sr.color = Color.white;
                isHealed = false;
            }
        }
            
        
    }


}
