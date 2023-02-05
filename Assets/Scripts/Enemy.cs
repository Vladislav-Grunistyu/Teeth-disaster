using UnityEngine;
using System;

public abstract class Enemy : MonoBehaviour
{
    public static Action<int> onChangeScore;

    [SerializeField] private float _speed;
    [SerializeField] protected GameObject _babahEffect;
    private Transform _player;
    private SpriteRenderer _spriteRenderer;
    private AudioSource _deathAudioSource;
    [SerializeField] protected AudioClip _audioEffect;

    private void Start()
    {
        _player = FindObjectOfType<Player>().transform;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _deathAudioSource = FindObjectOfType<AudioPlayEnemy>().GetComponent<AudioSource>();
    }

    private void Update()
    {
        MoveToTarget();
        LookAtTarget();
    }

    protected void PlaySound()
    {
        _deathAudioSource.PlayOneShot(_audioEffect);
    }

    private void LookAtTarget()
    {
        if (transform.position.x > _player.transform.position.x)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
    }
    protected void MoveToTarget()
    {
        transform.position += (_player.position - transform.position).normalized * _speed * Time.deltaTime;
    }
    protected abstract void Death();
    protected abstract void ClickOnEnemy();

    protected void ChangeScore(int score)
    {
        onChangeScore?.Invoke(score);
    }

    private void OnMouseOver()
    {
        if (Time.timeScale == 1)
        {
            ClickOnEnemy();
        }
    }
}
