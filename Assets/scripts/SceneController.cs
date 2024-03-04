using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    private GameObject[] enemies;
    private Vector3 spawnPoint = new Vector3 (0, 0, 5);
    private int numEnemies = 5;
    [SerializeField]
    private GameObject iguanaPrefab;
    private GameObject[] iguanas;
    private int numIguanas = 10;
    [SerializeField]
    private Transform iguanaSpawnPt;

    private void Start()
    {
        enemies = new GameObject[numEnemies];
        iguanas = new GameObject[numIguanas];

        // spawn multiple iguana instances
        for (int i = 0; i < iguanas.Length; i++)
        {
            if (iguanas[i] == null)
            {
                iguanas[i] = Instantiate(iguanaPrefab) as GameObject;
                iguanas[i].transform.position = iguanaSpawnPt.position;
                float angle = Random.Range(0, 360);
                iguanas[i].transform.Rotate(0, angle, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // spawn multiple enemy instances
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] == null)
            {
                enemies[i] = Instantiate(enemyPrefab) as GameObject;
                enemies[i].transform.position = spawnPoint;
                float angle = Random.Range(0, 360);
                enemies[i].transform.Rotate(0, angle, 0);
            }
        }
        
    }
}
