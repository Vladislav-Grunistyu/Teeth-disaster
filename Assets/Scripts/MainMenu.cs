using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _castScene;
    private void Start()
    {
        Time.timeScale = 1;
    }

    public void StartGameButton()
    {
        _castScene.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
