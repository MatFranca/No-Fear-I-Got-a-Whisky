using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    Animator anim;
    UnityEngine.AI.NavMeshAgent nav;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

        anim = GetComponent<Animator>();
    }


    void Update()
    {
        Ray lineOfSight = new Ray(transform.position, player.position - transform.position);
        RaycastHit lineOfSightHit;
        if (Physics.Raycast(lineOfSight, out lineOfSightHit) && lineOfSightHit.collider.tag.Equals("Player"))
        {
            if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
            {
                anim.SetBool("IsWalking", true);
                nav.SetDestination(player.position);

            }

        }
    }
}
