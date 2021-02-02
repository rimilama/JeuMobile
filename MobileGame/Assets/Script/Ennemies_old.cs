using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemies_old : MonoBehaviour
{
    public Teleporte Tp;
    public GameObject[] EnnemieList;
    private float rotationSpeed;
    private Rigidbody2D rb;
    public float speed;
    private Vector2 direction;
    private Personnage Personnage;
    private float mouvementAlea;
    private bool CreaKill;
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

    private void CreaPetit(GameObject EnnemieKill)
    {
        if(EnnemieKill.tag == "Size3")
        {
            NewInstance(EnnemieKill, EnnemieList[1]);
        }
        else if(EnnemieKill.tag == "Size2")
        {
            Destroy(EnnemieKill);
        }
        else if(EnnemieKill.tag == "Size1")
        {
            Destroy(EnnemieKill);
        }
    }

    private void NewInstance(GameObject EnnemieKill, GameObject NewEnnemie)
    {
        Vector2 position = EnnemieKill.transform.position;
        GameObject ennemiesClone = Instantiate(NewEnnemie, new Vector2(position.x+1, position.y+1), transform.rotation);
        ennemiesClone.GetComponent<Ennemies_old>().direction = new Vector2(Random.value, Random.value);
        ennemiesClone.SetActive(true);
        if (NewEnnemie.tag == "Size2")
        {
            GameObject ennemiesCloneBis = Instantiate(NewEnnemie, new Vector2(position.x-1, position.y-1), transform.rotation);
            ennemiesCloneBis.GetComponent<Ennemies_old>().direction = ennemiesClone.GetComponent<Ennemies_old>().direction * (-1);
            ennemiesCloneBis.SetActive(true);
        }
        ennemiesClone.SetActive(true);
        Destroy(EnnemieKill);
    }
}
