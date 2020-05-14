using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    float timer = 2f;
    float countdown;
    float radius = 10f;
    float force = 500f;
    float damage = 50f;

    bool hasExploded;

    public GameObject Particles;



    Enemy health;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Enemy>();
        countdown = timer;

    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0 && !hasExploded)
        {
            Explode();
        }
    }



    void Explode()
    {
        GameObject spawnedParticle = Instantiate(Particles, transform.position, transform.rotation);
        Destroy(spawnedParticle, 1);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);

                Destroy(gameObject);
            }
        }

        hasExploded = true;

    }


}
