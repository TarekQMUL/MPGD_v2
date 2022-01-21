 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MutantScript : MonoBehaviour
{
    [SerializeField] NavMeshAgent bot;
    GameObject[] target;
    int rndIndex;
    Vector3 nextTarget;
    [SerializeField] Transform playerTarget;
    public float lookRadius = 10f;
    bool patrolMode;

    public float health = 50f;

   // public Slider enemyHealthBar;

    // Start is called before the first frame update


    public Slider healthbar;
    void Start()
    {
        playerTarget = PlayerManager.instance.player.transform;

        target = GameObject.FindGameObjectsWithTag("PatrolPoint");
        GotoNextPoint();
        rndIndex = UnityEngine.Random.Range(0, target.Length);
        bot.SetDestination(target[rndIndex].transform.position);
    }

    private void GotoNextPoint()
    {
        bot.SetDestination(target[rndIndex].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //enemyHealthBar.value = health / 50f;
        if (target != null && patrolMode)
        {
            rndIndex = UnityEngine.Random.Range(0, target.Length);
            nextTarget = target[rndIndex].transform.position;
            if (!bot.pathPending)
            {
                if (bot.remainingDistance <= bot.stoppingDistance)
                {
                    if (!bot.hasPath || bot.velocity.sqrMagnitude == 0f)
                    {
                        bot.SetDestination(nextTarget);
                    }
                }
            }
        }
        float distance = Vector3.Distance(playerTarget.position, transform.position);
        if (distance <= lookRadius)
        {
            patrolMode = false;
            // Move towards the player
            bot.SetDestination(playerTarget.position);
        }
        else
            patrolMode = true;


        UpdateAnimator();
        healthbar.value = health/50f;
    }

    private void UpdateAnimator()
    {
        Vector3 playerVelocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(playerVelocity);
        GetComponent<Animator>().SetFloat("mutantmove", localVelocity.z);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}

