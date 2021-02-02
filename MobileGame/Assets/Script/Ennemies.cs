using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Ennemies
{
    Vector2 direction { get; set; }
    bool CreaKill { get; set; }
    void CreaPetit(GameObject EnnemieKill);
}
