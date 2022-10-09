using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    public float timeToShoot;
    public GameObject enemyBulletPrefab;
    
    private IEnumerator _coroutine;
    
    void Start()
    {
        _coroutine = EnemyShoot();
        StartCoroutine(_coroutine);
    }

    IEnumerator EnemyShoot()
    {
        while(true)
        {
            timeToShoot = Random.Range(4, 7);
            yield return new WaitForSeconds(timeToShoot);
            Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);
        }
    }
}
