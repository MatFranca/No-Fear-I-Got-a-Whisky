using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    //public AudioClip deathClip;


    Animator anim;
    //AudioSource enemyAudio;
    //ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;

    public GameObject itemDrop1;

    public GameObject itemDrop2;
    void Awake()
    {
        anim = GetComponent<Animator>();
        //enemyAudio = GetComponent<AudioSource>();
        //hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        currentHealth = startingHealth;
    }


    void Update()
    {
        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        if (isDead)
            return;

        //enemyAudio.Play();

        currentHealth -= amount;

        //hitParticles.transform.position = hitPoint;
        //hitParticles.Play();

        if (currentHealth <= 0)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;

        int randomDrop = Random.Range(0, 10);
        if (randomDrop < 4)
        {
            Instantiate(itemDrop1, transform.position + new Vector3(0f, 0.25f, 0f), Quaternion.Euler(0, 0, 0));
        }
        else if (randomDrop < 8)
        {
            Instantiate(itemDrop2, transform.position + new Vector3(0f, 0.25f, 0f), Quaternion.Euler(0, 0, 0));
        }



        capsuleCollider.isTrigger = true;
        StartSinking();
        anim.SetTrigger("Dead");

        //enemyAudio.clip = deathClip;
        //enemyAudio.Play();
    }


    public void StartSinking()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        //ScoreManager.score += scoreValue;
        Destroy(gameObject, 2f);
    }
}
