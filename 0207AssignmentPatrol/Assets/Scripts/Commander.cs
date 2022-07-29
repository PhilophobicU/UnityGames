using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Commander : MonoBehaviour
{
    public OffMeshLink[] teleports;
    public GameObject[] wayPoints;
    public enum EnemyStates { Patrol, Chase, Attack }
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
                case EnemyStates.Patrol:
                    StartCoroutine(Patrol());
                    break;
                case EnemyStates.Chase:
                    StartCoroutine(Chase());
                    break;
                case EnemyStates.Attack:
                    StartCoroutine(Attack());
                    break;
            }
        }
    }
    

    public TankPathfinding[] tanks;

    private EnemyStates currentState;
    void Start()
    {
        teleports = FindObjectsOfType<OffMeshLink>();
        tanks = FindObjectsOfType<TankPathfinding>();
        agent = GetComponent<NavMeshAgent>();
        CurrentState = EnemyStates.Patrol;
        foreach (OffMeshLink item in teleports)
        {
            item.activated = false;
        }
    }
    IEnumerator Patrol()
    {
        GameObject currentWaypoint = wayPoints[Random.Range(0, wayPoints.Length)];
        while (currentState == EnemyStates.Patrol)
        {
            Debug.Log("patroldeyim");
            agent.SetDestination(currentWaypoint.transform.position);

            if (Vector3.Distance(transform.position, currentWaypoint.transform.position) < targetDistance)
            {
                currentWaypoint = wayPoints[Random.Range(0, wayPoints.Length)];
            }
            yield return new WaitForSeconds(.1f);
        }
    }
    IEnumerator Chase()
    {
        while (currentState == EnemyStates.Chase)
        {
            agent.SetDestination(player.transform.position);
            Debug.Log("takipteyim");

            if (Vector3.Distance(transform.position, player.transform.position) < attakcDistance)
            {
                Debug.Log("takibi biraktim atack ");
                CurrentState = EnemyStates.Attack;
            }
            yield return new WaitForSeconds(.1f);
        }
    }
    IEnumerator Attack()
    {
        while (currentState == EnemyStates.Attack)
        {
            agent.SetDestination(player.transform.position);
            Debug.Log("Saldir");

            if (Vector3.Distance(transform.position, player.transform.position) > attakcDistance)
            {
                Debug.Log("v?s");
                CurrentState = EnemyStates.Chase;
            }
            yield return new WaitForSeconds(.1f);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CurrentState = EnemyStates.Chase;
            foreach (TankPathfinding item in tanks)
            {
                item.CurrentState = TankPathfinding.EnemyStates.Chasee;
            }
        }
    }
}
