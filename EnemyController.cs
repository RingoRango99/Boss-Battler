using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;
    public float damage = 15f;
    public float captureRadius = 5f;

    public GameObject player;
    Transform target;
    NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();

        target = PlayerManager.instance.player.transform;

    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }

            if (distance <= captureRadius)
            {
                Attack();
            }
            
        }


    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);


    }

    void Attack()
    {
        Debug.Log("attacking");


        player.GetComponent<PlayerStats>().RecieveDamage(damage);
       
    }


    // Used to draw the look radius to visualise how far enemies see
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
