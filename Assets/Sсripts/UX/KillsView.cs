using TMPro;
using UnityEngine;

public class KillsView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private int _kills;

    public void OnKillsUpdate(EnemyStateMachine enemy)
    {
        enemy.Died -= OnKillsUpdate;

        _kills++;

        _text.text = $"Kills: {_kills}";
    }
}
