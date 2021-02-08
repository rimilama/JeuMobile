using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject personnage;
    public GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        personnage.transform.Rotate(new Vector3(0, 0, 50) * Time.deltaTime);
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
