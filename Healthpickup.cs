using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthpickup : MonoBehaviour
{
    public float healthAmmount = 50;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            other.GetComponent<PlayerStats>().Increase(healthAmmount);
            Destroy(gameObject);
        }
    }
}
