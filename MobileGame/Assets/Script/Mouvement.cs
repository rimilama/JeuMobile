using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    public GameObject bullet;
    private Rigidbody2D rb;
    public float moveSpeed;
    public float rotationSpeed;
    public float shootRate;
    private float nextShoot;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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
        Deplacement();
        Rotation();
    }

    void Deplacement()
    {
        Vector2 InputDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.AddForce(InputDir * moveSpeed);
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
}
