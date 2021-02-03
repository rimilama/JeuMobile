using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Ennemies : MonoBehaviour
{
    public Vector2 direction;
    public bool CreaKill;
    public Teleporte Tp;
    public float rotationSpeed;
    protected Rigidbody2D rb;
    public float speed;
    protected Personnage personnage;
    protected float mouvementAlea;
    protected int Score;

    virtual protected void Start()
    {
        this.gameObject.tag = "Ennemie";
        rotationSpeed = Random.Range(-25, 25);
        rb = GetComponent<Rigidbody2D>();
        personnage = GameObject.FindObjectOfType<Personnage>();
        if (CreaKill == false)
        {
            direction = personnage.transform.position - transform.position;
            mouvementAlea = Random.Range(-5, 5);
            rb.AddForce(new Vector2(direction.x + mouvementAlea, direction.y + mouvementAlea) * speed);
        }
        else
        {
            rb.AddForce(new Vector2(direction.x, direction.y) * speed*20);
        }
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime);
        Tp.Bordure(this.gameObject);
    }

    abstract protected void CreaPetit(GameObject EnnemieKill);
}
