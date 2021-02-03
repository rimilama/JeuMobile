using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiePetit : Ennemies
{
    protected override void Start()
    {
        base.Start();
        Score = 100;
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "bullet(Clone)")
        {
            personnage.GetComponent<Personnage>().ScoreTotal += Score;
            Destroy(collision.gameObject);
            CreaPetit(this.gameObject);
        }
    }

    protected override void CreaPetit(GameObject EnnemieKill)
    {
        Destroy(EnnemieKill);
    }
}
