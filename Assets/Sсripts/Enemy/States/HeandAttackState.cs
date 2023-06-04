using System.Collections;
using UnityEngine;

public class HeandAttackState : EnemyState
{
    [SerializeField] private int _attackForce;
    [SerializeField] private float _attackDelay;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _coroutine = StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        while (enabled)
        {
            Animator.SetTrigger("Attack");
            Player.ApplyDamage(_attackForce);
            yield return new WaitForSeconds(_attackDelay);
        }
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }
}
