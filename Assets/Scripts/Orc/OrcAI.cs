using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum OrcStates
{
    Idle = 0,
    Move = 1,
    Attack1 = 2,
    Attack2 = 3,
    GetHit = 4,
    Victory = 5,
    Dead = 6
}

public class OrcAI : MonoBehaviour
{
    private OrcStates orcStates;
    private Animator animator;
    private NavMeshAgent agent;
    private GameObject player;
    private PlayerHealth playerHealth;
    private ParticleSystem bloodParticle;
    private OrcHealth orcHealth;
    private Vector3 startPosition;

    private float wanderTime = 10;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        bloodParticle = GetComponent<ParticleSystem>();
        orcHealth = GetComponent<OrcHealth>();
        //SetState(OrcStates.Idle);
        startPosition = transform.position;

        if (orcStates != OrcStates.Victory)
        {
            InvokeRepeating("Wander", 2, 5);
        }
    }

    void Update()
    {
        switch (orcStates)
        {
            case OrcStates.Dead:
                //TO DO
                break;
            case OrcStates.Idle:
                LookForTarget();
                break;
            case OrcStates.Move:
                LookForTarget();
                break;
            case OrcStates.Attack1:
                LookForTarget();
                break;
            case OrcStates.Attack2:
                break;
            case OrcStates.GetHit:
                break;
            case OrcStates.Victory:
                break;
            default:
                break;
        }
        Debug.Log("orc state = " + orcStates);
    }

    public void SetState(OrcStates state)
    {
        if (orcStates != state)
        {
            animator.SetInteger("State", (int)state);
            orcStates = state;
        }
    }

    private void SetAgentSpeed(float speed)
    {
        agent.speed = speed;
        animator.SetFloat("OrcVelocity", agent.velocity.magnitude);
    }

    private void LookForTarget()
    {
        SetState(OrcStates.Move);

        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        
        if (distanceToPlayer < 10)
        {
            MoveToPlayer(distanceToPlayer);
            SetAgentSpeed(5f);
        }
        else if (agent.velocity.magnitude == 0)
        {
            SetState(OrcStates.Idle);
        }
    }

    private void MoveToPlayer(float distance)
    {
        if (distance < 2f)
        {
            AttackToPlayer();
        }
        else
        {
            agent.SetDestination(player.transform.position);
            SetState(OrcStates.Move);
        }
    }

    private void AttackToPlayer()
    {
        CancelInvoke("Wander");
        if (playerHealth.isDead)
        {
            SetState(OrcStates.Victory);
        }
        else
        {
            SetState(OrcStates.Attack1);
        }    
    }

    private void HitToPlayer()
    {
        //Triggered when 0.17th second in attack01 animation

        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < 2f)
        {
            playerHealth.ModifyHealth(20f, HealthType.Damage);
        }
        //düzelt performans
    }

    public void GetHit()
    {
        Debug.Log("orca vurdu ");
        orcHealth.ModifyHealth(50);
        bloodParticle.Play();
    }

    private void Wander()
    {
        SetState(OrcStates.Move);
        Vector3 destination = startPosition + new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20));   
        SetAgentSpeed(2f);
        agent.SetDestination(destination);
    }
}
