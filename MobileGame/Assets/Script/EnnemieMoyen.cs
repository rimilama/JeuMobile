using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemieMoyen : Ennemies
{
    public GameObject NewEnnemie;

    protected override void Start()
    {
        base.Start();
        Score = 50;
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
        Vector2 position = EnnemieKill.transform.position;
        GameObject ennemiesClone1 = Instantiate(NewEnnemie, new Vector2(position.x + 1, position.y + 1), transform.rotation);
        ennemiesClone1.GetComponent<Ennemies>().direction = new Vector2(Random.value, Random.value);
        ennemiesClone1.GetComponent<Ennemies>().CreaKill = true;
        ennemiesClone1.SetActive(true);
        GameObject ennemiesClone2 = Instantiate(NewEnnemie, new Vector2(position.x - 1, position.y - 1), transform.rotation);
        ennemiesClone2.GetComponent<Ennemies>().direction = ennemiesClone1.GetComponent<Ennemies>().direction * (-1);
        ennemiesClone2.GetComponent<Ennemies>().CreaKill = true;
        ennemiesClone2.SetActive(true);


        Destroy(EnnemieKill);
    }
}
