using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private Animator _clueAnim;
    private Animator _pauseAnim;
    private static bool clueOpened;

    private void Start()
    {
        _pauseAnim = GetComponent<Animator>();
        if (!clueOpened)
        {
            OpenClue();
            clueOpened = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
        {
            OpenPause();
        }      
    }

    public void OpenPause()
    {
        Time.timeScale = 0;
        _pauseAnim.SetTrigger("OpenPause");
    }
    public void ClosePause()
    {
        Time.timeScale = 1;
        _pauseAnim.SetTrigger("ClosePause");
    }

    public void OpenClue()
    {
        Time.timeScale = 0;
        _clueAnim.SetTrigger("OpenClue");
    }
    public void CloseClue()
    {
        Time.timeScale = 1;
        _clueAnim.SetTrigger("CloseClue");
    }
}
