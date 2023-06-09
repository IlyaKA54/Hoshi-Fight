using UnityEngine;

public abstract class PlayerState : MonoBehaviour
{
    [SerializeField] private PlayerTransition[] _tranzitions;

    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }

    public void Enter(Rigidbody rigidbody, Animator animator)
    {
        if (enabled == false)
        {
            Rigidbody = rigidbody;
            Animator = animator;

            enabled = true;

            foreach (var transition in _tranzitions)
            {
                transition.enabled = true;
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

    public PlayerState GetNextState()
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
