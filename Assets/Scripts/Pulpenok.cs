using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulpenok : Enemy
{
    protected override void ClickOnEnemy()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ChangeScore(23 + 50);
            Death();
        }
        else if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.C))
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
