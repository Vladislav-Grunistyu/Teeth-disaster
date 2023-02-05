using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public int _levelToLoad;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void FadeToLevel()
    {
        anim.SetTrigger("Fade");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(_levelToLoad);
    }
}
