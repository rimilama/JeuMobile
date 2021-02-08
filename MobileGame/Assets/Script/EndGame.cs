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
    public GameObject Panel;
    public Text texte_score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        Ennemies = GameObject.FindGameObjectsWithTag("Ennemie");
        Spawn.SetActive(false);
        Personnage.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Personnage.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        for(int i = 0; i< Personnage.GetComponent<Personnage>().controle.Length; i++)
        {
            Personnage.GetComponent<Personnage>().controle[i] = KeyCode.None;
        }
        for(int i=0; i<Ennemies.Length; i++)
        {
            Ennemies[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Ennemies[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            Ennemies[i].GetComponent<Ennemies>().rotationSpeed = 0;
        }
        texte_score.text = "Votre score est de " + Personnage.GetComponent<Personnage>().ScoreTotal +  " points";
        Panel.SetActive(true);

    }

    public void RetourMenu()
    {
        SceneManager.LoadScene(0);
    }

}
