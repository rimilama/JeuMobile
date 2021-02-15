using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EndGame : MonoBehaviour
{
    public GameObject Spawn;
    public GameObject Personnage;
    public GameObject[] Ennemies;
    public GameObject[] Bullet;
    public GameObject Panel;
    public Text texte_score;
    public bool Fin;
    // Start is called before the first frame update
    void Start()
    {
        Fin = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        Ennemies = GameObject.FindGameObjectsWithTag("Ennemie");
        Bullet = GameObject.FindGameObjectsWithTag("Bullet");
        Spawn.SetActive(false);
        Personnage.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Personnage.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        for(int i=0; i<Ennemies.Length; i++)
        {
            Ennemies[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Ennemies[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            Ennemies[i].GetComponent<Ennemies>().rotationSpeed = 0;
        }
        for (int i = 0; i < Bullet.Length; i++)
        {
            Bullet[i].SetActive(false);
        }
        texte_score.text = "Votre score est de " + Personnage.GetComponent<Personnage>().ScoreTotal +  " points";
        if (!PlayerPrefs.HasKey("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", Personnage.GetComponent<Personnage>().ScoreTotal);
        }else if(PlayerPrefs.GetInt("BestScore")< Personnage.GetComponent<Personnage>().ScoreTotal)
        {
            PlayerPrefs.SetInt("BestScore", Personnage.GetComponent<Personnage>().ScoreTotal);
        }

        Fin = true;
        Panel.SetActive(true);
    }

    public void RetourMenu()
    {

        SceneManager.LoadScene(0);
    }

}
