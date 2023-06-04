using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseGameMenu;

    private bool _flag = true;

    public void BackStartMenu(int indexScene)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(indexScene);
    }
    public void Pause()
    {
        _pauseGameMenu.SetActive(_flag);
        Time.timeScale = 0f;
        _flag = false;
    }

    public void LostMenu()
    {
        _pauseGameMenu.SetActive(_flag);
        Time.timeScale = 1f;
        _flag = true;
    }

}
