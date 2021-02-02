using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemieGrand : MonoBehaviour, Ennemies
{
    public Teleporte Tp;
    public GameObject NewEnnemie;
    private bool CreaKill;
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
        if (CreaKill == false)
        {
            direction = Personnage.transform.position - transform.position;
            mouvementAlea = Random.Range(-5, 5);
            rb.AddForce(new Vector2(direction.x + mouvementAlea, direction.y + mouvementAlea) * speed);
        }
        else
        {
            rb.AddForce(new Vector2(direction.x, direction.y) * speed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime);
        Tp.Bordure(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "bullet(Clone)")
        {
            Destroy(collision.gameObject);
            CreaPetit(this.gameObject);
        }
    }

    public void CreaPetit(GameObject EnnemieKill)
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
