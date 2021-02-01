using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    private Camera mainCamera;
    public GameObject bullet;
    private Rigidbody2D rb;
    public float moveSpeed;
    public float maxSpeed;
    public float rotationSpeed;
    public float shootRate;
    private float nextShoot;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Bordure();
        if (Input.GetKey(KeyCode.Space))
        {
            if (nextShoot > 0)
            {
                nextShoot -= Time.deltaTime;
            }
            if(nextShoot <= 0)
            {
                Shoot();
            }
        }
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            Deplacement();
            Rotation();
        }
    }

    void Deplacement()
    {
        Vector2 InputDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.AddForce(InputDir * moveSpeed);
        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    void Rotation()
    {
        float Angle = Mathf.Atan2(Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"))*Mathf.Rad2Deg-90;
        Quaternion rotation = Quaternion.AngleAxis(Angle, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        nextShoot = shootRate;
        GameObject bulletClone = Instantiate(bullet, new Vector2(bullet.transform.position.x, bullet.transform.position.y), transform.rotation);
        bulletClone.SetActive(true);
        bulletClone.GetComponent<Bullet>().killClone();
    }

    void Bordure()
    {
        float CameraLargeur = mainCamera.orthographicSize * 2 * mainCamera.aspect;
        float CameraHauteur = mainCamera.orthographicSize * 2;

        float BordureDroite = CameraLargeur / 2;
        float BordureGauche = BordureDroite * (-1);
        float BordureHaut = CameraHauteur / 2;
        float BordureBas = BordureHaut * (-1);

        if (transform.position.x > BordureDroite)
        {
            transform.position = new Vector2(BordureGauche, transform.position.y);
        }
        if (transform.position.x < BordureGauche)
        {
            transform.position = new Vector2(BordureDroite, transform.position.y);
        }
        if (transform.position.y > BordureHaut)
        {
            transform.position = new Vector2(transform.position.x, BordureBas);
        }
        if (transform.position.x < BordureGauche)
        {
            transform.position = new Vector2(transform.position.x, BordureHaut);
        }
    }
}
