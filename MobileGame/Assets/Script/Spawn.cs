using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] EnnemiesList;
    public GameObject[] SpawnList;
    public float SpawnRate;
    private float NextSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (NextSpawn > 0)
        {
            NextSpawn -= Time.deltaTime;
        }
        if (NextSpawn <= 0)
        {
            NewEnnemie();
        }
    }

    private void NewEnnemie()
    {
        NextSpawn = SpawnRate;
        Vector2 position = SpawnList[Random.Range(0, SpawnList.Length)].transform.position;
        GameObject ennemiesClone = Instantiate(EnnemiesList[Random.Range(0, EnnemiesList.Length)], new Vector2(position.x, position.y), transform.rotation);
        ennemiesClone.SetActive(true);
    }
}
