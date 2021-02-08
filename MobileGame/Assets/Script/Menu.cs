using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject personnage;
    public GameObject Panel;
    public GameObject Score;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            Score.SetActive(true);
            Score.GetComponent<Text>().text = "Meilleur score : " + PlayerPrefs.GetInt("BestScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        personnage.transform.Rotate(new Vector3(0, 0, 50) * Time.deltaTime);
    }

    public void BestScore()
    {

    }

    public void Jouer()
    {
        SceneManager.LoadScene(1);
    }

    public void Instruction()
    {
        Panel.SetActive(true);
    }

    public void CloseInstruction()
    {
        Panel.SetActive(false);
    }

    public void Quitter()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
