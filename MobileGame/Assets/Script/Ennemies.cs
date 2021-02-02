using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemies : MonoBehaviour
{
    public Teleporte Tp;
    private float rotationSpeed;
    private Rigidbody2D rb;
    public float speed;
    private Vector2 direction;
    private Personnage Personnage;
    private float mouvementAlea;
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = Random.Range(-25, 25);
        rb = GetComponent<Rigidbody2D>();
        Personnage = GameObject.FindObjectOfType<Personnage>();
        direction = Personnage.transform.position - transform.position;
        mouvementAlea = Random.Range(-5, 5);
        rb.AddForce(new Vector2(direction.x+mouvementAlea, direction.y+mouvementAlea) * speed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime);
        Tp.Bordure(this.gameObject);
    }
}
