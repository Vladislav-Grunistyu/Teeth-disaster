using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TMP_Text _textCopy;
    [SerializeField] private TMP_Text _textPaste;
    [SerializeField] private Animator _presAnim;
    [SerializeField] private Animator _zatmAnim;
    [SerializeField] private Animator _gameOverAnim;


    private void Start()
    {
        Time.timeScale = 1;
    }

    public void GameOverScreen()
    {
        Time.timeScale = 0;
        _textPaste.text = _textCopy.text;
        _presAnim.SetTrigger("Pres");
        _gameOverAnim.SetTrigger("Show");
        _zatmAnim.SetTrigger("Zatm");
    }

}
