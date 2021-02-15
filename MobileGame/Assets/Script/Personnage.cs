using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Personnage : MonoBehaviour
{
    public EndGame End;
    public Teleporte Tp;
    public GameObject bullet;
    private Rigidbody2D rb;
    public float moveSpeed;
    public float maxSpeed;
    public float rotationSpeed;
    public float shootRate;
    private float nextShoot;
    public KeyCode[] controle;
    public int ScoreTotal;
    public Text textScore;
    public JoystickButton AttackButton;
    public Joystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ScoreTotal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!End.Fin)
        {
            Tp.Bordure(this.gameObject);
            if (Input.GetKey(controle[4]) || AttackButton.IsPressed)
            {
                if (nextShoot > 0)
                {
                    nextShoot -= Time.deltaTime;
                }
                if (nextShoot <= 0)
                {
                    Shoot();
                }
            }
            if (joystick.InputDir != Vector2.zero || Input.GetKey(controle[0]) || Input.GetKey(controle[1]) || Input.GetKey(controle[2]) || Input.GetKey(controle[3]))
            {
                Deplacement();
                Rotation();
            }
            textScore.text = "Score : " + ScoreTotal.ToString();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ennemie")
        {
            End.GameOver();
        }
    }

    void Deplacement()
    {
        Vector2 InputDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        InputDir = joystick.InputDir;
        rb.AddForce(InputDir * moveSpeed);
        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    void Rotation()
    {
        float Angle = Mathf.Atan2(Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"))*Mathf.Rad2Deg-90;
        Angle = Mathf.Atan2(joystick.InputDir.x*(-1), joystick.InputDir.y) * Mathf.Rad2Deg;
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
