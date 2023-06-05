using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private EnemyStateMachine[] _enemiesTemplates;

    public EnemyStateMachine CreateEnemy()
    {
        var enemyNumber = Random.Range(0, _enemiesTemplates.Length);
        var enemy = Instantiate(_enemiesTemplates[enemyNumber], transform.position, _enemiesTemplates[enemyNumber].transform.rotation);

        return enemy;
    }

}
