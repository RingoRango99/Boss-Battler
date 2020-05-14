using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrow : MonoBehaviour
{

    public float throwForce = 1000f;
    public GameObject grenadePref;

    float timer = 5f;
    float countdown;

    bool isThrown;

    public GrenadeCooldown gCooldown;

    // Start is called before the first frame update
    void Start()
    {
        isThrown = false;

        countdown = timer;

        gCooldown.SetMaxCooldown(Mathf.FloorToInt(timer));
    }

    // Update is called once per frame
    void Update()
    {
        if (isThrown == true)
        {
            countdown -= Time.deltaTime;
            gCooldown.Setcooldown(Mathf.FloorToInt(countdown));
            if (countdown <= 0)
            {
                
                isThrown = false;
            }
        }


        if (!isThrown)
        {
            if (Input.GetButtonDown("Fire2"))
            {

                ThrowGrenade();
                isThrown = true;

            }
        }
       
    }

    void ThrowGrenade()
    {

        GameObject grenade = Instantiate(grenadePref, transform.position, transform.rotation);

        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce);

        countdown = timer;

    }
}
