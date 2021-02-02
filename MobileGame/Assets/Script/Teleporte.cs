using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporte : MonoBehaviour
{
    public Camera mainCamera;

    public void Bordure(GameObject Analyser)
    {
        float CameraLargeur = mainCamera.orthographicSize * 2 * mainCamera.aspect;
        float CameraHauteur = mainCamera.orthographicSize * 2;

        float BordureDroite = CameraLargeur / 2;
        float BordureGauche = BordureDroite * (-1);
        float BordureHaut = CameraHauteur / 2;
        float BordureBas = BordureHaut * (-1);

        if (Analyser.transform.position.x > BordureDroite)
        {
            Analyser.transform.position = new Vector2(BordureGauche, Analyser.transform.position.y);
        }
        if (Analyser.transform.position.x < BordureGauche)
        {
            Analyser.transform.position = new Vector2(BordureDroite, Analyser.transform.position.y);
        }
        if (Analyser.transform.position.y > BordureHaut)
        {
            Analyser.transform.position = new Vector2(Analyser.transform.position.x, BordureBas);
        }
        if (Analyser.transform.position.x < BordureGauche)
        {
            Analyser.transform.position = new Vector2(Analyser.transform.position.x, BordureHaut);
        }
    }
}
