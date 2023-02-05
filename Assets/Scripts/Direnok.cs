using UnityEngine;

public class Direnok : Enemy
{
    [SerializeField] private GameObject _miniDirenok;
    protected override void ClickOnEnemy()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Death();
        }
        else if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X))
        {
            ChangeScore(-67 + 50);
        }
    }

    protected override void Death()
    {
        if (_miniDirenok != null)
        {
            ChangeScore(25 + 50);
            Instantiate(_miniDirenok, transform.position + Vector3.one /2, Quaternion.identity);
            Instantiate(_miniDirenok, transform.position - Vector3.one /2, Quaternion.identity);
        }
        ChangeScore(5 + 50);
        PlaySound();
        Instantiate(_babahEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
