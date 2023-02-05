using UnityEngine;

public class Karasenok : Enemy
{
    protected override void ClickOnEnemy()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            ChangeScore(32 + 50);
            Death();
        }
        else if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.C))
        {
            ChangeScore(-67 + 50);
        }
    }

    protected override void Death()
    {
        PlaySound();
        Instantiate(_babahEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
