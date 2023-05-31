using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject _infoPanel;

    private bool _flag = true;

    public void StartGame(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }

    public void CheckInfo()
    {
        _infoPanel.SetActive(_flag);

        _flag = !_flag;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
