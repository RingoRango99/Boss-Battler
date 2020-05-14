using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float health = 200f;

    public void TakeDamage(float amount)
    {

        health -= amount;

        if (health <= 0f)
        {
            Death();
        }

    }

    void Death()
    {
        GameManager.instance.KillEnemy();
        Destroy(gameObject);

    }



}
