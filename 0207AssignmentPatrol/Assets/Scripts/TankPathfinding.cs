using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TankPathfinding : MonoBehaviour
{
    public OffMeshLink[] teleportss;
    public GameObject[] teleports;
    public GameObject[] wayPoints;
    public enum EnemyStates { Patroll,Chasee,Attackk }
    public GameObject player;
    private NavMeshAgent agent;

    [SerializeField] private float targetDistance = 2f;
    [SerializeField] private float attakcDistance = 2f;

    public EnemyStates CurrentState
    {
        get { return currentState; }
        set
        {
            StopAllCoroutines();
            currentState = value;
            switch (currentState)
            {
                case EnemyStates.Patroll:
                    StartCoroutine(Patroll());
                    break;
                case EnemyStates.Chasee:
                    StartCoroutine(Chasee());
                    break;
                case EnemyStates.Attackk:
                    StartCoroutine(Attackk());
                    break;
            }
        }
    }
    private EnemyStates currentState;
    void Start()
    {
        teleportss = GetComponents<OffMeshLink>();
        agent = GetComponent<NavMeshAgent>();
        CurrentState = EnemyStates.Patroll;
    }
   
    public IEnumerator Patroll()
    {
        GameObject currentWaypoint = wayPoints[Random.Range(0,wayPoints.Length)];
        while (currentState == EnemyStates.Patroll)
        {
            agent.SetDestination(currentWaypoint.transform.position);
            
            if (Vector3.Distance(transform.position, currentWaypoint.transform.position) < targetDistance)
            {
                currentWaypoint = wayPoints[Random.Range(0, wayPoints.Length)];
            }
            yield return new WaitForSeconds(.1f);
        }
    }
    public IEnumerator Chasee()
    {
        while (currentState == EnemyStates.Chasee)
        {
            
            
            agent.SetDestination(player.transform.position);

            if (Vector3.Distance(transform.position, player.transform.position) < attakcDistance)
            {
                CurrentState = EnemyStates.Attackk;
            }
            yield return new WaitForSeconds(.1f);
        }
    }
    public IEnumerator Attackk()
    {
        while (currentState == EnemyStates.Attackk)
        {
            agent.SetDestination(player.transform.position);

            if (Vector3.Distance(transform.position, player.transform.position) > attakcDistance)
            {
                CurrentState = EnemyStates.Chasee;
            }
            yield return new WaitForSeconds(.1f);
        }
    }

}
