using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMesh))]
public class ChaseState : EnemyState
{
    private NavMeshAgent _agent;
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        _agent.enabled = true;
        Animator.SetBool("IsRunning", true);
    }

    private void OnDisable()
    {
        _agent.enabled = false;

    }

    private void Update()
    {
        _agent.SetDestination(Player.transform.position);
    }
}
