using UnityEngine;

public class IdleState : PlayerState
{

    [SerializeField] private float _timeout;

    private float _waitTime;

    private void OnEnable()
    {
        _waitTime = 0;
    }
    private void Update()
    {
        _waitTime += Time.deltaTime;

        if( _waitTime >= _timeout )
        {
            Animator.SetTrigger("Angry");
            _waitTime = 0;
        }
    }
}
