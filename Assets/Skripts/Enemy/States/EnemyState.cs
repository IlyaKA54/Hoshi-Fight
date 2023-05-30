using UnityEngine;

public abstract class EnemyState : MonoBehaviour
{
    [SerializeField] private EnemyTransition[] _tranzitions;

    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    public PlayerStateMachine Player { get; private set; }

    public void Enter(Rigidbody rigidbody, Animator animator, PlayerStateMachine player)
    {
        if (enabled == false)
        {
            Rigidbody = rigidbody;
            Animator = animator;
            Player = player;

            enabled = true;

            foreach (var transition in _tranzitions)
            {
                transition.enabled = true;
                transition.Init(Player);
            }
        }
    }

    public void Exit()
    {
        if (enabled == true)
        {
            foreach (var transition in _tranzitions)
            {
                transition.enabled = false;
            }
        }

        enabled = false;
    }

    public EnemyState GetNextState()
    {
        foreach (var transition in _tranzitions)
        {
            if (transition.NeedTransit)
            {
                return transition.TargetState;
            }

        }

        return null;
    }
}
