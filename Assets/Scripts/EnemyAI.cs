using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    bool isProvoked = false;

    private NavMeshAgent navMeshAgent;
    private float distanceToTarget = Mathf.Infinity;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (isProvoked) {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange) {
            isProvoked = true;
        }
    }

    private void EngageTarget() {

        if (distanceToTarget >= navMeshAgent.stoppingDistance) {
            ChaseTarget();
        }
        else {
            AttackTarget();
        }
    }

    private void ChaseTarget() {
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget() {
        Debug.Log("Attacking player");
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
