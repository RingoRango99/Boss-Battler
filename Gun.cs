using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public float damage = 10f;
    public float fireRate = .25f;
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public Transform gunEnd;

    public Camera fpsCam;

    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
    private AudioSource gunAudio;
    private LineRenderer laserLine;
    private float nextFire;

    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        fpsCam = GetComponentInParent<Camera>();
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {

            nextFire = Time.time + fireRate;

            StartCoroutine(ShotEffect());

            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            laserLine.SetPosition(0, gunEnd.position);

            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {

                laserLine.SetPosition(1, hit.point);

                Enemy health = hit.collider.GetComponent<Enemy>();


                if (health != null)
                {
                    health.TakeDamage(damage);
                   
                }
                if (hit.rigidbody != null)
                {

                    hit.rigidbody.AddForce(-hit.normal * hitForce);

                }
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            }
        }

 
    }

    private IEnumerator ShotEffect()
    {
        gunAudio.Play();

        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;


    }


}
