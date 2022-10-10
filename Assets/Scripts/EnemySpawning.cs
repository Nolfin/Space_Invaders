using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject ramEnemy, shootingEnemy;
    
    // Start is called before the first frame update
    void Start()
    {
        for (float i = 0; i < 7; i++)
        {
            Instantiate(shootingEnemy, new Vector3( -1.5f + i / 2, 4,0), Quaternion.identity);
            Instantiate(ramEnemy, new Vector3( -1.5f + i / 2, 3.5f,0), Quaternion.identity);
            Instantiate(ramEnemy, new Vector3( -1.5f + i / 2, 3,0), Quaternion.identity);
            Instantiate(ramEnemy, new Vector3(-1.5f + i / 2, 2.5f,0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
