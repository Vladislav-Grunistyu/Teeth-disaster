using UnityEngine;

public class Kistenok : Enemy
{
    private bool ZSet = false;
    private bool XSet = false;
    private bool CSet = false;
    protected override void ClickOnEnemy()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !ZSet)
        {
            ZSet = true;
        }
        else if (Input.GetKeyDown(KeyCode.Z) && ZSet)
        {
            ChangeScore(-67 + 50);
        }

        if (Input.GetKeyDown(KeyCode.X) && !XSet)
        {
            XSet = true;
        }
        else if (Input.GetKeyDown(KeyCode.X) && XSet)
        {
            ChangeScore(-67 + 50);
        }

        if (Input.GetKeyDown(KeyCode.C) && !CSet)
        {
            CSet = true;
        }
        else if (Input.GetKeyDown(KeyCode.C) && CSet)
        {
            ChangeScore(-67 + 50);
        }

        if (ZSet && XSet && CSet)
        {
            ChangeScore(72 + 50);
            Death();
        }
    }

    protected override void Death()
    {
        PlaySound();
        Instantiate(_babahEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
