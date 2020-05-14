using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health = 200;
    public float damageTaken;

    public Healthbar healthBar;

    public GameManager gManager;

    // Start is called before the first frame update
    void Start()
    {
        gManager = GetComponent<GameManager>();
        damageTaken = 0;
        healthBar.SetMaxHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void RecieveDamage(float damageTaken)
    {

        health -= Mathf.FloorToInt(damageTaken);

        healthBar.SetHealth(health);

        if (health <= 0f)
        {
            Death();
        }

    }

    public void Increase(float ammount)
    {
 
        health = health + Mathf.FloorToInt(ammount);
        healthBar.SetHealth(health);

    }

    private void Death()
    {
        GameManager.instance.gameOver = true;

    }
}
