using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveController : ActionController
{
    [Header("MoveController")]

    [SerializeField]
    protected NavMeshAgent agent;

    [SerializeField]
    protected bool isOnGround;

    [SerializeField]
    protected Transform[] navpointsList;

    [SerializeField]
    int ActualNavpoint = 0;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void InitMoveBehaviour()
    {
        if (navpointsList.Length > 0)
        {
            agent.isStopped = false;
            agent.SetDestination(navpointsList[ActualNavpoint].position);
        }
        else
        {
            StopMoveBehaviour();
        }
    }

    public void MoveBehaviour()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);

        if (navpointsList.Length > 0)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                ActualNavpoint++;
                if (ActualNavpoint >= navpointsList.Length - 1)
                {
                    ActualNavpoint = 0;
                }
                agent.SetDestination(navpointsList[ActualNavpoint].position);
            }
        }
        else
        {
            StopMoveBehaviour();
        }
    }

    public void StopMoveBehaviour()
    {
        agent.isStopped = true;
        agent.velocity = Vector3.zero;
    }
}
