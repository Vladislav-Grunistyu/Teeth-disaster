using UnityEngine;

public class Health : MonoBehaviour
{
    private GameObject[] _hearts = new GameObject[3];
    private int _healPoint = 3;
    private GameOver _gameOver;
    [SerializeField] AudioSource _defeatAudioSource;

    private void Start()
    {
        _gameOver = FindObjectOfType<GameOver>();
        for (int i = 0; i < transform.childCount; i++)
        {
            _hearts[i] = transform.GetChild(i).gameObject;
        }
    }
    private void OnEnable()
    {
        Player.onHit += TakeDamage;
    }

    private void TakeDamage()
    {
        _healPoint -= 1;
        _hearts[_healPoint].GetComponent<Animator>().SetTrigger("TakeHit");
        if (_healPoint == 0)
        {
            _defeatAudioSource.Play();
            _gameOver.GameOverScreen();
        }
    }

    private void OnDisable()
    {
        Player.onHit -= TakeDamage;
    }
}
