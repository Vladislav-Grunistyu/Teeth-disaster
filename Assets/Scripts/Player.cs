using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Action onHit;
    public static Action<int> onChangeScore;

    private Animator _playerAnim;
    private SpriteRenderer _playerSprite;

    [SerializeField] AudioSource _hitAudioSource;

    private void Start()
    {
        _playerAnim = GetComponent<Animator>();
        _playerSprite = GetComponent<SpriteRenderer>();
    }
    private void MissEnemy()
    {
        _playerAnim.SetTrigger("Scary");
        _hitAudioSource.Play();
        onHit?.Invoke();
    }

    private void Update()
    {
        if (Time.timeScale == 1)
        {
            LookAtCursor();
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.C))
            {
                _playerAnim.SetTrigger("Attack");
                ChangeScore(-50);
            }
        }
    }

    private void LookAtCursor()
    {
        Vector2 worldPosition = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
        Vector2 screenPosition = Camera.main.ScreenToWorldPoint(worldPosition);
        if (screenPosition.x > transform.position.x)
        {
            _playerSprite.flipX = true;
        }
        else
        {
            _playerSprite.flipX = false;
        }
    }

    private void ChangeScore(int score)
    {
        onChangeScore?.Invoke(score);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            MissEnemy();
        }
    }
}
